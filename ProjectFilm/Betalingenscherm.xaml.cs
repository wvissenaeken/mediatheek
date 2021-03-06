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
    /// Interaction logic for Betalingenscherm.xaml
    /// </summary>
    public partial class Betalingenscherm : Window
    {
        private decimal totaalprijs;

        public Betalingenscherm()
        {
            InitializeComponent();
        }

        public Betalingenscherm(decimal totaalprijs)
        {
            this.totaalprijs = totaalprijs;
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCash_Click(object sender, RoutedEventArgs e)
        {
            Cashscherm cashverwijzing = new Cashscherm(/*totaalprijs*/);
            cashverwijzing.ShowDialog();
        }

        private void btnBancontact_Click(object sender, RoutedEventArgs e)
        {
            Bancontactscherm bancontactverwijzing = new Bancontactscherm(/*totaalprijs*/);
            bancontactverwijzing.ShowDialog();
        }
    }
}
