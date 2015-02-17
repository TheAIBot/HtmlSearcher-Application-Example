using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Forms;
using HtmlSearcher;

namespace Super_Memo_Card_Generator
{
    /// <summary>
    /// Interaction logic for SuperiorMessageBox.xaml
    /// </summary>
    public partial class SuperiorMessageBox : Window
    {
        //LayoutTemplate Plate;
        //FoundText[] CostumList;
        //List<FoundText> CurrentlyShownText = new List<FoundText>();
        //int Index;
        //int MainIndex = -1;
        //List<int> TreeIndexes = new List<int>();
        ////ProcessedInfo PInfo;
        //System.Windows.Forms.TreeView treeView1;
        //List<TreeViewElement> TreeViewElements = new List<TreeViewElement>();
        //int ListBoxSelectedIndex;

        public SuperiorMessageBox(ProcessedInfo PInfo, LayoutTemplate TPlate)
        {
            InitializeComponent();
            //treeView1 = (System.Windows.Forms.TreeView)Compat.Child;

            //this.treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            ////PInfo = PInfo;
            //Plate = TPlate;
            //CostumList = new FoundText[PInfo.AllTexts.Count];

            //SetupTreeNodes(PInfo);
        }

        //private void SetupTreeNodes(ProcessedInfo PInfo)
        //{
        //    TreeViewElements.Add(new TreeViewElement("Sammenlagte par", PInfo.CorrectTexts, 0, false));
        //    TreeViewElements.Add(new TreeViewElement("Næsten sammenlagte par", PInfo.CloseCorrectTexts, 1, false));
        //    TreeViewElements.Add(new TreeViewElement("Alle lister", PInfo.AllTexts, 2, true));

        //    MainTreeNodeMaker();
        //}

        //private void MainTreeNodeMaker()
        //{
        //    // setups the treeview
        //    foreach (var TreeElement in TreeViewElements)
        //    {
        //        if (!TreeElement.IsLast)
        //        {
        //            SetupTreeView(TreeElement.ElementList, TreeElement.Name);
        //        }
        //        else
        //        {
        //            AddAllListsToTreeView(TreeElement.ElementList,TreeElement.Name);
        //        }
        //    }
        //    // choses what should be shown to the user the first time the window opens
        //    foreach (var TreeElement in TreeViewElements)
        //    {
        //        if (!TreeElement.IsLast)
        //        {
        //            if (TreeElement.ElementList.Count > 0)
        //            {
        //                ShowTextBox.Text = ConvertTextPiecesToShowText(TreeElement.ElementList[0]);
        //                return;
        //            }
        //        }
        //    }
        //}

        //private void AddAllListsToTreeView(List<List<FoundText>> ListToAdd, string Name)
        //{

        //    List<List<TreeNode>> Node1 = (from Item1 in ListToAdd
        //                                  select new List<TreeNode>(
        //                                 (from Item2 in Item1
        //                                  select new TreeNode(Item2.Texts.Count().ToString())).ToList())).ToList();
        //    int Index1 = 1;
        //    List<TreeNode> Node2 = new List<TreeNode>();
        //    foreach (List<TreeNode> item in Node1)
        //    {
        //        int TempIndex = 0;
        //        foreach (TreeNode item1 in item)
        //        {
        //            item1.Name = TempIndex.ToString();
        //            TempIndex++;
        //        }
        //        TreeNode Temp = new TreeNode("Liste " + Index1.ToString(), item.ToArray());
        //        Temp.Name = (Index1 - 1).ToString();
        //        Node2.Add(Temp);
        //        Index1++;
        //    }
        //    TreeNode Node3 = new TreeNode(Name, Node2.ToArray());
        //    Node3.ExpandAll();
        //    treeView1.Nodes.Add(Node3);
        //}

