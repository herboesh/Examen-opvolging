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

namespace Opvolging
{
    /// <summary>
    /// Interaction logic for ToevoegenTest.xaml
    /// </summary>
    public partial class ToevoegenTest : Window
    {
        List<string> Klassen = new List<string>();
        List<Klas> TempList;
        List<string> Vakken = new List<string>();
        List<Vak> TempList1;
        public ToevoegenTest()
        {
            InitializeComponent();
            using (Repos rep = new Repos())
            {
                TempList = rep.Klassen();
                foreach (Klas k in TempList)
                {
                    Klassen.Add(k.Naam);
                }
            }
            Cbt.ItemsSource = Klassen;
           
        }   
        private void Cbt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Repos rep = new Repos())
            {
                TempList1 = rep.Vakjes(TempList[Cbt.SelectedIndex]); 
                foreach ( Vak v in TempList1)
                {
                    Vakken.Add(v.Naam);
                }
            }
            Cbt2.ItemsSource = Vakken;
        }

        private void VolgendeK_Click_1(object sender, RoutedEventArgs e)
        {
            using (Repos rep = new Repos())
            { // geen savechanges 
                rep.ToevoegenTV(new Test() { TestNaam = Testnaam.Text }, (TempList1[Cbt2.SelectedIndex]));
            }

            MessageBox.Show("Test toegevoegd.");
        }

        private void TerugkerenK_Click(object sender, RoutedEventArgs e)
        {
            { this.Close(); }
        }
    }
}
