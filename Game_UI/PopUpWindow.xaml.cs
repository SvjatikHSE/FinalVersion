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
using System.Windows.Shapes;

namespace Game_UI
{
    /// <summary>
    /// Логика взаимодействия для PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window
    {
        public bool gamemode;
        public PopUpWindow()
        {
            InitializeComponent();
          
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            gamemode = false ;
            this.Close();
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            gamemode = true;
            this.Close();
        }
    }
}
