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
    public partial class Form1 : Form
    {
        Handler getVacancy;
        VacancyCollection _vacancyCollection;

        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(VacancyCollection.BaseName))     // Если база создана, то выполняем
            {
                   _vacancyCollection = VacancyCollection.Load();
                
              if ( _vacancyCollection.VacancyList.Count > 0) RefreshTable();
            }
        }

        private void RefreshTable()    // Обновление таблицы путем фильтрации элементов по полю Path
        { 

            List<Items> filtered = _vacancyCollection.VacancyList;

            dgvTable.DataSource = null;
            dgvTable.DataSource = filtered;
        }
    }
}
