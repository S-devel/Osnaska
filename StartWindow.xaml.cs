using Osnaska.Model;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Osnaska
{

    public partial class StartWindow : Window
    {
      
        public StartWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
           
            DataContext = this;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Window window = Window.GetWindow(this);
                window?.DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            // проверкa пользователя
            User currentUser = AuthenticateUser(username, password);

            if (currentUser != null)
            {
                MainWindow mainWindow = new MainWindow(currentUser);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private User AuthenticateUser(string username, string password)
        {
            if (username == "Сергей" && password == "пароль") 
            {
                return new User { Id = 1, Username = username, Role = "Creator" };
            }
            return null;
        }
    }
}