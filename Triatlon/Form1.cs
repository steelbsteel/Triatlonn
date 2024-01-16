using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Triatlon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string GetTime(double swim, double bycicle, double run)
        {
            if (swim <= 0 || String.IsNullOrEmpty(Convert.ToString(swim)) ||
                bycicle <= 0 || String.IsNullOrEmpty(Convert.ToString(bycicle)) ||
                run <= 0 || String.IsNullOrEmpty(Convert.ToString(run)))
            {
                return ("Ошибка");
            }

            double time = 1500 / swim + 40 / bycicle * 60 + 10 / run * 60;
            return Convert.ToString(time);
        }
        private void BtnGetTime_Click(object sender, EventArgs e)
        {
            try
            {
                FPTime.Text = GetTime(double.Parse(FPSwim.Text), double.Parse(FPBycicle.Text), double.Parse(FPRun.Text));
                SPTime.Text = GetTime(double.Parse(SPSwim.Text), double.Parse(sPBycicle.Text), double.Parse(SPRun.Text));
                TPTime.Text = GetTime(double.Parse(TPSwim.Text), double.Parse(TPBycicle.Text), double.Parse(TPRun.Text));
            }
            catch
            {
                FPTime.Text = "Ошибка";
                SPTime.Text = "заполнения";
                TPTime.Text = "данных";
            }
        }

        private void BtnGetWinner_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(FPTime.Text) ||
               String.IsNullOrEmpty(SPTime.Text) ||
               String.IsNullOrEmpty(TPTime.Text))
            {
                WinnerTB.Text = "Сначала вычислите время";
                return;
            }

            if (FPTime.Text == "Ошибка" ||
                FPTime.Text == "Ошибка" ||
                FPTime.Text == "Ошибка")
            {
                WinnerTB.Text = "Ошибка. Проверьте корректность данных в полях времени.";
                return;
            }

            string max_name;

            MaxAndName(double.Parse(FPTime.Text), double.Parse(SPTime.Text), double.Parse(TPTime.Text),
            "Андрей", "Егор", "Михаил",
            out max_name);

            WinnerTB.Text = max_name;

        }

        void MaxAndName(double x1, double x2, double x3,
            string name1, string name2, string name3,
            out string name_max)
        {
            double min = double.MaxValue; //вводим переменную для максимума с начальным значением MinValue
            name_max = "";
            if (x1 < min)
            {
                min = x1; name_max = name1; //максимум из одного значения и имя 
            }
            if (x2 < min)
            {
                min = x2; name_max = name2; //максимум из двух значений и имя 
            }
            if (x3 < min)
            {
                name_max = name3; //максимум из трех значений и имя 
            }
        }

    }
}
