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
using System.Runtime.Serialization;

namespace Super_Memo_Card_Generator
{
    /// <summary>
    /// Interaction logic for NewTemplateWindow.xaml
    /// </summary>
    public partial class NewTemplateWindow : Window
    {
        public NewTemplateWindow()
        {
            InitializeComponent();
            LayoutTemplate Plate = new LayoutTemplate();
            TextStructure.Text = Plate.Structure;
            TemplateName.Text = Plate.Name;
            IsDefault.IsChecked = Plate.IsDefault;
        }

        private Boolean VerifyTemplateName()
        {
            string PlateName = TemplateName.Text.Trim();
            if (PlateName.Length > 0)
            {
                if (TemplateControl.Templates.All(x => x.Name != PlateName))
                {
                    return true;
                }
                throw new NameException("Another template already has that name");
            }
            throw new NameException("No name entered");
        }

        private Boolean VerifyTemplateTextAmunt()
        {
            try
            {
                int Text = Convert.ToInt32(AmountOfTexts.Text);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        [Serializable]
        private class NameException : Exception
        {
            public NameException(string message) : base(message) { }

            protected NameException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
        }
    }
}
