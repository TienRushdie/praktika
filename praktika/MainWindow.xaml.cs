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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MachineModel m = new MachineModel();
            //var query =
            //   from Repairers in m.Repairers
            //   select new
            //   {
            //       Repairers.id,
            //       Repairers.tab_n,
            //       Repairers.FIO,
            //       Repairers.experience,
            //       Repairers.Phone_number
            //   };

            RepairersTable.ItemsSource = MachineModel.GetContext().Repairers.ToList();
            //var q =
            //   from Storage in m.Storage
            //   select new
            //   {
            //       Storage.Id,
            //       Storage.Storage_n,
            //       Storage.Address,
            //       Storage.Square,

            //   };

            StorageTable.ItemsSource = MachineModel.GetContext().Storage.ToList();
        }

        private void W_add_b_Click(object sender, RoutedEventArgs e)
        {
            Add_window a = new Add_window();
            a.Show();
        }

        private void W_upd_b_Click(object sender, RoutedEventArgs e)
        {if (RepairersTable.SelectedItem != null)
            {
                update_window w = new update_window(RepairersTable.SelectedItem);
                w.Show();
            }
            else { MessageBox.Show("Выберите строку"); }
            }

            private void Update_data_b_r_Click(object sender, RoutedEventArgs e)
        {
            MachineModel m = new MachineModel();
            RepairersTable.ItemsSource = MachineModel.GetContext().Repairers.ToList();
         
        }

        private void R_del_b_Click(object sender, RoutedEventArgs e)
        {
            DeleteRepairer d = new DeleteRepairer();
            d.Show();
            
        }

        private void Update_data_b_s_Click(object sender, RoutedEventArgs e)
        {
            MachineModel m = new MachineModel();
            StorageTable.ItemsSource = MachineModel.GetContext().Storage.ToList();

  
        }

        private void S_upd_b_Click(object sender, RoutedEventArgs e)
        {
            if (StorageTable.SelectedItem == null) { MessageBox.Show("Выберите строку"); }
            else
            {
                update_storage u = new update_storage(StorageTable.SelectedItem);
                u.Show();
            }
        }

        private void S_add_b_Click(object sender, RoutedEventArgs e)
        {
            storage_add s = new storage_add();
            s.Show();
        }

        private void S_del_b_Click(object sender, RoutedEventArgs e)
        {
            del_storage u = new del_storage();
            u.Show();
        }

        private void R_export_b_Click(object sender, RoutedEventArgs e)
        {
            List<Repairers> repairers;
            List<Storage> storages;
            using (MachineModel usersEntities = new MachineModel())
            {
                repairers = usersEntities.Repairers.ToList().OrderBy(s => s.FIO).ToList();
                storages = usersEntities.Storage.ToList().OrderBy(g => g.Storage_n).ToList();
                var app = new Word.Application();
                Word.Document document = app.Documents.Add();
                
                    Word.Paragraph paragraph =
                    document.Paragraphs.Add();
                    Word.Range range = paragraph.Range;
                    range.Text = Convert.ToString(repairers.FirstOrDefault().FIO);
                    paragraph.set_Style("Заголовок 1");
                    range.InsertParagraphAfter();
                    Word.Paragraph tableParagraph = document.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;
                    Word.Table studentsTable =
                    document.Tables.Add(tableRange, repairers.Count() + 1, 5);
                    studentsTable.Borders.InsideLineStyle =
                    studentsTable.Borders.OutsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                    studentsTable.Range.Cells.VerticalAlignment =
                    Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    Word.Range cellRange;
                    cellRange = studentsTable.Cell(1, 1).Range;
                    cellRange.Text = "ИД";
                    cellRange = studentsTable.Cell(1, 2).Range;
                    cellRange.Text = "Табельный номер";
                    cellRange = studentsTable.Cell(1, 3).Range;
                    cellRange.Text = "ФИО";
                    cellRange = studentsTable.Cell(1, 4).Range;
                    cellRange.Text = "Опыт(лет)";
                    cellRange = studentsTable.Cell(1, 5).Range;
                    cellRange.Text = "Телефон";
                studentsTable.Rows[1].Range.Bold = 1;
                    studentsTable.Rows[1].Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    int i = 1;
                    foreach (var currentrep in repairers)
                    {
                        cellRange = studentsTable.Cell(i + 1, 1).Range;
                        cellRange.Text = currentrep.id.ToString();
                        cellRange.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = studentsTable.Cell(i + 1, 2).Range;
                        cellRange.Text = currentrep.tab_n.ToString();
                        cellRange.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = studentsTable.Cell(i + 1, 3).Range;
                        cellRange.Text = currentrep.FIO.ToString();
                       cellRange.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = studentsTable.Cell(i + 1, 4).Range;
                        cellRange.Text = currentrep.experience.ToString();
                        cellRange.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        cellRange = studentsTable.Cell(i + 1, 5).Range;
                        cellRange.Text = currentrep.Phone_number.ToString();
                        cellRange.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    i++;
                    }
                    Word.Paragraph countStudentsParagraph = document.Paragraphs.Add();
                    Word.Range countStudentsRange =
                    countStudentsParagraph.Range;
                    countStudentsRange.Text = $"Количество ремонтников -{ repairers.Count()}";
                    countStudentsRange.Font.Color = Word.WdColor.wdColorDarkRed;
                    countStudentsRange.InsertParagraphAfter();
                    document.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
                
                app.Visible = true;
                document.SaveAs2(@"D:\outputFileWord.docx");
                document.SaveAs2(@"D:\outputFilePdf.pdf",
                Word.WdExportFormat.wdExportFormatPDF);

            }

            }
        }
    }

