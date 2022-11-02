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
    /// Логика взаимодействия для storage_add.xaml
    /// </summary>
    public partial class storage_add : Window
    {
        public storage_add()
        {
            InitializeComponent();
        }

        private void S_add_b_Click(object sender, RoutedEventArgs e)
        {
            int b;
            bool isnum1 = Int32.TryParse(T1.Text, out b);
            bool isnum2 = Int32.TryParse(T3.Text, out b);
            
            if (isnum1 && isnum2)
            {
                using (MachineModel db = new MachineModel())
                {

                    Storage s = new Storage();

                    s.Storage_n = int.Parse(T1.Text);
                    s.Address = T2.Text;
                    s.Square = int.Parse(T3.Text);

                    db.Storage.Add(s);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Ошибка ввода"); }
            
            this.Close();
        }
    }
}
