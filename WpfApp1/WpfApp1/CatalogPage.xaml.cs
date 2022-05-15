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
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        int _itemcount = 0;
        int pageNum = 1;
        public CatalogPage()
        {
            InitializeComponent();
            var goods = prodyktEntities.GetContext().программный_продукт.OrderBy(p => p.название_продукта).ToList();
            goods.Insert(0, new программный_продукт
            {
                название_продукта = "Все"
            });
            LViewGoods.ItemsSource = prodyktEntities.GetContext().программный_продукт.OrderBy(p => p.название_продукта).ToList();
            _itemcount = LViewGoods.Items.Count;
            TextBlockCount.Text = $"Результат запроса: {_itemcount} записей из {_itemcount}";
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                prodyktEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewGoods.ItemsSource = prodyktEntities.GetContext().программный_продукт.OrderBy(p => p.название_продукта).ToList();
            }
        }

        private void Update()
        {
            List<программный_продукт> программный_Продуктs = prodyktEntities.GetContext().программный_продукт.OrderBy(p => p.название_продукта).ToList();
            if (SearchTb.Text.Trim() != "")
            {
                программный_Продуктs = программный_Продуктs
                    .Where(p => p.название_продукта.Trim().ToLower().Contains(SearchTb.Text.Trim().ToLower())).ToList();
            }
            if (GoodsFilterCb.SelectedIndex > 0)
            {
                программный_Продуктs = программный_Продуктs.Where(p => p.код_продукта == (GoodsFilterCb.SelectedItem as программный_продукт).код_продукта).ToList();
            }
            if (GoodsSortCb.SelectedIndex > 0)
            {
                switch (GoodsSortCb.SelectedIndex)
                {
                    case 1:
                        программный_Продуктs = программный_Продуктs.OrderBy(p => p.дата_выпуска).ToList();
                        break;
                    case 2:
                        программный_Продуктs = программный_Продуктs.OrderByDescending(p => p.дата_выпуска).ToList();
                        break;
                }
            }
            try
            {
                bool canParse = int.TryParse(PageCount.Text, out int currentPage);
                List<программный_продукт> pageAgents = new List<программный_продукт>();

                currentPage = currentPage <= 0 || currentPage > программный_Продуктs.Count || !canParse ? 1 : currentPage;

                int itemsPerPage = 10;
                int offset = ((currentPage - 1) * itemsPerPage + 1) - 1;
                for (int i = offset; i < itemsPerPage + offset; i++)
                {
                    if (i < программный_Продуктs.Count)
                    {
                        pageAgents.Add(программный_Продуктs[i]);
                    }
                }
                LViewGoods.ItemsSource = pageAgents;
                LViewGoods.ItemsSource = pageAgents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TablePage());
        }

        private void secondBtn_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = (pageNum+1).ToString();
            Update();
        }

        private void firstBtn_Click(object sender, RoutedEventArgs e)
        {
            PageCount.Text = pageNum.ToString();
            Update();
        }

        private void prevPages_Click(object sender, RoutedEventArgs e)
        {
            List<программный_продукт> patients = prodyktEntities.GetContext().программный_продукт
             .OrderBy(p => p.название_продукта)
             .ToList();
            if (pageNum > 2)
            {
                pageNum -= 2;
                firstBtn.Content = pageNum;
                secondBtn.Content = pageNum + 1;

            }
        }

        private void GoodsFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void GoodsSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void PageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
