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
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        public static List<программный_продукт> программный_Продуктs { get; set; }
        public TablePage()
        {
            InitializeComponent();
            программный_Продуктs = prodyktEntities.GetContext().программный_продукт.ToList();
            DataContext = программный_Продуктs;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridGood.ItemsSource = null;
            prodyktEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            List<программный_продукт> goods = prodyktEntities.GetContext().программный_продукт.OrderBy(p => p.название_продукта).ToList();
            DataGridGood.ItemsSource = goods;
        }

        private void GoodsInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GoodsInfoPage((программный_продукт) (sender as Button).DataContext));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var product = DataGridGood.SelectedItems.Cast<программный_продукт>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {product.Count()}записей ??? ", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    программный_продукт x = product[0];
                    var complects = prodyktEntities.GetContext().программный_продукт.Where(p => p.код_продукта == x.код_продукта).ToList();
                    prodyktEntities.GetContext().программный_продукт.RemoveRange(complects);
                    prodyktEntities.GetContext().программный_продукт.Remove(x);
                    prodyktEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<программный_продукт> goods = prodyktEntities.GetContext().программный_продукт.OrderBy(p =>
                    p.название_продукта).ToList();
                    DataGridGood.ItemsSource = null;
                    DataGridGood.ItemsSource = goods;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GoodsInfoPage(null));
        }

        private void DataGridGood_LoadingRow_1(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
