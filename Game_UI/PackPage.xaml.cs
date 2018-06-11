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
    /// Логика взаимодействия для QuestionPage.xaml
    /// </summary>
    public partial class PackPage : Page
    {
        private User _user;
        public PackPage(User user)
        {
            InitializeComponent();
            _user = user;
            var testrepo = new DBRepository();
            testrepo.LoadData();
            UILogic.AdaptPacksForUser(user, testrepo.Packages);
            PackList.ItemsSource = testrepo.Packages;
            PointsList.ItemsSource = testrepo.Packages;
            CheckBoxList.ItemsSource = testrepo.Packages;
            

        }
        List<CheckBox> CreateChBs(List<Package> packs)
        {
            var listOfChb = new List<CheckBox>();
            foreach (var p in packs)
            {
                var checkbox = new CheckBox();
                checkbox.IsChecked = p.IsAlreadyPlayed;
                listOfChb.Add(checkbox);
            }
            return listOfChb;
        }
    }
}
