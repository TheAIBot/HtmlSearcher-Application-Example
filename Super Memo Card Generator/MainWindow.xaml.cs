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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.Web;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;
using HtmlSearcher;

namespace Super_Memo_Card_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //haven't set the TextChanged Events yet
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            try
            {
                TestsInHere.Test();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + e.StackTrace);
            }
            Groups.Items.Add("fisk");
#endif
        }

        private void WebsiteAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            Uri fisk;
            try
            {
                fisk = new Uri(WebsiteAddress.Text);
            }
            catch (Exception) 
            {
                return;
            }
            WBrowser.Navigate(fisk);
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            if (GroupName.Text.Trim() != String.Empty)
            {
                Groups.Items.Add(GroupName.Text);
            }
        }

        private void AddTextGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddText_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}