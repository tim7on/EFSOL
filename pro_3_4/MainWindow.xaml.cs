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
/*Задание 4 
Создайте приложение WPF Application, позволяющее пользователям сохранять данные в 
изолированное хранилище. 
Для выполнения этого задания необходимо наличие библиотеки Xceed.Wpf.Toolkit.dll. Ее 
можно получить через References -> Manage NuGet Packages… -> в поиске написать Extended 
WPF Toolkit (помимо интересующей нас библиотеки будут установлены и другие), или же 
скачать непосредственно на сайте http://wpftoolkit.codeplex.com/ и подключить в проект только 
интересующую нас бибилиотеку (References -> Add Reference …). 
1. Разместите в окне Label и Button. 
2. Разместите в окне ColorPicker (данный инструмент предоставляется вышеуказанной 
библиотекой). Для этого необходимо в XAML коде в теге Window подключить пространство 
имен xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit" . Также, нам понадобиться событие 
Loaded окна. 
3. Реализуйте, чтобы при выборе цвета из ColorPicker в Label выводилось название 
выбранного цвета и в этот цвет закрашивался фон Label. По нажатию на кнопку, данные о 
цвете сохраняются в изолированное хранилище. При запуске приложения заново, цвет фона 
Label остается таким, каким был сохранен при предыдущих запусках приложения.*/
namespace pro_3_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    { 
        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
    {
       // TextBox.Text = "#" + ClrPcker_Background.SelectedColor.R.ToString() + ClrPcker_Background.SelectedColor.G.ToString() + ClrPcker_Background.SelectedColor.B.ToString();
    }
    
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
