using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для Add_window.xaml
    /// </summary>
    public partial class Add_window : Window
    {
        public Add_window()
        {
            InitializeComponent();
        }

        private void R_add_b_Click(object sender, RoutedEventArgs e)
        {
            int b;
            bool isnum1 = Int32.TryParse(T1.Text, out b);
            bool isnum2 = Int32.TryParse(T3.Text, out b);
            bool isnum3 = Int32.TryParse(T4.Text, out b);
            if (isnum1 && isnum2 && isnum3)
            {
                using (MachineModel db = new MachineModel())
                {
                    Repairers r = new Repairers();
                    r.tab_n = int.Parse(T1.Text);
                    r.FIO = T2.Text;
                    r.experience = int.Parse(T3.Text);
                    r.Phone_number = int.Parse(T4.Text);
                    db.Repairers.Add(r);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Ошибка ввода"); }
            this.Close();
        }
            
    }
}

