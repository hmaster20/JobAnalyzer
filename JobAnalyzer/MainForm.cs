using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JobAnalyzer
{
    public partial class MainForm : Form
    {
        Handler getVacancy;
        VacancyCollection _vacancyCollection;
        Areas ars;

        Dictionary<string, List<string>> DicQuery;

        public MainForm()
        {
            InitializeComponent();

            getVacancy = new Handler();

            _vacancyCollection = new VacancyCollection();
            ars = new Areas();
            DicQuery = new Dictionary<string, List<string>>();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //string vac = "19291539";
            //getVacancy.GetVacancy(vac);

            getVacancy.FindAllVacancies("C%23");
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
            cbCountry.Items.AddRange(getVacancy.GetCountry().ToArray());    // List<Area> 
            btnRefreshCountry.Enabled = true;
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
                        if (_regionA.parent_id == null) // если нет родителя (parent_id), значит это страна
                        {
                            if (!DicQuery["country"].Contains(region))   // если &area=113 не существует, то добавить
                            {
                                deleteParent(region);
                                deleteChild(region);
                                DicQuery["country"].Add(region);
                                return;
                            }
                        } // есть родитель, запуск поиска
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
                // 1. проверка наличия дубликатов в словаре
                //if (DicQuery["country"].Contains(node))
                //{
                //    return;
                //}
                // 2. проверка наличие родителей в словаре
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

           // List<string> ss = new List<string>();

            string[] arr = new string[] { };

            DicQuery["country"].CopyTo(arr);


            // for (int i = 0; i < DicQuery["country"].Count; i++)
            for (int i = 0; i < arr.Count(); i++)
            {
                string count = arr[i];
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
            }
        }














        //void checkArea2(string _id)
        //{
        //    try
        //    {
        //        string _id_number_ = _id.Substring(_id.LastIndexOf('=') + 1);   // 113
        //        Areas _id_obj = Areas.FindbyID(ars, _id_number_);
        //        if (_id_obj != null)    //если есть объект
        //        {
        //            if (!DicQuery["country"].Contains(_id))
        //            {
        //                // если родитель есть - удаляем, запускаем новую итерацию
        //                DicQuery["country"].Remove(_id);
        //            }

        //            string parent = "&area=" + _id_obj.parent_id;
        //            checkArea2(parent);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}







        // проверка строки запроса
        private void btnCheckTextQuery_Click(object sender, EventArgs e)
        {
            tbQuery.Text = "";
            tbQuery.Text += ("?text=" + tbTextForQuery.Text);

            if (DicQuery != null && DicQuery.Keys.Count > 0)
            {
                foreach (var _key in DicQuery.Keys)
                {
                    if (DicQuery[_key].Count > 0)
                    {
                        foreach (var _listElement in DicQuery[_key])
                        {
                            tbQuery.Text += _listElement;
                        }
                    }

                }
            }
        }

        // сброс
        private void btnReset_Click(object sender, EventArgs e)
        {
            DicQuery.Clear();
            tbTextForQuery.Text = "";
            tbQuery.Text = "";
        }


    }
}



//void checkArea(string _id)
//{
//    try
//    {
//        string _id_number_ = _id.Substring(_id.LastIndexOf('=') + 1);   // 113
//        Areas _id_obj = Areas.Find(ars, _id_number_);
//        if (_id_obj.parent_id == null)
//        {
//            DicQuery["country"].Remove(_id_number_);
//        }
//        else
//        {
//            // если родитель есть - удаляем, запускаем новую итерацию
//            DicQuery["country"].Remove(_id_number_);
//            string parent = "&area=" + _id_obj.parent_id;
//            checkArea(parent);
//        }
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show(ex.Message);
//    }
//}



// выбираем страну и добавляем в словарь
//private void SelectAndAddCountry()
//{
//    Area _country = new Area();
//    if (cbCountry.SelectedItem is Area)
//    {
//        _country = (Area)cbCountry.SelectedItem;
//    }

//    if (_country != null)
//    {
//        if (!DicQuery.ContainsKey("country"))
//        {
//            DicQuery.Add("country", new List<string>());
//        }

//        string strana = "&area=" + _country.id;

//        if (!DicQuery["country"].Contains(strana))
//        {
//            DicQuery["country"].Add(strana);
//        }
//    }
//}