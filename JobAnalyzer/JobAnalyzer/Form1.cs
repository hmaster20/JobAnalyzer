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
        hh_vacancies yt;

        public Form1()
        {
            InitializeComponent();

            yt = new hh_vacancies();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yt.Translate("1", "2");
        }
    }
}
