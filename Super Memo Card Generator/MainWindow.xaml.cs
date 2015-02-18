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
        //S
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
#endif
            Search.OnProgressChanged += Search_OnProgressChanged;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            FillComboboxes();
        }

        public void FillComboboxes()
        {
            List<string> TemplateNames = (from Template in TemplateControl.Templates
                                          select Template.Name).ToList();
        }

        #region Get texts from html code

        //private List<List<string>> GetBestGuessList(List<List<List<string>>> ListToCheck)
        //{
        //    int[] testpoint = new int[emner.Count];
        //    char[] subjectarray = new char[subject.Length];
        //    string teststring = "";
        //    subjectarray = subject.ToCharArray();
        //    for (int i = 0; i < emner.Count; i++)
        //    {
        //        for (int u = 0; u < subject.Length; u++)
        //        {
        //            for (int o = 0; o < subject.Length - u; o++)
        //            {
        //                teststring = "";
        //                for (int io = 0; io < u + 1; io++)
        //                {
        //                    teststring += subjectarray[o + io]; //dynsk dansk d y n s k dy yn ns sk dyn yns nsk dyns ynsk dynsk
        //                }
        //                //textBox2.Text += System.Environment.NewLine + teststring;
        //                if (emner[i].ToLower().IndexOf(teststring) != -1)
        //                {
        //                    testpoint[i]++;
        //                }
        //            }
        //        }
        //    }

        //    int score = 0;

        //    int closestEmne = 0;
        //    for (int t = 0; t < emner.Count; t++)
        //    {
        //        if (testpoint[t] > score)
        //        {
        //            score = testpoint[t];
        //            closestEmne = t;
        //        }
        //    }
        //}
        #endregion

        private List<string> GetWebAddresses()
        {
            List<string> WebAddresses = new List<string>();
            //for (int i = 0; i < TextBoxWebsites.LineCount; i++)
            //{
            //    string Address = TextBoxWebsites.GetLineText(i);
            //    Address = Regex.Replace(Address, Environment.NewLine, String.Empty).Trim();
            //    if (Address.Length > 0)
            //    {
            //        WebAddresses.Add(Address);
            //    }
            //}
            return WebAddresses;
        }

        private POptions GetPOption()
        {
            //switch (ChosenPOption.Text)
            //{
            //    case "Auto":
            //        return POptions.Auto;
            //    case "Manual":
            //        return POptions.Manual;
            //    default:
                    return POptions.Auto; // this is just to make the compiler happy
            //}
        }

        private void ShowDebugScreen()
        {
            //UserInput.Visibility = Visibility.Hidden;
            //DebugGrid.Visibility = Visibility.Visible;
        }

        private void ShowInputScreen()
        {
            //UserInput.Visibility = Visibility.Visible;
            //DebugGrid.Visibility = Visibility.Hidden;
        }

        private void MakeCards(List<string> WebAddresses, LayoutTemplate Plate, POptions POption)
        {
            //List<ProcessedInfo> PInfos = Search.FindText(WebAddresses, Plate, POption);

            //foreach (ProcessedInfo PInfo  in PInfos)
            //{
            //    if (!PInfo.Failed)
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            var Wind = new SuperiorMessageBox(PInfo, Plate);
            //            Wind.Owner = this;
            //            Wind.Show();
            //        });
            //    }
            //    else
            //    {
            //        System.Windows.Forms.MessageBox.Show(PInfo.Error.Message + Environment.NewLine + PInfo.Error.StackTrace);
            //    }
            //}
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText("TextFile.txt", "");
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShowDebugScreen();

            //POptions POption = GetPOption();
            //List<string> WebAddresses = GetWebAddresses();
            //LayoutTemplate Plate = TemplateControl.Templates.Single(x => x.Name == ChosenTemplate.Text);

            //await Task.Factory.StartNew(() => MakeCards(WebAddresses, Plate, POption));
//#if !DEBUG
            ShowInputScreen();
//#endif
        }

        private void Search_OnProgressChanged(object source, ProgressEventArgs e)
        {
            //Dispatcher.Invoke(() => ShowProgress.Text = e.UpdateText);
        }

        private async void TextBoxWebsites_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            //List<string> WebAddresses = GetWebAddresses();
            //List<Task<Tuple<Boolean, string>>> Tasks = new List<Task<Tuple<Boolean, string>>>();
            //foreach (string Address in WebAddresses)
            //{
            //    Tasks.Add(Task<Tuple<Boolean, string>>.Factory.StartNew(() => PingWebsite(Address)));
            //}
            //while (Tasks.Count > 0)
            //{
            //    Task<Tuple<Boolean, string>> FinishedTask = await Task.WhenAny(Tasks);
            //}
        }

        private void ShowPingResponseInTextbox(Tuple<Boolean, string> Info)
        {
            List<string> WebAddresses = GetWebAddresses();
            //TextBoxWebsites.Text = String.Empty;
            //TextBoxWebsites.InLine
        }

        private void NewTemplate_Click(object sender, RoutedEventArgs e)
        {
            new CreateNewTemplate(this).Show();
        }

        private void EditTemplate_Click(object sender, RoutedEventArgs e)
        {
            new EditTemplateWindow(this).Show();
        }

        private void EditTemplates_Click(object sender, RoutedEventArgs e)
        {
            new EditTemplates(this).Show();
        }

        //private Tuple<Boolean,string> PingWebsite(string Website)
        //{
        //    ////tries to ping 3 times
        //    //for (int i = 0; i < 3; i++)
        //    //{
        //    //    try
        //    //    {
        //    //        Ping ping = new Ping();
        //    //        PingReply result = ping.Send(Website);

        //    //        if (result.Status == IPStatus.Success)
        //    //        {
        //    //            //got a response from the website
        //    //            return new Tuple<Boolean, string>(true, Website);
        //    //        }
        //    //    }
        //    //    catch (Exception) { }
        //    //}
        //    ////couldn't connect to the website
        //    //return new Tuple<Boolean, string>(false, Website);
        //}
    }
}