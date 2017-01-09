﻿using ProjectFilmLibrary;
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

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for LeesKaartData.xaml
    /// </summary>
    public partial class LeesKaartData : Window
    {
        public LeesKaartData()
        {
            InitializeComponent();
            leeskaart = new LeesKaart();
        }

        LeesKaart leeskaart;

        private void btn_LeesKaart_Click(object sender, RoutedEventArgs e)
        {
            lblNaam.Content = leeskaart.GetSurname();
            lblVoornaam.Content = leeskaart.GetFirstName();
        }
    }
}
