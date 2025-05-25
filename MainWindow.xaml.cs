using Osnaska.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Osnaska
{
    public partial class MainWindow : Window
    {
        private bool isSpecialUser = false;
        private DispatcherTimer timer;
        private User _currentUser;
        public MainWindow(User currentUser)
        {

            InitializeComponent();
            _currentUser = currentUser;

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            btnConditional.Visibility = isSpecialUser ? Visibility.Visible : Visibility.Collapsed;

            txtTime.Text = DateTime.Now.ToString("HH:mm");
            StartTimer();
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void btnAlwaysVisible_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnConditional_Click(object sender, RoutedEventArgs e)
        {
            ShowMessage("Действие не выполнено, доступ запрещен.");
        }

        private void ShowMessage(string message)
        {
            txtMessage.Text = message; 
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
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
    }
}