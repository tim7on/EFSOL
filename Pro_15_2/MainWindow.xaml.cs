using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
/*Задание 2 
Создайте WPF приложение, разместите в окне TextBox и две кнопки. При нажатии на первую 
кнопку в TextBox выводится сообщение «Подключен к базе данных» при этом в обработчике 
установите задержку в 3-5 сек для имитации подключения к БД, также данная кнопка запускает 
таймер, который с периодичностью в несколько секунд выводит в TextBox сообщение «Данные 
получены». При нажатии на вторую кнопку по аналогии с первой отключаемся от базы (с 
задержкой), выводим сообщение и останавливаем таймер.*/
namespace Pro_15_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            TimeSpan tick = TimeSpan.FromSeconds(2);
            timer.Interval = tick;
            timer.Tick += Timer_counter;
        }

        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            BtnConnect.IsEnabled = false;
            TxtBox.Text += await ConnectAsync();
            BtnDisconnect.IsEnabled = true;
        }
        private async void BtnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            BtnDisconnect.IsEnabled = false;
            TxtBox.Text += await DisconnectAsync();
            BtnConnect.IsEnabled = true;
        }

        private async void Timer_counter(object sender, EventArgs e)
        {
            TxtBox.Text += await GetDataAsync();
            TxtBox.ScrollToEnd();
        }
        private Task<string> GetDataAsync()
        {
            return Task.Run(() => { return "Data received" + Environment.NewLine; });
        }
        private async Task<string> ConnectAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Connected" + Environment.NewLine;
            });
        }
        private async Task<string> DisconnectAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Disconnected" + Environment.NewLine;
            });
        }
    }
}
