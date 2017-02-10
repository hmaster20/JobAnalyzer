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
            ars = getVacancy.GetRegions();
            TreeViewDeveloper(ars);
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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Area info = new Area();
        //    if (cbCountry.SelectedItem is Area)
        //    {
        //        info = (Area)cbCountry.SelectedItem;
        //    }
        //    MessageBox.Show(info.id.ToString());
        //}


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
                //if (DicQuery.ContainsKey("country"))
                //{
                //    DicQuery["country"].Clear();
                //}
                //else
                //{
                //DicQuery.Add("country", new List<string>());
                // }

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
            Areas _regionAreas = Areas.Find(ars, e.Node.Text);
            if (_regionAreas != null)
            {
                string strana = "&area=" + _regionAreas.parent_id;
                string region = "&area=" + _regionAreas.id;

                if (DicQuery["country"].Contains(strana))
                {
                    DicQuery["country"].Remove(strana);
                }

                if (!DicQuery["country"].Contains(region))
                {
                    DicQuery["country"].Add(region);
                }          
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