        //private void FindSelectedNode(TreeNodeMouseClickEventArgs e, ref List<List<FoundText>> ListToCheck, int MIndex, string TextToCheckFor)
        //{
        //    if (IsNodeAChild(e.Node.Parent))
        //    {
        //        this.Index = e.Node.Parent.Index;
        //    }
        //    ShowTextBox.Text = ConvertTextPiecesToShowText(ListToCheck[this.Index]);
        //    MainIndex = MIndex;
        //    TreeIndexes.Clear();
        //    if (e.Node.Parent.Text == TextToCheckFor)
        //    {
        //        TreeIndexes.Add(Convert.ToInt32(e.Node.Name));
        //    }
        //    else
        //    {
        //        int TempIndex1 = Convert.ToInt32(e.Node.Parent.Name);
        //        int TempIndex2 = Convert.ToInt32(e.Node.Name);
        //        TreeIndexes.Add(TempIndex1);
        //        TreeIndexes.Add(TempIndex2);
        //        listBox1.Items.Clear();

        //        foreach (string item in ListToCheck[TempIndex1][TempIndex2].Texts)
        //        {
        //            listBox1.Items.Add(item);
        //        }
        //    }
        //}

        //private void FindSelectedNodeAll(TreeNodeMouseClickEventArgs e, ref List<List<FoundText>> ListToCheck, int MIndex)
        //{
        //    int NodeIndex = Convert.ToInt32(e.Node.Parent.Name);
        //    listBox1.Items.Clear();
        //    MainIndex = MIndex;
        //    foreach (string item in ListToCheck[NodeIndex][Index].Texts)
        //    {
        //        listBox1.Items.Add(item);
        //    }
        //    TreeIndexes.Clear();
        //    int TempIndex1 = Convert.ToInt32(e.Node.Parent.Name);
        //    int TempIndex2 = Convert.ToInt32(e.Node.Name);
        //    TreeIndexes.Add(TempIndex1);
        //    TreeIndexes.Add(TempIndex2);
        //    if (IsNodeAChild(e.Node.Parent))
        //    {
        //        CostumList[TempIndex1] = ListToCheck[TempIndex1][TempIndex2]; // adds the list to the list of lists that will be used
        //        foreach (TreeNode Node in e.Node.Parent.Nodes) // removes the - - - from the old selected list
        //        {
        //            if (Node.Text.Contains("- - -"))
        //            {
        //                Node.Text = Node.Text.Split('-')[0];
        //            }
        //        }
        //        e.Node.Text = e.Node.Text + " - - -"; // add - - - to the selected treenode text
        //        ShowCostumList();
        //    }
        //}

        //private void ShowCostumList()
        //{
        //    if (IsCostumListComplete())
        //    {
        //        List<FoundText> TempCostumList = new List<FoundText>();
        //        foreach (FoundText item in CostumList)
        //        {
        //            TempCostumList.Add(item);
        //        }
        //        ShowTextBox.Text = ConvertTextPiecesToShowText(TempCostumList);
        //    }
        //}

        //private Boolean IsCostumListComplete()
        //{
        //    foreach (FoundText item in CostumList)
        //    {
        //        if (item == null) // if any item is null then the costum list is not complete
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //private Boolean IsNodeAChild(TreeNode Node)
        //{
        //    try // this tests if the node has a parent
        //    {
        //        string Test = Node.Parent.Text;
        //        return true; // has parents
        //    }
        //    catch (Exception)
        //    {
        //        return false; // doesn't have parent
        //    }
        //}

        //private void SetupTreeView(List<List<FoundText>> ToShow, string NodeName)
        //{
        //    List<TreeNode> ListOfNodes = new List<TreeNode>();
        //    List<Tuple<string, List<string>>> Test = (from Item in ToShow
        //                                              orderby Item.Count descending
        //                                              select new Tuple<string, List<string>>(Item.Min(x => x.Texts.Count).ToString() + " par",
        //                                             (from Item2 in ToShow
        //                                              where Item2 == Item
        //                                              orderby Item2.Count descending
        //                                              from Item3 in Item2
        //                                              select Item3.Texts.Count().ToString()).ToList())).ToList();

