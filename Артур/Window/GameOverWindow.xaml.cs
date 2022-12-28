using System;
using System.Windows;
using System.Windows.Threading;

namespace Артур
{
    /// <summary>
    /// Логика взаимодействия для GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        public GameOverWindow()
        {
            InitializeComponent();
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                this.Close();
            };
        }
    }
}
