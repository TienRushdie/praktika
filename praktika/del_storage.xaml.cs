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
    /// Логика взаимодействия для del_storage.xaml
    /// </summary>
    public partial class del_storage : Window
    {
        public del_storage()
        {
            InitializeComponent();
        }

        private void S_del_b_Click(object sender, RoutedEventArgs e)
        {
            MachineModel machineModel = new MachineModel();
            Storage s = new Storage();
            int b;
            bool isnum1 = Int32.TryParse(T1.Text, out b);
            if (isnum1)
            {
                s = machineModel.Storage.Find(int.Parse(T1.Text));
                if (s != null)
                {
                    machineModel.Storage.Remove(s);

                    machineModel.SaveChanges();
                }
                else { MessageBox.Show("Несуществующий cклад"); }
            }
            else { MessageBox.Show("Ошибка ввода"); }
            
            this.Close();
        }
    }
}
