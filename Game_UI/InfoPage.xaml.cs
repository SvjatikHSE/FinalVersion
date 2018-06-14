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
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
            InfoTexrBlock.Text = "Добро пожаловать в Game of Brains.\r\nЭто приложение создано для тренировки команд спортивного Что? Где? Когда?\r\nНо если вы с ним не знакомы, не спешите закрывать программу.\r\nИгра подойдет и для пользователей, которые хотят почувствовать себя знатоками \r\nи проверить свои знания\r\n\r\nВ приложении представлены сборники(пакеты) вопросов различных интелектуальных игр:\r\nЧто?Где?Когда?, Своя игра, Брейн-Ринг...\r\nВы можете просматривать их в свободном режиме или запустить игровой.\r\nВо втором случае после чтения вопроса запускается минутный таймер, \r\nпо истечении времени будет доступен ответ и возможность выбрать, был ли дан верный ответ.\r\nПриложение запоминает отыгранные пакеты и ваш последний результат каждого из них.\r\nВ обоих режимах, если в вопросе предлагается изображение, \r\nпоявляется соответствующая кнопка.\r\n\r\nСпасибо, что выбрали Game of Brains.\r\n\r\nУдачной игры!\r\n\r\nКоманда MLG";
        }

     
    }
}
