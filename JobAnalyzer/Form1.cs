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
        Handler getVacancy;

        public Form1()
        {
            InitializeComponent();

            getVacancy = new Handler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vac = "19291539";
            getVacancy.GetVacancy(vac);
        }
    }
}
