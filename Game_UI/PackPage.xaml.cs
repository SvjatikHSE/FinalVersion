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
        private DBRepository dBRepository;
        public PackPage(User user)
        {
            InitializeComponent();
            _user = user;
            var testrepo = new DBRepository();
            dBRepository = testrepo;
            testrepo.LoadData();
            UILogic.AdaptPacksForUser(user, testrepo.Packages);
            PackList.ItemsSource = testrepo.Packages;
            PointsList.ItemsSource = testrepo.Packages;
            CheckBoxList.ItemsSource = testrepo.Packages;
            

        }
        private void UpdateInfo(List<Package> packages)
        {
            CheckBoxList.ItemsSource = null;
            CheckBoxList.ItemsSource = packages;
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

        private void PackList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var package = PackList.SelectedItem as Package;
            package.IsAlreadyPlayed = true;
            var currSession = UILogic.CreateSession(_user, package);
            UILogic.AdaptPacksForUser(_user, dBRepository.Packages);
            UpdateInfo(dBRepository.Packages);
        }       
    }
}
