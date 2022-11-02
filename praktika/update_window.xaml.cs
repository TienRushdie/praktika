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
    /// Логика взаимодействия для update_window.xaml
    /// </summary>
    public partial class update_window : Window
    { int b;
        private Repairers _repairers;
        public update_window(object selectedItem)
        {
            InitializeComponent();
            _repairers = selectedItem as Repairers;
            FillTextBoxes();
        }

        private void FillTextBoxes()
        {
           
                T2.Text = _repairers.tab_n.ToString();
                T3.Text = _repairers.FIO;
                T4.Text = _repairers.experience.ToString();
                T6.Text = _repairers.Phone_number.ToString();
           
                
           
        }

        private void C_upd_b_Click(object sender, RoutedEventArgs e)
        {
            
            bool isnum1 = Int32.TryParse(T2.Text, out b);
            bool isnum2 = Int32.TryParse(T4.Text, out b);
            bool isnum3 = Int32.TryParse(T6.Text, out b);
            if (isnum1 && isnum2 && isnum3)
            {
                using (MachineModel db = new MachineModel())
                {
                    Repairers r = new Repairers();
                    r = db.Repairers.Find(int.Parse(T2.Text));
                    if (r != null)
                    {
                        r.tab_n = int.Parse(T2.Text);
                        r.FIO = T3.Text;
                        r.experience = int.Parse(T4.Text);
                        r.Phone_number = int.Parse(T6.Text);

                        db.SaveChanges();
                    } }
            }
            else { MessageBox.Show("Ошибка ввода"); }
            
            this.Close();

            }
        }
    }

