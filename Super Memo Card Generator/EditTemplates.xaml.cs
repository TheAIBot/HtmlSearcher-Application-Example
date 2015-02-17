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
using HtmlSearcher;

namespace Super_Memo_Card_Generator
{
    /// <summary>
    /// Interaction logic for EditTemplates.xaml
    /// </summary>
    public partial class EditTemplates : Window
    {
        MainWindow UserForm;

        public EditTemplates(MainWindow UForm)
        {
            InitializeComponent();
            UserForm = UForm;
            this.Closing += (e,sender) => UserForm.FillComboboxes();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            AddPlates();
        }

        private void AddPlates()
        {
            ListBoxWithDefaults.ItemsSource = TemplateControl.Templates.Select(x => new DefaultStuff(TemplateControl.Templates.IndexOf(x))).ToList();
        }

        private class DefaultStuff
        {
            int Index;

            public string Name 
            {
                get
                {
                    return TemplateControl.Templates[Index].Name;
                }
                set
                {
                    TemplateControl.Templates[Index].Name = value;
                }
            }

            public bool IsDefault
            {
                get
                {
                    return TemplateControl.Templates[Index].IsDefault;
                }
                set
                {
                    TemplateControl.Templates[Index].IsDefault = (bool)value;

                    TemplateControl.SaveTemplate(TemplateControl.Templates[Index]);
                }
            }

            public DefaultStuff(int index)
            {
                Index = index;
            }
        }
    }
}
