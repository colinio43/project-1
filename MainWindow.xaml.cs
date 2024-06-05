using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Fietsenwinkel_allerlaatste_poging
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        decimal totaalBetalen = 0;

        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            pbTimer.Value = 100;

            // Start de timer bij het opstarten
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TimerReset();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            TimerReset();
        }

        private void TimerReset()
        {
            // Reset the timer and Progress bar
            timer.Stop();
            timer.Start();
            pbTimer.Value = 100;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (pbTimer.Value > 0)
            {
                pbTimer.Value--;
            }
            else
            {
                // Laat zien als de timer vol zit dat het programma gesloten word
                MessageBox.Show("Je hebt niks gedaan telang");
                Close();
            }
        }

        private void btnRekenmachine_Click(object sender, RoutedEventArgs e)
        {
            //zorgt er voor dat er een nieuwe window wordt geopend
            Rekenmachine mainwWindow = new Rekenmachine();
            mainwWindow.Show();
        }

        private void btnBestellen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*zorgt er voor dat je alleen getallen in mag vullen en niet min getallen in mag vullen
                 alleen als je getallen boven de 1 in vult wordt de code hier onder geactiveerd*/
                int dagen = Convert.ToInt32(txbAantalDagen.Text);
                if (dagen >= 1)
                {
                    string selectedcmbSoort = cmbFiets.Text;
                    string selectedcmbVerzekering = cmbVerzekering.Text;
                    string selectedcmbService = cmbService.Text;

                    if (cmbFiets.SelectedIndex >= 0)
                    {
                        ComboBoxItem fiets = (ComboBoxItem)cmbFiets.SelectedItem;
                        lstVerzameling.Items.Add(fiets.Content.ToString() + " Aantal dagen: " + txbAantalDagen.Text);
                    }

                    if (cmbVerzekering.SelectedIndex >= 0)
                    {
                        ComboBoxItem verzekering = (ComboBoxItem)cmbVerzekering.SelectedItem;
                        lstVerzameling.Items.Add(verzekering.Content.ToString() + " Aantal dagen: " + txbAantalDagen.Text);
                    }

                    if (cmbService.SelectedIndex >= 0)
                    {
                        ComboBoxItem service = (ComboBoxItem)cmbService.SelectedItem;
                        lstVerzameling.Items.Add(service.Content.ToString() + " Aantal dagen: " + txbAantalDagen.Text);
                    }

                    //FIETS
                    if (txbAantalDagen.Text != null)
                    {
                        if (cmbFiets.SelectedIndex != -1)
                        {
                            int index = selectedcmbSoort.IndexOf("€") + 1;
                            int length = selectedcmbSoort.IndexOf(" /") - index;
                            //hiermee kunnen we dadelijk de prijs ophalen\
                            //wat hier gebeurt is eigenlijk; hij kijkt hoeveel characters er voor en na de prijs zitten

                            if (index >= 0)
                            //als die index iets heeft opgehaald dan kan deze dingen gaan uitvoeren
                            {
                                string prijsfiets = selectedcmbSoort.Substring(index, length);
                                //haalt alles weg uit de string van de comboboxitem behalve de prijs van het item

                                string totaalbalans = lbTotaalBedrag.Content.ToString();
                                totaalBetalen = decimal.Parse(totaalbalans);
                                decimal prijsFietsdecimal = decimal.Parse(prijsfiets);


                                if (txbAantalDagen != null)
                                {
                                    if (lbTotaalBedrag.Content == "0")
                                    {
                                        lbTotaalBedrag.Content = "1";
                                    }
                                    prijsFietsdecimal *= Convert.ToInt32(txbAantalDagen.Text);
                                    //de prijs maal het aantal geselcteerde dagen

                                }

                                totaalBetalen += prijsFietsdecimal;
                                lbTotaalBedrag.Content = totaalBetalen.ToString();
                            }
                        }


                    }

                    //VERZEKERING
                    if (txbAantalDagen.Text != null)
                    {
                        if (cmbVerzekering.SelectedIndex != -1)
                        {
                            int index = selectedcmbVerzekering.IndexOf("€") + 1;
                            int length = selectedcmbVerzekering.IndexOf(" /") - index;
                            if (index >= 0)
                            //als die index iets heeft opgehaald dan kan deze dingen gaan uitvoeren
                            {
                                string prijsverzekering = selectedcmbVerzekering.Substring(index, length);
                                //haalt alles weg uit de string van de comboboxitem behalve de prijs van het item

                                string totaalbalans = lbTotaalBedrag.Content.ToString();
                                totaalBetalen = decimal.Parse(totaalbalans);
                                decimal prijsVerzekringdecimal = decimal.Parse(prijsverzekering);


                                if (txbAantalDagen != null)
                                {
                                    if (lbTotaalBedrag.Content == "0")
                                    {
                                        lbTotaalBedrag.Content = "1";
                                    }
                                    prijsVerzekringdecimal *= Convert.ToInt32(txbAantalDagen.Text);
                                    //de prijs maal het aantal geselcteerde dagen
                                }

                                totaalBetalen += prijsVerzekringdecimal;
                                lbTotaalBedrag.Content = totaalBetalen.ToString();
                            }
                        }

                    }

                    //SERVICE
                    if (txbAantalDagen.Text != null)
                    {
                        if (cmbService.SelectedIndex != -1)
                        {
                            int index = selectedcmbService.IndexOf("€") + 1;
                            int length = selectedcmbService.IndexOf(" /") - index;
                            //hiermee kunnen we dadelijk de prijs ophalen\
                            //wat hier gebeurt is eigenlijk; hij kijkt hoeveel characters er voor en na de prijs zitten

                            if (index >= 0)
                            //als die index iets heeft opgehaald dan kan deze dingen gaan uitvoeren
                            {
                                string prijsService = selectedcmbService.Substring(index, length);
                                //haalt alles weg uit de string van de comboboxitem behalve de prijs van het item

                                string totaalbalans = lbTotaalBedrag.Content.ToString();
                                totaalBetalen = decimal.Parse(totaalbalans);
                                decimal prijsServicedecimal = decimal.Parse(prijsService);

                                if (txbAantalDagen != null)
                                {
                                    if (lbTotaalBedrag.Content == "0")
                                    {
                                        lbTotaalBedrag.Content = "1";
                                    }
                                    prijsServicedecimal *= Convert.ToInt32(txbAantalDagen.Text);
                                    //de prijs maal het aantal geselcteerde dagen

                                }

                                //zorgt er voor dat de prijs in de listbox komt te staan
                                
                                totaalBetalen += prijsServicedecimal;
                                lbTotaalBedrag.Content = totaalBetalen.ToString();
                            }
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("vul een geldig aantal dagen in wat boven de 0 is");
                }
            }
            catch 
            {
                MessageBox.Show("Vul cijfers in en geen letters");
            }

            
        }

        private void btnAfrekenen_Click(object sender, RoutedEventArgs e)
        {
            // de decimal zorgt er voor dat je een getal met een comma getal kan gebruiken
            decimal betaling = Convert.ToDecimal(lbTotaalBedrag.Content);
            if (betaling == 0)
            {
                MessageBox.Show("Je hebt nog niks besteld, bestel iets voordat je door gaat");
            }
            else
            {
                MessageBoxResult Antwoord = MessageBox.Show("Wil je afrekenen?", "Betaling", MessageBoxButton.YesNo);
               
                if (Antwoord == MessageBoxResult.Yes)
                {
                    //zorgt er voor dat alles wordt leeg gehaald en een bericht krijgt dat je hebt betaald
                    MessageBox.Show("U hebt betaald.");
                    txtVoornaam.Text = "";
                    txtTussenvoegsel.Text = "";
                    txtAchternaam.Text = "";
                    txbAantalDagen.Text = "";
                    lstVerzameling.Items.Clear();
                    cmbFiets.SelectedIndex = -1;
                    cmbVerzekering.SelectedIndex = -1;
                    cmbService.SelectedIndex = -1;
                    lbTotaalBedrag.Content = "0";
                    totaalBetalen = 0;
                }
                else
                {
                    MessageBox.Show("Kom terug als je klaar bent");
                }
            }
        }

        private void btnVolgendeKlant_Click(object sender, RoutedEventArgs e)
        {
            //zorgt er voor dat alles wordt leeg gehaald
            txtVoornaam.Text = "";
            txtTussenvoegsel.Text = "";
            txtAchternaam.Text = "";
            txbAantalDagen.Text = "";
            lstVerzameling.Items.Clear();
            cmbFiets.SelectedIndex = -1;
            cmbVerzekering.SelectedIndex = -1;
            cmbService.SelectedIndex = -1;
            lbTotaalBedrag.Content = "0";
            totaalBetalen = 0;
        }
        private void cmbSoort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // de code hier onder zorgt er voor dat je alleen 1 combobox per keer geselecteerd mag worden
            cmbVerzekering.SelectionChanged -= cmbVerzekering_SelectionChanged; //zet de eventhandeler uit
            cmbService.SelectionChanged -= cmbService_SelectionChanged;
            cmbVerzekering.SelectedIndex = -1;
            cmbService.SelectedIndex = -1;
            cmbVerzekering.SelectionChanged += cmbVerzekering_SelectionChanged;
            cmbService.SelectionChanged += cmbService_SelectionChanged; //zet de eventhandeler weer aan

        }

        private void cmbVerzekering_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbFiets.SelectionChanged -= cmbSoort_SelectionChanged;
            cmbService.SelectionChanged -= cmbService_SelectionChanged;
            cmbService.SelectedIndex = -1;
            cmbFiets.SelectedIndex = -1;
            cmbFiets.SelectionChanged += cmbSoort_SelectionChanged;
            cmbService.SelectionChanged += cmbService_SelectionChanged;

        }

        private void cmbService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbFiets.SelectionChanged -= cmbSoort_SelectionChanged;
            cmbVerzekering.SelectionChanged -= cmbVerzekering_SelectionChanged;
            cmbFiets.SelectedIndex = -1;
            cmbVerzekering.SelectedIndex = -1;
            cmbFiets.SelectionChanged += cmbSoort_SelectionChanged;
            cmbVerzekering.SelectionChanged += cmbVerzekering_SelectionChanged;

        }

        private void lstVerzameling_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string[] split1 = lstVerzameling.SelectedItem.ToString().Split("€");
                string[] split2 = split1[1].Split(" ");
                decimal prijs = Convert.ToDecimal(split2[0]);
                int dagen = Convert.ToInt32(split2[5]);
                totaalBetalen -= prijs * dagen;
                lbTotaalBedrag.Content = totaalBetalen.ToString();

                lstVerzameling.Items.Remove(lstVerzameling.SelectedItem);
                lstVerzameling.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("lijkt er op dat er iets is fout gegaan");
            }
        }
    }
}