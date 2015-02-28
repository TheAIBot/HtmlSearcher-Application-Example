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
using System.Text.RegularExpressions;
using HtmlSearcher;
using System.IO;
using System.Xml.Serialization;

namespace Super_Memo_Card_Generator
{
    /// <summary>
    /// Interaction logic for EditTemplateWindow.xaml
    /// </summary>
    public partial class EditTemplateWindow : Window
    {
        Boolean EverythingIsLoaded = false;
        MainWindow UserForm;
        LayoutTemplate PlateToChange;

        public EditTemplateWindow(MainWindow Form)
        {
            InitializeComponent();
            UserForm = Form;
            InsertTemplatesInComboBox();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            EverythingIsLoaded = true;
        }

        private void InsertTemplatesInComboBox()
        {
            List<string> TemplateNames = TemplateControl.Templates.Select(x => x.Name).ToList();
            AllTemplates.ItemsSource = TemplateNames;
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
            TemplateControl.ChangeTemplate(PlateToChange, Plate);
            this.Close();
        }

        private LayoutTemplate CreateTemplate()
        {
            LayoutTemplate Plate = new LayoutTemplate();
            Plate.Name = TemplateName.Text.Trim();
            Plate.Structure = TemplateStructure.Text;
            Plate.IsDefault = (bool)TempateDefault.IsChecked;
            Plate.AmountOfTexts = GetAmountOfTexts();
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
                    && VerifyTemplateStructure(TemplateStructure)
                    && VerifyComboBoxValue())
                {
                    if ((bool)EnableConverter.IsChecked)
                    {
                        if (VerifyTemplateStructure(WebsiteTemplate))
                        {
                            SaveTemplate.IsEnabled = true;
                            return;
                        }
                        SaveTemplate.IsEnabled = false;
                        return;
                    }
                    SaveTemplate.IsEnabled = true;
                    return;
                }
                SaveTemplate.IsEnabled = false;
            }
        }

        private Boolean VerifyTemplateStructure(TextBox Ctrl)
        {
            if (Ctrl.Text.Length > 0)
            {
                if (Ctrl.Text.Contains("{1}"))
                {
                    HideToolTip(Ctrl);
                    return true;
                }
                ShowToolTip(Ctrl);
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
                HideToolTip(TemplateName);
                return true;
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

        private void ShowTemplate(LayoutTemplate Plate)
        {
            TemplateStructure.Text = Plate.Structure;
            TemplateName.Text = Plate.Name;
            ShowMaxCards(Plate);
            if ((bool)EnableConverter.IsChecked)
            {
                WebsiteTemplate.Text = Plate.Converter.WebsitePlate;
                ToUseBeweenWords.Text = Plate.Converter.BetweenWords;
            }
            TempateDefault.IsChecked = Plate.IsDefault;
        }

        private void ShowMaxCards(LayoutTemplate Plate)
        {
            if (Plate.UnlimitedCards == true)
            {
                TemplateMaxCards.SelectedIndex = 0;
            }
            else
            {
                TemplateMaxCards.Text = Plate.MaxCards.ToString();
            }
        }

        private void AllTemplates_LostFocus(object sender, RoutedEventArgs e)
        {
            LayoutTemplate Plate = TemplateControl.Templates.SingleOrDefault(x => x.Name == AllTemplates.Text);
            if (Plate != default(LayoutTemplate))
            {
                TemplateMaxCards.IsEnabled = true;
                TemplateName.IsEnabled = true;
                TemplateStructure.IsEnabled = true;
                TempateDefault.IsEnabled = true;
                EnableConverter.IsChecked = true;

                ShowTemplate(Plate);
                PlateToChange = Plate;
                return;
            }
            TemplateMaxCards.IsEnabled = false;
            TemplateName.IsEnabled = false;
            TemplateStructure.IsEnabled = false;
            TempateDefault.IsEnabled = false;
            EnableConverter.IsChecked = false;
        }
    }

    //public static class TemplateControls
    //{
    //    private const string DirectoryName = "Templates";
    //    public static List<LayoutTemplate> Templates = new List<LayoutTemplate>();

    //    internal static void LoadEverything()
    //    {
    //        //create directory to store the templates in, if it doesn't exist
    //        if (!Directory.Exists(DirectoryName))
    //        {
    //            Directory.CreateDirectory(DirectoryName);
    //        }
    //        //if the default template doesn't exists then it's created and saved to the Template directory
    //        if (!File.Exists(System.IO.Path.Combine(DirectoryName, new LayoutTemplate().Name)))
    //        {
    //            LayoutTemplate Plate = new LayoutTemplate();
    //            Plate.IsDefault = true;
    //            SaveTemplate(Plate);
    //        }
    //        //load all saved templates
    //        Templates = LoadAllTemplates();
    //    }

    //    public static void SaveTemplate(LayoutTemplate Plate)
    //    {
    //        using (FileStream FStream = new FileStream(System.IO.Path.Combine(DirectoryName, Plate.Name), FileMode.Create))
    //        {
    //            XmlSerializer Serializer = new XmlSerializer(typeof(LayoutTemplate));
    //            Serializer.Serialize(FStream, Plate);
    //        }
    //    }

    //    public static void AddTemplate(LayoutTemplate Plate)
    //    {
    //        SaveTemplate(Plate);
    //        if (Plate.IsDefault)
    //        {
    //            LayoutTemplate TPlate = Templates.Single(x => x.IsDefault);
    //            TPlate.IsDefault = false;
    //            SaveTemplate(TPlate);
    //        }
    //        Templates.Add(Plate);
    //    }

    //    public static void RemoveTemplate(LayoutTemplate Plate)
    //    {
    //        Templates.Remove(Plate);
    //        File.Delete(System.IO.Path.Combine(DirectoryName, Plate.Name));
    //    }

    //    public static void ChangeTemplate(LayoutTemplate ToChange, LayoutTemplate ChangeTo)
    //    {
    //        if (!ToChange.IsDefault && ChangeTo.IsDefault)
    //        {
    //            LayoutTemplate TPlate = Templates.Single(x => x.IsDefault);
    //            TPlate.IsDefault = false;
    //            SaveTemplate(TPlate);
    //        }
    //        File.Delete(System.IO.Path.Combine(DirectoryName, ToChange.Name));
    //        SaveTemplate(ChangeTo);
    //        Templates = LoadAllTemplates();
    //        TemplateControl.Templates = TemplateControl.
    //    }

    //    internal static List<LayoutTemplate> LoadAllTemplates()
    //    {
    //        List<LayoutTemplate> Plates = new List<LayoutTemplate>();
    //        foreach (string FilePath in Directory.GetFiles(DirectoryName))
    //        {
    //            using (FileStream FStream = new FileStream(FilePath, FileMode.Open))
    //            {
    //                XmlSerializer Serializer = new XmlSerializer(typeof(LayoutTemplate));
    //                LayoutTemplate TPlate = (LayoutTemplate)Serializer.Deserialize(FStream);
    //                Plates.Add(TPlate);
    //            }
    //        }
    //        return Plates;
    //    }
    //}

    //[Serializable()]
    //public class LayoutTemplate
    //{
    //    public string Name = "Default Template";
    //    public string Structure = "q: {1}" + Environment.NewLine +
    //                              "a: {2}" + Environment.NewLine + Environment.NewLine;
    //    public Boolean IsDefault = false;
    //    public int AmountOfTexts = 2;
    //    public Boolean UnlimitedCards = true;
    //    public int MaxCards = int.MaxValue;
    //}
}
