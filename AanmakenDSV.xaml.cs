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
    /// Interaction logic for AanmakenDSV.xaml
    /// </summary>
    public partial class AanmakenDSV : Window
    {
        List<string> Leerkrachten = new List<string>();
        List<Leerkracht> TempList;
        List<string> Klassen = new List<string>();
        List<Klas> TempList1;
        public AanmakenDSV()
        {
            InitializeComponent();

            using (Repos rep = new Repos())
            {
                TempList = rep.Leerkrachten();
                foreach (Leerkracht l in TempList)
                {
                    Leerkrachten.Add(l.Naam);
                }
            }
            using (Repos rep = new Repos())
            {
                TempList1 = rep.Klassen();
                foreach (Klas k in TempList1)
                {
                    Klassen.Add(k.Naam);
                }
            }
            CB1.ItemsSource = Leerkrachten;
            CB2.ItemsSource = Leerkrachten;
            CB3.ItemsSource = Leerkrachten;
            CB4.ItemsSource = Leerkrachten;
            CB5.ItemsSource = Leerkrachten;
            CB6.ItemsSource = Leerkrachten;
            CB7.ItemsSource = Klassen;

        }

        private void UitvoerenV_Click(object sender, RoutedEventArgs e)
        {
            using (Repos rep = new Repos())
            { // geen savechanges 
                rep.ToevoegenV(new Vak() { Naam = Vak1.Text, Leerkracht = rep.PakLeerkracht(TempList[CB1.SelectedIndex]) } , (TempList1[CB7.SelectedIndex]));
                rep.ToevoegenV(new Vak() { Naam = Vak2.Text, Leerkracht = rep.PakLeerkracht(TempList[CB2.SelectedIndex]) } , (TempList1[CB7.SelectedIndex]));
                rep.ToevoegenV(new Vak() { Naam = Vak3.Text, Leerkracht = rep.PakLeerkracht(TempList[CB3.SelectedIndex]) } , (TempList1[CB7.SelectedIndex]));
                rep.ToevoegenV(new Vak() { Naam = Vak4.Text, Leerkracht = rep.PakLeerkracht(TempList[CB4.SelectedIndex]) } , (TempList1[CB7.SelectedIndex]));
                rep.ToevoegenV(new Vak() { Naam = Vak5.Text, Leerkracht = rep.PakLeerkracht(TempList[CB5.SelectedIndex]) } , (TempList1[CB7.SelectedIndex]));
                rep.ToevoegenV(new Vak() { Naam = Vak6.Text, Leerkracht = rep.PakLeerkracht(TempList[CB6.SelectedIndex]) } , (TempList1[CB7.SelectedIndex]));
            }

            MessageBox.Show("Vakken toegevoegd.");
        }

        private void TerugkerenV_Click(object sender, RoutedEventArgs e)
        {
            { this.Close(); }
        }

    }
}
