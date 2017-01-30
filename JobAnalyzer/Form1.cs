using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JobAnalyzer
{
    public partial class Form1 : Form
    {
        hh_vacancies hhv;

        public Form1()
        {
            InitializeComponent();

            hhv = new hh_vacancies();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hhv.GetVacancy("1");
        }
    }
}
