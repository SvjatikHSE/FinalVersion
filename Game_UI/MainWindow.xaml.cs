﻿using MLG;
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
using System.IO;
using System.Reflection;
using System.Media;

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
            var dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var way= System.IO.Path.GetFullPath("TestFile.xml");
            repository = new DBRepository();
          
            //скачиваю файл номер два
            //Information information = new Information();
            //information.DownloadInfo("https://db.chgk.info/xml/random", "TestFile6.xml");
            InitializeComponent();
           

        }


 
    }
}
