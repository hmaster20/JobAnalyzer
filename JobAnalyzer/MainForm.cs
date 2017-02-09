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

        public MainForm()
        {
            InitializeComponent();

            getVacancy = new Handler();

            _vacancyCollection = new VacancyCollection();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //string vac = "19291539";
            //getVacancy.GetVacancy(vac);

            getVacancy.FindVacancy("C%23");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lbKeys.Items.Add(tbKey.Text);

        }

        private void lbKeys_DoubleClick(object sender, EventArgs e)
        {
            lbKeys.Items.Remove(lbKeys.SelectedItem);
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshCountry_Click(object sender, EventArgs e)
        {
            btnRefreshCountry.Enabled = false;
            cbCountry.Items.AddRange(getVacancy.GetCountry().ToArray());
            btnRefreshCountry.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Area info = new Area();
            if (cbCountry.SelectedItem is Area)
            {
                info = (Area)cbCountry.SelectedItem;
            }  
            MessageBox.Show(info.id.ToString());
        }

        private void btnGetArr_Click(object sender, EventArgs e)
        {
            getVacancy.GetArrr();
        }
    }

    


}

namespace tester
{
    public class Area
    {
        public string parent_id { get; set; }
        public List<object> areas { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class RootObject
    {
        public object parent_id { get; set; }
        public List<Area> areas { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }
}