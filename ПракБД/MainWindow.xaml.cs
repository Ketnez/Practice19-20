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
using System.Data.Entity;

namespace ПракБД
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ZPEntities4 db = ZPEntities4.GetContext();


        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            db.Table_1.Load();
            DataGrid1.ItemsSource = db.Table_1.Local.ToBindingList();
        }


        private void DataGrid2_Loaded(object sender, RoutedEventArgs e)
        {
            db.Table_3.Load();
            DataGrid2.ItemsSource = db.Table_3.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //add1
        {
            ADD1 f = new ADD1();
            f.ShowDialog();
            DataGrid1.Focus();
        }

        private void ed1_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                Table_1 row = (Table_1)DataGrid1.Items[indexRow];

                Class1.Фамилия = row.Фамилия;
                Class1.Имя = row.Имя;
                Class1.Отчество = row.Отчество;
                Class1.Название_цеха = row.Название_цеха;
                Class1.Дата_поступления_на_работу = row.Дата_поступления_на_работу;

                Edit1 f = new Edit1();
                f.ShowDialog();

                DataGrid1.Items.Refresh();
                DataGrid1.Focus();
            }
        }


        private void Button_Click_5(object sender, RoutedEventArgs e) //delete1
        {
            MessageBoxResult result;
            result = MessageBox.Show("удалить запись?", "удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result== MessageBoxResult.Yes)
            {
                try
                {
                    Table_1 row = (Table_1)DataGrid1.SelectedItems[0];
                    db.Table_1.Remove(row);
                  
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("выберите запись");
                }
                
                  
                
            }
        }











        private void Button_Click_Add(object sender, RoutedEventArgs e) //add2
        {
            ADD2 f = new ADD2();
            f.ShowDialog();
            DataGrid2.Focus();
        }


        private void ed2_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid2.SelectedIndex;
            if (indexRow != -1)
            {
                Table_3 row = (Table_3)DataGrid2.Items[indexRow];

                Class2.Размер_зп = row.Размер_зп;
                Class2.Стаж_работника = row.Стаж_работника;
                Class2.Разряд = row.Разряд;
                Class2.Должность = row.Должность;

                Edit2 f = new Edit2();
                f.ShowDialog();

                DataGrid2.Items.Refresh();
                DataGrid2.Focus();
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) //delete2
        {
            MessageBoxResult result;
            result = MessageBox.Show("удалить запись?", "удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Table_3 row = (Table_3)DataGrid2.SelectedItems[0];
                    db.Table_3.Remove(row);

                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("выберите запись");
                }



            }
        }

    }
}
