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
    /// Логика взаимодействия для DeleteRepairer.xaml
    /// </summary>
    public partial class DeleteRepairer : Window
    {
        public DeleteRepairer()
        {
            InitializeComponent();
        }

        private void C_upd_b_Click(object sender, RoutedEventArgs e)
        {
            MachineModel machineModel = new MachineModel();
            Repairers r = new Repairers();
            int b;
            bool isnum1 = Int32.TryParse(T1.Text, out b);
            if (isnum1)
            {
                r = machineModel.Repairers.Find(int.Parse(T1.Text));
                if (r != null)
                {
                    machineModel.Repairers.Remove(r);

                    machineModel.SaveChanges();
                }
                else { MessageBox.Show("Несуществующий работник"); }
            }
            else { MessageBox.Show("Ошибка ввода"); }
            this.Close();
        }
    }
}
