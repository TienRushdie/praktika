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
    /// Логика взаимодействия для update_storage.xaml
    /// </summary>
    public partial class update_storage : Window
    {
        private Storage _storage;
        public update_storage(object selectedItem)
        {
                InitializeComponent();
                _storage = selectedItem as Storage;
                FillTextBoxes();
            
        }
        private void FillTextBoxes()
        {
            
                T1.Text = _storage.Id.ToString();
                T2.Text = _storage.Storage_n.ToString();
                T3.Text = _storage.Address.ToString();
                T4.Text = _storage.Square.ToString();
            
            
        }

        private void C_upd_b_Click(object sender, RoutedEventArgs e)
        {
            int b;
            bool isnum1 = Int32.TryParse(T2.Text, out b);
            bool isnum2 = Int32.TryParse(T4.Text, out b);
           
            if (isnum1 && isnum2)
            {
                
            
            using (MachineModel db = new MachineModel())
            {
                Storage s = new Storage();
                s = db.Storage.Find();
                if (s != null)
                {
                    s.Storage_n = int.Parse(T2.Text);
                    s.Address = T3.Text;
                    s.Square = int.Parse(T4.Text);
                    

                    db.SaveChanges();
                }
            }
            }
            else { MessageBox.Show("Ошибка ввода"); }

            this.Close();
        }
    }
}
