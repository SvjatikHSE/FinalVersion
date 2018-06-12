using MLG;
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

namespace Game_UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        DBRepository repository;
        public MainWindow()
        {
            repository = new DBRepository();
                //скачиваю файл номер два
                Information information = new Information();
                information.DownloadInfo("https://db.chgk.info/xml/random", "TestFile3.xml");
                Package package = new Package();
            package.LoadData("C:/Users/mir.shn/source/repos/FinalVersionn/Game_UI/TestFile.xml", 1);
            InitializeComponent();
        }

        private void NavigationWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
