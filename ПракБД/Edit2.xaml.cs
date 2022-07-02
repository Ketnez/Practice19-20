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

namespace ПракБД
{
    /// <summary>
    /// Логика взаимодействия для Edit2.xaml
    /// </summary>
    public partial class Edit2 : Window
    {
        public Edit2()
        {
            InitializeComponent();
        }

        ZPEntities4 db = ZPEntities4.GetContext();

        Table_3 p1;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p1 = db.Table_3.Where(p => p.Размер_зп == Class2.Размер_зп).FirstOrDefault();

            tt1.Text = Convert.ToString(p1.Размер_зп);
            tt2.Text = Convert.ToString(p1.Стаж_работника);
            tt3.Text = Convert.ToString(p1.Разряд);
            tt4.Text = Convert.ToString(p1.Должность);
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (tt1.Text.Length == 0)
            {
                errors.AppendLine("error");
            }

            if (tt2.Text.Length == 0)
            {
                errors.AppendLine("error");
            }

            if (tt3.Text.Length == 0)
            {
                errors.AppendLine("error");
            }

            if (tt4.Text.Length == 0)
            {
                errors.AppendLine("error");
            }



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }



            p1.Размер_зп = Convert.ToInt32(tt1.Text);
            p1.Стаж_работника = Convert.ToInt32(tt2.Text);
            p1.Разряд = Convert.ToInt32(tt3.Text);
            p1.Должность = Convert.ToString(tt4.Text);

            try
            {

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
