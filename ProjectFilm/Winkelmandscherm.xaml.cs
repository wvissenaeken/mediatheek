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
    /// Interaction logic for Winkelmandscherm.xaml
    /// </summary>
    public partial class Winkelmandscherm : Window
    {
        public Winkelmandscherm()
        {
            InitializeComponent();
        }

        private void Annuleren_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBetalen_Click(object sender, RoutedEventArgs e)
        {
            Betalingenscherm betaal = new Betalingenscherm();
            betaal.ShowDialog();
        }
    }
}
