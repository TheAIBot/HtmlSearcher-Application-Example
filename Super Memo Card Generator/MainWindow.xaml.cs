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
        int GroupIndex = 0;
        int GroupTextsIndex = -1;
        int TextIndex = -1;
        List<GroupToFind> GroupList = new List<GroupToFind>();

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
            Groups.Items.Add("Translation");
            GroupList.Add(new GroupToFind() { Name = "Translation" });
#endif
        }

        private void WebsiteAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Uri derp = new Uri("http://" + WebsiteAddress.Text, UriKind.Absolute);
                WBrowser.Navigate(derp);
            }
            catch (Exception) { }
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            if (GroupName.Text.Trim() != String.Empty)
            {
                GroupToFind NewGroup = new GroupToFind();
                NewGroup.Name = GroupName.Text.Trim();
                GroupList.Add(NewGroup);

                Groups.Items.Add(GroupName.Text.Trim());
            }
        }
        private void AddTextGroup_Click(object sender, RoutedEventArgs e)
        {
            if (GroupTextName.Text.Trim() != String.Empty
                && GroupIndex != -1)
            {
                TextToFindInfo TFinfo = new TextToFindInfo();
                TFinfo.Name = GroupTextName.Text.Trim();
                GroupList[GroupIndex].TextsToFind.Add(TFinfo);

                GroupTexts.Items.Add(GroupTextName.Text.Trim());
            }
        }
        private void AddText_Click(object sender, RoutedEventArgs e)
        {
            if (TextToAdd.Text.Trim() != String.Empty
                && GroupIndex != -1
                && GroupTextsIndex != -1)
            {
                GroupList[GroupIndex].TextsToFind[GroupTextsIndex].TextsToFind.Add(TextToAdd.Text);
                TextsInTextGroup.Items.Add(TextToAdd.Text);
            }
        }

        private void RemoveGroup_Click(object sender, RoutedEventArgs e)
        {
            if (GroupIndex != -1 &&
                GroupList.Count > 0)
            {
                Groups.Items.RemoveAt(GroupIndex);
                GroupList.RemoveAt(GroupIndex);
            }
        }
        private void RemoveGroupText_Click(object sender, RoutedEventArgs e)
        {
            if (GroupIndex != -1
                && GroupTextsIndex != -1)
            {
                GroupTexts.Items.RemoveAt(GroupTextsIndex);
                GroupList[GroupIndex].TextsToFind.RemoveAt(GroupTextsIndex);
            }
        }
        private void RemoveText_Click(object sender, RoutedEventArgs e)
        {
            if (GroupIndex != -1
                && GroupTextsIndex != -1
                && TextIndex != -1)
            {
                TextsInTextGroup.Items.RemoveAt(TextIndex);
                GroupList[GroupIndex].TextsToFind[GroupTextsIndex].TextsToFind.RemoveAt(TextIndex);
            }
        }

        private void GroupsListBoxIndexChanged(object sender, MouseButtonEventArgs e)
        {
            GroupIndex = Groups.SelectedIndex;
            GroupTextsIndex = -1;
            TextIndex = -1;
            ShowInfoInLists();
        }
        private void GroupTextsListBoxIndexChanged(object sender, MouseButtonEventArgs e)
        {
            GroupTextsIndex = GroupTexts.SelectedIndex;
            TextIndex = -1;
            ShowInfoInLists();
        }
        private void TextsInTextGroupListBoxIndexChanged(object sender, MouseButtonEventArgs e)
        {
            TextIndex = TextsInTextGroup.SelectedIndex;
            ShowInfoInLists();
        }

        private void ShowInfoInLists()
        {
            Groups.Items.Clear();
            foreach (var GG in GroupList)
            {
                Groups.Items.Add(GG.Name);
            }
            Groups.SelectedIndex = GroupIndex;

            if (GroupIndex != -1)
            {
                GroupTexts.Items.Clear();
                foreach (TextToFindInfo TText in GroupList[GroupIndex].TextsToFind)
                {
                    GroupTexts.Items.Add(TText.Name);
                }
                GroupTexts.SelectedIndex = GroupTextsIndex;

                if (GroupTextsIndex != -1)
                {
                    TextsInTextGroup.Items.Clear();
                    foreach (string Text in GroupList[GroupIndex].TextsToFind[GroupTextsIndex].TextsToFind)
                    {
                        TextsInTextGroup.Items.Add(Text);
                    }
                    TextsInTextGroup.SelectedIndex = TextIndex;
                }
                else
                {
                    TextsInTextGroup.Items.Clear();
                }
            }
            else
            {
                GroupTexts.Items.Clear();
                TextsInTextGroup.Items.Clear();
            }
        }
    }
}