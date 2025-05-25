using System.Windows.Controls;
using System.Windows;

namespace Osnaska
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : UserControl
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //private void btnAlwaysVisible_Click(object sender, RoutedEventArgs e)
        //{
        //    OrderWindow orderWindow = new OrderWindow();
        //    orderWindow.Show(); // Открываем новое окно
        //}
    }
}