        //    int TempIndex1 = 0;
        //    foreach (Tuple<string, List<string>> Item in Test) // adds the lists to the treenodes
        //    {
        //        List<TreeNode> Temp = (from Item1 in Item.Item2 select new TreeNode(Item1)).ToList(); // adds the individual list<string>s to the list the treenode 
        //        int TempIndex = 0;
        //        foreach (TreeNode Node1 in Temp) // adds an index to the name for easier tracking
        //        {
        //            Node1.Name = TempIndex.ToString();
        //            TempIndex++;
        //        }
        //        TreeNode TempNode = new TreeNode(Item.Item1, Temp.ToArray());
        //        TempNode.Name = TempIndex1.ToString();
        //        TempIndex1++;
        //        ListOfNodes.Add(TempNode);
        //    }
        //    TreeNode Node = new TreeNode(NodeName, ListOfNodes.ToArray());
        //    Node.ExpandAll();
        //    treeView1.Nodes.Add(Node);
        //}

        //private HtmlPattern MakeFullPattern()
        //{
        //    HtmlPattern NewPattern = new HtmlPattern();
        //    NewPattern.IsPrecise = true;
        //    foreach (var item in CurrentlyShownText)
        //    {
        //        NewPattern.GoBack.Add(item.PatternStart.Length);
        //        NewPattern.GoForward.Add(item.PatternEnd.Length);
        //        NewPattern.PatternStart.Add(item.PatternStart);
        //        NewPattern.PatternEnd.Add(item.PatternEnd);
        //    }
        //    return NewPattern;
        //}

        //private string ConvertTextPiecesToShowText(List<FoundText> ListWithTexts)
        //{
        //    CurrentlyShownText = ListWithTexts;
        //    StringBuilder TextToShow = new StringBuilder();
        //    StringBuilder StringToReplace;
        //    string TempText;
        //    int MakeNumberOfCards;

        //    if (Plate.UnlimitedCards && Plate.MaxCards > ListWithTexts.Max(x => x.Texts.Count) - 1)
        //    {
        //        MakeNumberOfCards = ListWithTexts.Max(x => x.Texts.Count) - 1;
        //    }
        //    else
        //    {
        //        MakeNumberOfCards = Plate.MaxCards - 1;
        //    }

        //    for (int Index = 0; Index <= MakeNumberOfCards; Index++)
        //    {
        //        TempText = Plate.Structure;
        //        for (int SecondIndex = 0; SecondIndex <= ListWithTexts.Count - 1; SecondIndex++) // goes through all the things that needs to be replaced
        //        {
        //            StringToReplace = new StringBuilder();
        //            StringToReplace.Append("{");
        //            StringToReplace.Append((SecondIndex + 1).ToString());
        //            StringToReplace.Append("}");
        //            if (ListWithTexts[SecondIndex].Texts.Count - 1 >= Index) // checks if there is a string in the list. if not then it will be blank
        //            {
        //                TempText = TempText.Replace(StringToReplace.ToString(), ListWithTexts[SecondIndex].Texts[Index]); // replaces the placeholder with the string
        //            }
        //            else
        //            {
        //                TempText = TempText.Replace(StringToReplace.ToString(), String.Empty);
        //            }
        //        }
        //        TextToShow.Append(TempText);
        //    }
        //    return TextToShow.ToString();
        //}

        //private void DeleteItemFromList(ref List<List<FoundText>> ToDeleteFrom)
        //{
        //    // removes the string from the list
        //    ToDeleteFrom[TreeIndexes[0]][TreeIndexes[1]].Texts.RemoveAt(ListBoxSelectedIndex);
        //    // removes the string from the listbox
        //    listBox1.Items.RemoveAt(ListBoxSelectedIndex);
        //    // updates the text in the treeview
        //    treeView1.Nodes[MainIndex].Nodes[TreeIndexes[0]].Nodes[TreeIndexes[1]].Text = listBox1.Items.Count.ToString();
        //    // updates the pair with the right amount of pairs
        //    treeView1.Nodes[MainIndex].Nodes[TreeIndexes[0]].Text = ToDeleteFrom[TreeIndexes[0]].Max(x => x.Texts.Count).ToString() + " Par";
        //    // update the text to save
        //    ShowTextBox.Text = ConvertTextPiecesToShowText(ToDeleteFrom[TreeIndexes[0]]);
        //}

