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
using System.Data.Entity;

namespace ПракБД
{
    /// <summary>
    /// Логика взаимодействия для ADD1.xaml
    /// </summary>
    public partial class ADD1 : Window
    {
        public ADD1()
        {
            InitializeComponent();
        }

        ZPEntities4 db = ZPEntities4.GetContext();

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

            if (tt5.Text.Length == 0)
            {
                errors.AppendLine("error");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            Table_1 p1 = new Table_1();

            p1.Фамилия = Convert.ToString(tt1.Text);
            p1.Имя = Convert.ToString(tt2.Text);
            p1.Отчество = Convert.ToString(tt3.Text);
            p1.Название_цеха = Convert.ToString(tt4.Text);
            p1.Дата_поступления_на_работу = Convert.ToDateTime(tt5.Text);

            try
            {
                db.Table_1.Add(p1);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
