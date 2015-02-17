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
using System.Diagnostics;
using System.Text.RegularExpressions;
using HtmlSearcher;

namespace Super_Memo_Card_Generator
{
    /// <summary>
    /// Interaction logic for GetTextsToSearchFor.xaml
    /// </summary>
    public partial class GetTextsToSearchFor : Window
    {
        readonly int AmountOfTexts;
        readonly string WebAddress;
        public List<string> FoundTextToUse;

        public GetTextsToSearchFor(string webaddress, int AmountOfTextsToFind)
        {
            InitializeComponent();
            WebAddress = webaddress;
            AmountOfTexts = AmountOfTextsToFind;
#if DEBUG || !DEBUG
            //TextsToFind.Text = "mam" + Environment.NewLine +
            //    "妈";
            //TextsToFind.Text = "nosotros/nosotras bautizamos " + Environment.NewLine +
                           //"he/she/it baptizes";
            //TextsToFind.Text = "perro" + Environment.NewLine +
            //                "adj. col. Muy malo,indigno:" + Environment.NewLine +
            //                "mentira perra.";
            //TextsToFind.Text = "bullshit" + Environment.NewLine +
            //    "Wise up to Jake's bullshit." + Environment.NewLine +
            //    "Avivate de esta mierda de Jake.";
            TextsToFind.Text = "reducir" + Environment.NewLine +
                            "abad";
            Finish.IsEnabled = true;
#endif
        }

        private void Finish_Click_1(object sender, RoutedEventArgs e)
        {
            FoundTextToUse = GetText();
            DialogResult = true;
            this.Close();
        }

        private void OpenWebsite_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start(WebAddress);
        }

        private void TextsToFinds_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            List<string> LineText = GetText();
            if (LineText.Count == AmountOfTexts)
            {
                Finish.IsEnabled = true;
            }
            else
            {
                Finish.IsEnabled = false;
            }
        }

        private List<string> GetText()
        {
            List<string> LineText = new List<string>();
            for (int i = 0; i < TextsToFind.LineCount; i++)
            {
                string LookFor = TextsToFind.GetLineText(i).Trim();
                LookFor = Regex.Replace(LookFor, Environment.NewLine, String.Empty);
                //no point in adding empty lines to the line count
                if (LookFor != String.Empty)
                {
                    //the html code is all lower case, so the text to look for has to be aswell
                    LineText.Add(LookFor.ToLower());
                }
            }
            return LineText;
        }
    }
}
