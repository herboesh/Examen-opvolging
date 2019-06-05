using OpvolgingLib;
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
using System.Windows.Threading;

namespace Opvolging
{

    public partial class OpvragenResultaat : Window
    {
        List<Resultaat> Result;
        List<Test> Testnaam;
        public OpvragenResultaat()
        {
            InitializeComponent();
            using (Repos rep = new Repos())
            {
                Result = rep.VindResultaten();
                //Testnaam = rep.VindTest();
                GridLNR.ItemsSource = Result;

            }
        }
        // niet gelukt om grid te vullen met testnaam en leerling naam.


        private void TkLN_Click(object sender, RoutedEventArgs e)
        {
            { this.Close(); }
        }

        //geprobeerd met combobox maar ook niet gelukt.
        private void CbO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
