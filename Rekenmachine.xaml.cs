using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fietsenwinkel_allerlaatste_poging
{
    /// <summary>
    /// decimaleraction logic for Rekenmachine.xaml
    /// </summary>
    public partial class Rekenmachine : Window
    {
        //de som die berekend kan worden
        string Reken = "";
        decimal Antwoord = 0;

        public Rekenmachine()
        {
            InitializeComponent();
        }

        private void btnNull_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 0;
        }

        private void btnEen_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 1;
        }

        private void btnTwee_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 2;
        }

        private void btnDrie_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 3;
        }

        private void btnVier_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 4;
        }

        private void btnVijf_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 5;
        }

        private void btnZes_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 6;
            btnDellen.IsEnabled = true;
            btnKeer.IsEnabled = true;
        }

        private void btnZeven_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 7;
        }

        private void btnAcht_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 8;
        }

        private void btnNegen_Click(object sender, RoutedEventArgs e)
        {
            txtBerekening.Text = Reken = Reken + 9;
        }

        private void btnDellen_Click(object sender, RoutedEventArgs e)
        {
            if (!txtBerekening.Text.EndsWith("+ ") && !txtBerekening.Text.EndsWith("- ") && !txtBerekening.Text.EndsWith("x ") && !txtBerekening.Text.EndsWith(": ") && !txtBerekening.Text.EndsWith(","))
            {
                txtBerekening.Text = Reken = Reken + " " + ":" + " ";
                btnComma.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("vul een tweede getal in");
            }
        }

        private void btnKeer_Click(object sender, RoutedEventArgs e)
        {
            if (!txtBerekening.Text.EndsWith("+ ") && !txtBerekening.Text.EndsWith("- ") && !txtBerekening.Text.EndsWith("x ") && !txtBerekening.Text.EndsWith(": ") && !txtBerekening.Text.EndsWith(","))
            {
                txtBerekening.Text = Reken = Reken + " " + "x" + " ";
                btnComma.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("vul een tweede getal in");
            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (!txtBerekening.Text.EndsWith("+ ") && !txtBerekening.Text.EndsWith("- ") && !txtBerekening.Text.EndsWith("x ") && !txtBerekening.Text.EndsWith(": ") && !txtBerekening.Text.EndsWith(","))
            {
                txtBerekening.Text = Reken = Reken + " " + "+" + " ";
                btnComma.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("vul een tweede getal in");
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            if (!txtBerekening.Text.EndsWith("+ ") && !txtBerekening.Text.EndsWith("- ") && !txtBerekening.Text.EndsWith("x ") && !txtBerekening.Text.EndsWith(": ") && !txtBerekening.Text.EndsWith(","))
            {
                txtBerekening.Text = Reken = Reken + " " + "-" + " ";
                btnComma.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("vul een tweede getal in");
            }
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //zorgt er voor dat alles weg gaat en het and ook word gereset
            Reken = "";
            txtBerekening.Text = "";
            txtAntwoord.Text = "";
            btnComma.IsEnabled = true;

        }

        private void btnAntwoord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!txtBerekening.Text.EndsWith("+ ") && !txtBerekening.Text.EndsWith("- ") && !txtBerekening.Text.EndsWith("x ") && !txtBerekening.Text.EndsWith(": ") && !txtBerekening.Text.EndsWith(","))
                {
                    string[] mathDiv = Reken.Split(" ");
                    if (mathDiv[1] == "+")
                    {
                        //pakt het eerste getal en doet plus het 2de getal
                        decimal value1 = decimal.Parse(mathDiv[0]);
                        decimal value2 = decimal.Parse(mathDiv[2]);
                        Antwoord = value1 + value2;
                        txtAntwoord.Text = Antwoord.ToString();
                    }
                    else if (mathDiv[1] == "-")
                    {
                        //pakt het eerste getal en doet min het 2de getal
                        decimal value1 = decimal.Parse(mathDiv[0]);
                        decimal value2 = decimal.Parse(mathDiv[2]);
                        Antwoord = value1 - value2;
                        txtAntwoord.Text = Antwoord.ToString();
                    }
                    else if (mathDiv[1] == ":")
                    {
                        //pakt het eerste getal en doet gedeeld door het 2de getal
                        decimal value1 = decimal.Parse(mathDiv[0]);
                        decimal value2 = decimal.Parse(mathDiv[2]);
                        Antwoord = value1 / value2;
                        txtAntwoord.Text = Antwoord.ToString();
                    }
                    else
                    {
                        //pakt het eerste getal en doet keer door het 2de getal
                        decimal value1 = decimal.Parse(mathDiv[0]);
                        decimal value2 = decimal.Parse(mathDiv[2]);
                        Antwoord = value1 * value2;
                        txtAntwoord.Text = Antwoord.ToString();
                    }
                    btnComma.IsEnabled = true;

                }
                else
                {
                    MessageBox.Show("vul Eerst een tweede getal in");
                }
            }
            catch
            {
                MessageBox.Show("Je hebt nog niet de voledige berekening afgemaakt");
            }
        }

        private void btnAns_Click(object sender, RoutedEventArgs e)
        {
            Reken = Antwoord.ToString();
            txtBerekening.Text = Reken.ToString();
            txtAntwoord.Text = "";
            btnComma.IsEnabled = true;
        }

        private void btnComma_Click(object sender, RoutedEventArgs e)
        {
            if (!txtBerekening.Text.EndsWith("+ ") && !txtBerekening.Text.EndsWith("- ") && !txtBerekening.Text.EndsWith("x ") && !txtBerekening.Text.EndsWith(": ") && !txtBerekening.Text.EndsWith(",") && !txtBerekening.Text.EndsWith("0,"))
            {

                if (txtBerekening.Text == "")
                {
                    txtBerekening.Text = Reken = Reken + "0,";
                }
                else
                {
                    txtBerekening.Text = Reken = Reken + ",";
                }
                btnComma.IsEnabled = false;
            }
            else
            {
                txtBerekening.Text = Reken = Reken + "0,";
                btnComma.IsEnabled = false;
            }
        }
    }
}
