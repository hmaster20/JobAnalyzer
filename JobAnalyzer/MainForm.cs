﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JobAnalyzer
{
    public partial class MainForm : Form
    {
        Handler getVacancy;
        VacancyCollection _vacancyCollection;
        Areas ars;

        /// <summary>Словарь для построения запроса</summary>
        Dictionary<string, List<string>> DicQuery { get; set; }

        public MainForm()
        {
            InitializeComponent();

            getVacancy = new Handler();

            _vacancyCollection = new VacancyCollection();
            ars = new Areas();
            DicQuery = new Dictionary<string, List<string>>();

            for (int i = 1; i < 31; i++)
            {
                cbPeriod.Items.Add(i);
            }

            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.AutoFlush = true;
            Debug.Indent();
            Debug.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Debug.WriteLine("Exiting Main");
            Debug.Unindent();

            System.Diagnostics.Trace.WriteLine("Trace - Hello World!");
            System.Diagnostics.Debug.WriteLine("Debug - Hello World!");
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (File.Exists(VacancyCollection.BaseName))     // Если база создана, то выполняем
            {
                _vacancyCollection = VacancyCollection.Load();

                if (_vacancyCollection.VacancyList.Count > 0) RefreshTable();
            }
            LoadCountry();
        }

        private void RefreshTable()    // Обновление таблицы путем фильтрации элементов по полю Path
        {
            List<Items> filtered = _vacancyCollection.VacancyList;

            dgvTable.DataSource = null;
            dgvTable.DataSource = filtered;
        }


        #region Analyze

        private void btnAddKeyforAnalyze_Click(object sender, EventArgs e)
        {
            lbKeys.Items.Add(tbKey.Text);
        }

        private void lbKeys_DoubleClick(object sender, EventArgs e)
        {
            lbKeys.Items.Remove(lbKeys.SelectedItem);
        }

        #endregion



        // Получить список стран
        private void btnRefreshCountry_Click(object sender, EventArgs e)
        {
            btnRefreshCountry.Enabled = false;
            LoadCountry();
            btnRefreshCountry.Enabled = true;
        }

        private void LoadCountry()
        {
            try
            {
                cbCountry.Items.Clear();
                List<Area> ListArea = getVacancy.GetCountry();
                ListArea.Sort(Area.CompareByName);
                cbCountry.Items.AddRange(ListArea.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Получить периоды
        private void btnRefreshPeriod_Click(object sender, EventArgs e)
        {
            btnRefreshPeriod.Enabled = false;
            cbGrafik.Items.Clear();
            cbGrafik.Items.AddRange(getVacancy.GetGrafik().schedule);    // []Schedule
            btnRefreshPeriod.Enabled = true;
        }

        private void cbGrafik_SelectedIndexChanged(object sender, EventArgs e)
        {
            Schedule _period = new Schedule();
            if (cbGrafik.SelectedItem is Schedule)
            {
                _period = (Schedule)cbGrafik.SelectedItem;
            }

            string key = "grafik";
            string par = "&schedule=" + _period.id;
            SetRequestParam(key, par);
        }


        private void cbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = "period";
            string par = "&search_period=" + cbPeriod.SelectedItem.ToString();
            SetRequestParam(key, par);
        }

        private void cbSpecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Specs _spec = new Specs();
            if (cbSpecs.SelectedItem is Specs)
            {
                _spec = (Specs)cbSpecs.SelectedItem;
            }

            string key = "specs";
            string par = "&specialization=" + _spec.id;
            SetRequestParam(key, par);
        }

        /// <summary>Корректировка словаря параметров запросов</summary>
        /// <param name="key">ключ</param>
        /// <param name="par">URL значение</param>
        private void SetRequestParam(string key, string par)
        {
            if (!DicQuery.ContainsKey(key)) // проверяем создан ли ключ
            {
                DicQuery.Add(key, new List<string>());
                DicQuery[key].Add(par);
                return;
            }
            else
            {
                DicQuery[key].Clear();
                DicQuery[key].Add(par);
            }
        }



        #region Постройка дерева
        void TreeViewDeveloper(Areas _areas)
        {
            TreeNode treeNode = new TreeNode(_areas.name);
            AddChildren(treeNode, _areas.areas);
            treeView1.Nodes.Add(treeNode);
        }

        void AddChildren(TreeNode treeNode, List<Areas> _areas) // Рекурсивное построение дерева
        {
            _areas.Sort(Areas.CompareByName);   // Сортировка дерева
            foreach (var item in _areas)
            {
                TreeNode newNode = new TreeNode(item.name);
                treeNode.Nodes.Add(newNode);
                if (item.areas != null && item.areas.Count > 0)
                {
                    AddChildren(newNode, item.areas);
                }
            }
        }
        #endregion

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получить список регионов
            Area _country = new Area();
            if (cbCountry.SelectedItem is Area)
            {
                _country = (Area)cbCountry.SelectedItem;
            }

            foreach (TreeNode countryNode in treeView1.Nodes)  // исключаем дублирование элементов
            {
                if (countryNode.Text == _country.name)
                    return;
            }

            ars = getVacancy.GetRegions(_country.id.ToString());
            treeView1.Nodes.Clear();
            TreeViewDeveloper(ars);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectRegion(e.Node.Text);
        }

        // Выбор региона
        private void SelectRegion(string nodeName)
        {
            try
            {
                Areas _regionA = Areas.Find(ars, nodeName);

                if (_regionA != null)
                {
                    string region = "&area=" + _regionA.id;

                    if (!DicQuery.ContainsKey("country"))// проверяем создан ли ключ
                    {
                        DicQuery.Add("country", new List<string>());
                        DicQuery["country"].Add(region);
                        return;
                    }
                    else
                    {
                        if (_regionA.parent_id == null)     // если нет родителя (parent_id), значит это страна
                        {
                            //if (!DicQuery["country"].Contains(region))  // если &area=113 не существует, то добавить
                            //{
                            //    deleteParent(region);
                            //    deleteChild(region);
                            //    DicQuery["country"].Add(region);
                            //    return;
                            //}
                            //else
                            //{   // даже если он есть удаляем все лишнее
                            //    deleteParent(region);
                            //    deleteChild(region);
                            //    DicQuery["country"].Add(region);// проверка чтобы удаленный объект возвращался на место
                            //    return;
                            //}

                            deleteParent(region);
                            deleteChild(region);
                            DicQuery["country"].Add(region);
                            return;

                        }       // есть родитель, запуск поиска
                        else
                        {
                            deleteParent(region);
                            deleteChild(region);
                            if (!DicQuery["country"].Contains(region))
                            {
                                DicQuery["country"].Add(region);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Выполняется метод: SelectRegion. \n\nОшибка:\n" + ex.Message); }
        }

        //удаление предков на основе parent_id (идем снизу вверх)
        void deleteParent(string node)
        {
            try
            {
                Areas objectID = Areas.FindbyID(ars, node.Substring(node.LastIndexOf('=') + 1));

                if (objectID != null)
                {
                    if (objectID.parent_id != null)
                    {
                        string parent = "&area=" + objectID.parent_id;

                        if (DicQuery["country"].Contains(parent))
                            DicQuery["country"].Remove(parent);

                        deleteParent(parent);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Выполняется метод: checkArea3. /nОшибка:/n" + ex.Message); }
        }

        //удаление детей на основе parent_id (идем сверху вниз)
        void deleteChild(string node)
        {
            string nodeID = node.Substring(node.LastIndexOf('=') + 1);   // 113

            List<string> ss = new List<string>();

            DicQuery["country"].ForEach(x => ss.Add(x));


            // for (int i = 0; i < DicQuery["country"].Count; i++)
            for (int i = 0; i < ss.Count(); i++)
            {
                string count = ss[i];
                string count_number = count.Substring(count.LastIndexOf('=') + 1);   // 113

                List<string> listParent = new List<string>();

                Areas _id_obj = Areas.FindbyID(ars, count_number);
                if (_id_obj != null)    //если есть объект
                {
                    checkparent(_id_obj.id, ref listParent);
                }

                foreach (var pr in listParent)
                {
                    if (pr == nodeID)
                    {
                        DicQuery["country"].Remove(count);
                        break;
                    }
                }
            }
        }

        void checkparent(string id, ref List<string> parent)
        {
            Areas _id_obj = Areas.FindbyID(ars, id);
            if (_id_obj != null)    //если есть объект
            {
                if (_id_obj.parent_id != null)
                {
                    parent.Add(_id_obj.id);
                    checkparent(_id_obj.parent_id, ref parent);
                }
                else
                {   // если родителей нет, значит корневой элемент, добавляем и выходим
                    parent.Add(_id_obj.id);
                }
            }
        }



        private string getQueryText()
        {
            return tbQuery.Text;
        }

        private void setQueryText(string query)
        {
            tbQuery.Text = query;
        }

        // проверка строки запроса
        private void btnCheckTextQuery_Click(object sender, EventArgs e)
        {
            string query = "";

            query += ("?text=" + System.Uri.EscapeDataString(tbTextForQuery.Text));  // преобразовываем строку в формат URL

            if (DicQuery != null && DicQuery.Keys.Count > 0)
            {
                foreach (var _key in DicQuery.Keys)
                {
                    if (DicQuery[_key].Count > 0)
                    {
                        foreach (var _listElement in DicQuery[_key])
                        {
                            query += _listElement;
                        }
                    }
                }
            }
            setQueryText(query);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            getVacancy.FindAllVacancies(tbQuery.Text);
        }

        // сброс
        private void btnReset_Click(object sender, EventArgs e)
        {
            DicQuery.Clear();
            tbTextForQuery.Text = "";
            tbQuery.Text = "";
        }


        private void btnVac_Click(object sender, EventArgs e)
        {
            //string vac = "19291539";
            //getVacancy.GetVacancy(vac);
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {

            //  _vacancyCollection.DicKey
        }

        private void btnCheckSpecs_Click(object sender, EventArgs e)
        {
            btnCheckSpecs.Enabled = false;
            cbSpecs.Items.Clear();

            //cbCountry.Items.Clear();
            //List<Area> ListArea = getVacancy.GetCountry();
            //ListArea.Sort(Area.CompareByName);
            //cbCountry.Items.AddRange(ListArea.ToArray());

            List<Specs> ListSpecs = getVacancy.GetSpecs();
            ListSpecs.Sort(Specs.CompareByName);

            cbSpecs.Items.AddRange(ListSpecs.ToArray());
            btnCheckSpecs.Enabled = true;           
        }


    }
}