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
    /// Логика взаимодействия для PatientInfoPage.xaml
    /// </summary>
    public partial class GoodsInfoPage : Page
    {
        public программный_продукт Программный_Продукт { get; set; }
        public GoodsInfoPage(программный_продукт dataContext)
        {
            InitializeComponent();


            if (Программный_Продукт != null)
            {
                Программный_Продукт = dataContext;
                TextBoxGoodId.Visibility = Visibility.Hidden;
                TextBlockGoodID.Visibility = Visibility.Hidden;
                List<программный_продукт> additional = prodyktEntities.GetContext().программный_продукт.Where(p =>
                p.код_продукта == Программный_Продукт.код_продукта).ToList();
                List<программный_продукт> patients = new List<программный_продукт>();
            }
            else
            {
                Программный_Продукт = new программный_продукт();
            }
            DataContext = Программный_Продукт;
        }

        public GoodsInfoPage()
        {
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Программный_Продукт.код_продукта == 0)
                {
                    prodyktEntities.GetContext().программный_продукт.Add(Программный_Продукт);
                }
                prodyktEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<программный_продукт> additional = prodyktEntities.GetContext().программный_продукт.Where(p => p.код_продукта == Программный_Продукт.код_продукта).ToList();
            List<программный_продукт> goods = new List<программный_продукт>();
        }
    }
}
