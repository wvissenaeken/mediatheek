﻿using System;
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

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for BetalingenOKscherm.xaml
    /// </summary>
    public partial class BetalingenOKscherm : Window
    {
        public BetalingenOKscherm()
        {
            InitializeComponent();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            SluitAlleOpenVensters();
            MainWindow mainwindow = new MainWindow();
            mainwindow.ShowDialog();
        }

        //Sluit alle open vensters behalve Mainwindow (zit op App.Current.Windows[0])
        private void SluitAlleOpenVensters()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
                App.Current.Windows[intCounter].Hide();
        }
    }
}
