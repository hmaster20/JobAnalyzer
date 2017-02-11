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

        // Получить список регионов
        private void btnRefreshRegion_Click(object sender, EventArgs e)
        {
            btnRefreshRegion.Enabled = false;
            ars = getVacancy.GetRegions();
            TreeViewDeveloper(ars);
            btnRefreshRegion.Enabled = true;
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


        // Выбор страны
        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Area _country = new Area();
            if (cbCountry.SelectedItem is Area)
            {
                _country = (Area)cbCountry.SelectedItem;
            }

            if (_country != null)
            {
                if (!DicQuery.ContainsKey("country"))
                {
                    DicQuery.Add("country", new List<string>());
                }

                string strana = "&area=" + _country.id;

                if (!DicQuery["country"].Contains(strana))
                {
                    DicQuery["country"].Add(strana);
                }
            }
        }



        // Выбор региона
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            checkArea(e.Node.Text);

            //Areas _regionA = Areas.Find(ars, e.Node.Text);
            //if (_regionA != null)
            //{
            //    string region = "&area=" + _regionA.id;

            //    // если нет родителя (parent_id), значит это страна
            //    if (_regionA.parent_id == null)     
            //    {
            //        if (!DicQuery["country"].Contains(region))   // если &area=113 не существует, то добавить
            //        {
            //            DicQuery["country"].Add(region);
            //        }
            //        return;
            //    }

            //    // если родитель есть, то ищем его в списке и удаляем
            //    string _country = "&area=" + _regionA.parent_id;
            //    if (DicQuery["country"].Contains(_country))
            //    {
            //        DicQuery["country"].Remove(_country);
            //    }


            //    //проверить есть ли сам объект в списке
            //    // у него есть родители, и у родителей есть родители, то всех удалить.

            //    foreach (string _id in DicQuery["country"])
            //    {
            //        string _id_number_ = _id.Substring(_id.LastIndexOf('=') + 1);   // 113

            //        Areas _id_object_ = Areas.Find(ars, _id_number_);

            //        string parent = "&area=" + _id_object_.parent_id;

            //        if (DicQuery["country"].Contains(parent))       // если указана населенный пункт, то удаляем регион, в котором он находиться.
            //        {
            //            DicQuery["country"].Remove(parent);
            //        }
            //    }

            //    if (!DicQuery["country"].Contains(region))
            //    {
            //        DicQuery["country"].Add(region);
            //    }
            //}
        }


        void checkArea(string _id)
        {
            string _id_number_ = _id.Substring(_id.LastIndexOf('=') + 1);   // 113
            Areas _id_obj = Areas.Find(ars, _id_number_);
            if (_id_obj.parent_id == null)
            {
                DicQuery["country"].Remove(_id_number_);
            }
            else
            {
                // если родитель есть - удаляем, запускаем новую итерацию
                DicQuery["country"].Remove(_id_number_);
                string parent = "&area=" + _id_obj.parent_id;
                checkArea(parent);
            }
        }



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

        private void btnReset_Click(object sender, EventArgs e)
        {
            DicQuery.Clear();
            tbTextForQuery.Text = "";
            tbQuery.Text = "";
        }
    }
}
