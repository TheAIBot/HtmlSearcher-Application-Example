using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using HtmlSearcher;

namespace Super_Memo_Card_Generator
{
    /// <summary>
    /// Interaction logic for CreateNewTemplate.xaml
    /// </summary>
    public partial class CreateNewTemplate : Window
    {
        Boolean EverythingIsLoaded = false;
        MainWindow UserForm;

        public CreateNewTemplate(MainWindow Form)
        {
                InitializeComponent();
            UserForm = Form;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            EverythingIsLoaded = true;
        }

        private void TemplateName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            VerifyEverything();
        }
        private void TemplateStructure_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            VerifyEverything();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VerifyEverything();
        }
        private void TemplateMaxCards_TextInput(object sender, TextCompositionEventArgs e)
        {
            VerifyEverything();
        }
        private void TemplateMaxCards_LostFocus(object sender, RoutedEventArgs e)
        {
            VerifyEverything();
        }

        private void SaveTemplate_Click(object sender, RoutedEventArgs e)
        {
            LayoutTemplate Plate = CreateTemplate();
            TemplateControl.AddTemplate(Plate);
            this.Close();
        }

        private LayoutTemplate CreateTemplate()
        {
            LayoutTemplate Plate = new LayoutTemplate
            {
                Name = TemplateName.Text.Trim(),
                Structure = TemplateStructure.Text,
                IsDefault = (bool)TempateDefault.IsChecked,
                AmountOfTexts = GetAmountOfTexts()
            };
            Plate = GetMaxCards(Plate);

            if ((bool)EnableConverter.IsChecked)
            {
                Plate.UseConverter = true;
                Plate.Converter = CreateConverter();   
            }

            return Plate;
        }

        private LayoutTemplate GetMaxCards(LayoutTemplate Plate)
        {
            if (TemplateMaxCards.Text.Trim().ToLower() == "unlimited")
            {
                Plate.UnlimitedCards = true;
                Plate.MaxCards = int.MaxValue;
            }
            else
            {
                Plate.UnlimitedCards = false;
                Plate.MaxCards = Convert.ToInt32(TemplateMaxCards.Text.Trim());
            }
            return Plate;
        }

        private WordConverter CreateConverter()
        {
            WordConverter Converter = new WordConverter();
            Converter.WebsitePlate = WebsiteTemplate.Text;
            Converter.WordsRequired = GetWordsRequiredForConverter();
            Converter.BetweenWords = ToUseBeweenWords.Text;
            return Converter;
        }

        private int GetWordsRequiredForConverter()
        {
            int i = 0;
            while (WebsiteTemplate.Text.IndexOf("{" + (i + 1) + "}") != -1)
            {
                i++;
            }
            return i;
        }

        private int GetAmountOfTexts()
        {
            string ToCheck = TemplateStructure.Text;
            int AmountOfText = 0;
            while (ToCheck.IndexOf("{" + (AmountOfText + 1).ToString() + "}") != -1)
            {
                AmountOfText++;
            }
            return AmountOfText;
        }

        public void VerifyEverything()
        {
            if (EverythingIsLoaded)
            {
                if (VerifyTemplateName()
                    && VerifyTemplateStructure()
                    && VerifyComboBoxValue())
                {
                    SaveTemplate.IsEnabled = true;
                    return;
                }
                SaveTemplate.IsEnabled = false;
            }
        }

        private Boolean VerifyTemplateStructure()
        {
            if (TemplateStructure.Text.Length > 0)
            {
                if (TemplateStructure.Text.Contains("{1}"))
                {
                    HideToolTip(TemplateStructure);
                    return true;
                }
                ShowToolTip(TemplateStructure);
            }
            return false;
        }
        private Boolean VerifyTemplateName()
        {
            //For simplicity the name only accepts chars from a to z, so no special chars and no numbers
            Regex r = new Regex("^[a-z A-Z]*$");
            string Text = TemplateName.Text.Trim();
            if (Text.Length > 0)
            {
                if (r.IsMatch(Text) && TemplateControl.Templates.All(x => x.Name != Text))
                {
                    HideToolTip(TemplateName);
                    return true;
                }
                ShowToolTip(TemplateName);
            }
            return false;
        }
        private Boolean VerifyComboBoxValue()
        {
            try
            {
                int Value = Convert.ToInt32(TemplateMaxCards.Text);
                if (Value > 0)
                {
                    HideToolTip(TemplateMaxCards);
                    return true;
                }
            }
            catch (Exception)
            {
                if (TemplateMaxCards.Text.Trim().ToLower() == "unlimited")
                {
                    HideToolTip(TemplateMaxCards);
                    return true;
                }
            }
            ShowToolTip(TemplateMaxCards);
            return false;
        }

        private void HideToolTip(Control Ctrl)
        {
            ((ToolTip)Ctrl.ToolTip).IsOpen = false;
        }

        private void ShowToolTip(Control Ctrl)
        {
            Point Loc = Ctrl.PointToScreen(new Point(0, 0));
            ((ToolTip)Ctrl.ToolTip).PlacementRectangle = new Rect(Loc.X, Loc.Y + Ctrl.Height, 0, 0);
            ((ToolTip)Ctrl.ToolTip).IsOpen = true;
        }
    }
}
