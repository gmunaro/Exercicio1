using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using LiveCharts;
using LiveCharts.Wpf;

namespace Exercicio1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Exercicio();
        }

        void Exercicio()
        {
            List<string> Saida = new List<string>();

            string poema = @"Café com pão
Café com pão
Café com pão
Virge Maria que foi isto maquinista?

Agora sim
Café com pão
Agora sim
Voa, fumaça
Corre, cerca
Ai seu foguista
Bota fogo
Na fornalha
Que eu preciso
Muita força
Muita força
Muita força

Oô...
Foge, bicho
Foge, povo
Passa ponte
Passa poste
Passa pasto
Passa boi
Passa boiada
Passa galho
De ingazeira
Debruçada
No riacho
Que vontade
De cantar!

Oô...
Quando me prendero
No canaviá
Cada pé de cana
Era um oficiá

Oô...
Menina bonita
Do vestido verde
Me dá tua boca
Pra matá minha sede
Oô...
Vou mimbora vou mimbora
Não gosto daqui
Nasci no Sertão
Sou de Ouricuri
Oô...

Vou depressa
Vou correndo
Vou na toda
Que só levo
Pouca gente
Pouca gente
Pouca gente...";


            string PoemaReserva = poema;
            List<string> Tags = new List<string>();
            poema = poema.Replace(Environment.NewLine, " ").ToLower();
            string[] Palavras = poema.Split(" ");
            foreach (string Palavra in Palavras)
            {
                string PalavraTratada = RemoveCaracteres(Palavra);
                if (PalavraTratada != "")
                {
                    if (!Tags.Contains(PalavraTratada))
                    {
                        Tags.Add(PalavraTratada);
                        Saida.Add("Token encontrado: " + PalavraTratada);

                    }
                }
            }

            Saida.Add("1b) Foram encontrados " + Tags.Count + " Tokens");

            Saida.Add("1c) Das palavras contidas no texto, " + Palavras.Length + " , existem " + Tags.Count + " Palavras únicas");

            TB.ItemsSource = Saida;

            foreach (string Tag in Tags)
            {

                Grafico.Series.Add(new PieSeries
                {
                    Title = Tag,
                    Values = new ChartValues<int> { Regex.Matches(poema, Tag).Count() },
                    DataLabels = true
                }
                );

            }


            Saida.Add("1d) A palavra Pão aparece " + Regex.Matches(poema, "pão").Count() + " vezes");
            Saida.Add("1d) A palavra passa aparece " + Regex.Matches(poema, "passa").Count() + " vezes");

            Saida.Add("1e) A probabilidade de uma palavra ser \"Força\", é de: " + (Regex.Matches(poema, "força").Count()/ Palavras.Length) * 100 + " % ");

            
            foreach(string Tag in Tags)
            {
                if (Tag.Contains("ista"))
                {
                    Saida.Add("1f) A palavra: " + Tag + " Termina com \"ista\"");
                }
            }

            foreach (string Tag in Tags)
            {
                if (Tag.Contains("ista"))
                {
                    Saida.Add("1f) A palavra: " + Tag + " Termina com \"ista\"");
                }
            }

            foreach(string Tag in Tags)
            {
                bool PrimeiraLetraMaiuscula = false;
                string PalavraTratada = "";
                foreach(char c in Tag)
                {
                    if (PrimeiraLetraMaiuscula)
                    {
                        PalavraTratada += c;
                    }
                    else
                    {
                        PalavraTratada += char.ToUpper(c);
                    }
                }
                if (PoemaReserva.Contains(PalavraTratada))
                {
                    Saida.Add("1g) A palavra: " + PalavraTratada + " Começa com letra maiúscula");
                }
            }

            foreach(string Tag in Tags)
            {
                if (Tag.ToCharArray().Length < 3)
                {
                    Saida.Add("1h) A palavra: " + Tag + " Tem menos de três caracteres");
                }
            }

        }

        public static string RemoveCaracteres(string str)
        {
            string Retorno = "";

            foreach (char c in str)
            {
                if (!(c == '.' | c == ',' | c == '?' | c == '!'))
                {
                    Retorno = Retorno + c;
                }

            }
            return Retorno;

        }
    }

}