        //private void DeleteItemFromListAll(ref List<List<FoundText>> ToDeleteFrom)
        //{
        //    ToDeleteFrom[TreeIndexes[0]][TreeIndexes[1]].Texts.RemoveAt(ListBoxSelectedIndex);
        //    listBox1.Items.RemoveAt(ListBoxSelectedIndex);
        //    string NodeText = listBox1.Items.Count.ToString();
        //    // this if keeps the selected icon if the node has it
        //    if (treeView1.Nodes[MainIndex].Nodes[TreeIndexes[0]].Nodes[TreeIndexes[1]].Text.Contains("- - -"))
        //    {
        //        NodeText += " - - -";
        //    }
        //    treeView1.Nodes[MainIndex].Nodes[TreeIndexes[0]].Nodes[TreeIndexes[1]].Text = NodeText;
        //    ShowCostumList();
        //}

        //private void AddItemToList(ref List<List<FoundText>> ToDeleteFrom)
        //{
        //    // adds an empty string to the list
        //    ToDeleteFrom[TreeIndexes[0]][TreeIndexes[1]].Texts.Insert(ListBoxSelectedIndex + 1, String.Empty);
        //    // adds the list to the listbox
        //    listBox1.Items.Insert(ListBoxSelectedIndex + 1, String.Empty);
        //    // updates the text in the treeview
        //    treeView1.Nodes[MainIndex].Nodes[TreeIndexes[0]].Nodes[TreeIndexes[1]].Text = listBox1.Items.Count.ToString();
        //    // updates the pair with the right amount of pairs
        //    treeView1.Nodes[MainIndex].Nodes[TreeIndexes[0]].Text = ToDeleteFrom[TreeIndexes[0]].Max(x => x.Texts.Count).ToString() + " Par";
        //    // update the text to save
        //    ShowTextBox.Text = ConvertTextPiecesToShowText(ToDeleteFrom[TreeIndexes[0]]);
        //}

        //private void AddItemToListAll(ref List<List<FoundText>> ToDeleteFrom)
        //{

        //    // adds an empty string to the list
        //    ToDeleteFrom[TreeIndexes[0]][TreeIndexes[1]].Texts.Insert(ListBoxSelectedIndex + 1, String.Empty);
        //    // adds the list to the listbox
        //    listBox1.Items.Insert(ListBoxSelectedIndex + 1, String.Empty);
        //    string NodeText = listBox1.Items.Count.ToString();
        //    // this if keeps the selected icon if the node has it
        //    if (treeView1.Nodes[MainIndex].Nodes[TreeIndexes[0]].Nodes[TreeIndexes[1]].Text.Contains("- - -"))
        //    {
        //        NodeText += " - - -";
        //    }
        //    treeView1.Nodes[MainIndex].Nodes[TreeIndexes[0]].Nodes[TreeIndexes[1]].Text = NodeText;
        //    ShowCostumList();
        //}

        //private void ChangeListboxSelectedIndex(int CurrentSelectedIndex)
        //{
        //    if (CurrentSelectedIndex <= listBox1.Items.Count - 1)
        //    {
        //        listBox1.SelectedIndex = CurrentSelectedIndex;
        //    }
        //    else if (CurrentSelectedIndex != 0)
        //    {
        //        listBox1.SelectedIndex = CurrentSelectedIndex - 1;
        //    }
        //    else if (listBox1.Items.Count != 0)
        //    {
        //        listBox1.SelectedIndex = 0;
        //    }
        //}




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (TreeIndexes.Count == 2 && listBox1.SelectedIndex != -1)
            //{
            //    ListBoxSelectedIndex = listBox1.SelectedIndex;
            //    textBox1.Text = listBox1.Items[ListBoxSelectedIndex].ToString();
            //}
        } // done

