using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Water_meter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Counter_water CW;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Chek_hot_water_Checked(object sender, RoutedEventArgs e)
        {

            Chek_not_hot_water.IsChecked = false;
            TB_hot_water.IsEnabled = true;
            old_counter_hot.Text = CW.hot_water.ToString();
            old_counter_hot.Text = CW.hot_water.ToString();
        }

        private void Chek_not_hot_water_Checked(object sender, RoutedEventArgs e)
        {

            Chek_hot_water.IsChecked = false;
            TB_hot_water.IsEnabled = false;
            old_counter_hot.Text = "";
            TB_hot_water.Text = "";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TB_hot_water.IsEnabled = false;
            TB_last_check.IsEnabled = false;
            old_counter_cold.IsEnabled = false;
            old_counter_hot.IsEnabled = false;
            Chek_not_hot_water.IsChecked = true;
           


            DateTime dt = new DateTime(2022, 12, 25);
            var date = dt.ToShortDateString();


            CW = new Counter_water()
            {
                Contry = "China",
                model = "EX-234877",
                serial_number = 7894562588,
                last_check = date.ToString(),
                cold_water = 1077.22,
                hot_water = 782.35,
                new_cold_water = 0,
                new_hot_water = 0
            };
            DataContext = CW;

            TB_New_coldwater.Text = "";
            TB_hot_water.Text = "";
            old_counter_hot.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!TB_hot_water.IsEnabled)
            {
                if (TB_New_coldwater.Text == "")
                    MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (CW.cold_water > CW.new_cold_water)
                    MessageBox.Show("Новые показания счетчика не могут быть меньше предыдущих", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show("Показания успешно переданы", "Новые показания", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            if (TB_hot_water.IsEnabled)
            {
                if (TB_New_coldwater.Text == "" || TB_hot_water.Text == "")
                    MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                else if (CW.cold_water > CW.new_cold_water || CW.hot_water > CW.new_hot_water)
                    MessageBox.Show("Новые показания счетчика не могут быть меньше предыдущих", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                else
                    MessageBox.Show("Показания успешно переданы", "Новые показания", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Chek_hot_water_Unchecked(object sender, RoutedEventArgs e)
        {
            Chek_not_hot_water.IsChecked = true;
        }

        private void Chek_not_hot_water_Unchecked(object sender, RoutedEventArgs e)
        {
            Chek_hot_water.IsChecked = true;
        }

        private void TB_New_coldwater_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }

        private void TB_hot_water_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }
    }
}