        private void textBox1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            //if (TreeIndexes.Count == 2 && ListBoxSelectedIndex != -1 && textBox1.IsKeyboardFocused == true)
            //{
            //    listBox1.Items[ListBoxSelectedIndex] = textBox1.Text;
            //    foreach (var TreeElement in TreeViewElements)
            //    {
            //        //if the TreeElement match the one there was clicked in
            //        if (TreeElement.ElementIndex == MainIndex)
            //        {
            //            TreeElement.ElementList[TreeIndexes[0]][TreeIndexes[1]].Texts[ListBoxSelectedIndex] = textBox1.Text;
            //            if (!TreeElement.IsLast)
            //            {
            //                ShowTextBox.Text = ConvertTextPiecesToShowText(TreeElement.ElementList[TreeIndexes[0]]);
            //            }
            //            else
            //            {
            //                ShowCostumList();
            //            }
            //        }
            //    }
            //}
        } // done

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            ////if a list was selected and an item in the listbox is selected
            //if (TreeIndexes.Count == 2 && ListBoxSelectedIndex != -1)
            //{
            //    //int CurrentSelectedIndex = listBox1.SelectedIndex;
            //    foreach (var TreeElement in TreeViewElements)
            //    {
            //        //if the TreeElement match the one there was clicked in
            //        if (TreeElement.ElementIndex == MainIndex)
            //        {
            //            //if the list isn't empty
            //            if (TreeElement.ElementList[TreeIndexes[0]][TreeIndexes[1]].Texts.Count != 0)
            //            {
            //                if (!TreeElement.IsLast)
            //                {
            //                    DeleteItemFromList(ref TreeElement.ElementList);
            //                }
            //                else
            //                {
            //                    DeleteItemFromListAll(ref TreeElement.ElementList);
            //                }
            //            }
            //        }
            //    }
            //    ChangeListboxSelectedIndex(ListBoxSelectedIndex);
            //}
        } // done

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            ////if a list was selected and an item in the listbox is selected
            //if (TreeIndexes.Count == 2 && ListBoxSelectedIndex != -1)
            //{
            //    //int CurrentSelectedIndex = listBox1.SelectedIndex;
            //    foreach (var TreeElement in TreeViewElements)
            //    {
            //        //if the TreeElement match the one there was clicked in
            //        if (TreeElement.ElementIndex == MainIndex)
            //        {
            //            if (!TreeElement.IsLast)
            //            {
            //                AddItemToList(ref TreeElement.ElementList);
            //            }
            //            else
            //            {
            //                AddItemToListAll(ref TreeElement.ElementList);
            //            }
            //        }
            //    }
            //}
        } // done

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            //string TextToSave = ShowTextBox.Text;
            //File.AppendAllText("HtmlLists.txt", TextToSave);
            //PatternControl.AddIfNew(MakeFullPattern());
        } // done

        //private void treeView1_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        //{
        //    //if (treeView1.SelectedNode != null && IsNodeAChild(e.Node))
        //    //{
        //    //    this.Index = e.Node.Index;

        //    //    foreach (var TreeElement in TreeViewElements)
        //    //    {
        //    //        if (!TreeElement.IsLast)
        //    //        {
        //    //            if (e.Node.Parent.Text == TreeElement.Name || IsNodeAChild(e.Node.Parent) && e.Node.Parent.Parent.Text == TreeElement.Name)
        //    //            {
        //    //                FindSelectedNode(e, ref TreeElement.ElementList, TreeElement.ElementIndex, TreeElement.Name);
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            if (IsNodeAChild(e.Node.Parent) && e.Node.Parent.Parent.Text == TreeElement.Name)
        //    //            {
        //    //                FindSelectedNodeAll(e, ref TreeElement.ElementList, TreeElement.ElementIndex);
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //} // done



        //private class TreeViewElement
        //{
        //    public readonly string Name;
        //    public List<List<FoundText>> ElementList;
        //    public readonly int ElementIndex;
        //    public readonly Boolean IsLast;

        //    public TreeViewElement(string name, List<List<FoundText>> elementlist, int elementindex, Boolean islast)
        //    {
        //        Name = name;
        //        ElementList = elementlist;
        //        ElementIndex = elementindex;
        //        IsLast = islast;
        //    }
        //}
    }
}
