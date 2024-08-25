using System.DirectoryServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ice_Task_3
{
    public partial class MainWindow : Window
    {
        private FamilyTree _familyTree;

        public MainWindow()
        {
            InitializeComponent();

            // Example initialization with the monarch
            var monarch = new RoyalFamilyMember("Queen Elizabeth II", new DateTime(1926, 4, 21), true);
            _familyTree = new FamilyTree(monarch);

            // Adding example family members
            var princeCharles = new RoyalFamilyMember("Prince Charles", new DateTime(1948, 11, 14), true);
            _familyTree.AddFamilyMember(monarch, princeCharles);

            // More family members can be added here...

            // Display the family tree
            DisplayFamilyTree(_familyTree.Root);
        }

        private void DisplayFamilyTree(FamilyTreeNode rootNode)
        {
            FamilyTreeView.Items.Clear();
            var rootItem = new TreeViewItem { Header = rootNode.Member.Name };
            FamilyTreeView.Items.Add(rootItem);

            foreach (var child in rootNode.Children)
            {
                AddNodes(rootItem, child);
            }
        }

        private void AddNodes(TreeViewItem parentItem, FamilyTreeNode node)
        {
            var treeViewItem = new TreeViewItem { Header = node.Member.Name };
            parentItem.Items.Add(treeViewItem);

            foreach (var child in node.Children)
            {
                AddNodes(treeViewItem, child);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var name = SearchBox.Text;
            var member = _familyTree.SearchMember(name);

            if (member != null)
            {
                SearchResult.Text = $"Found: {member.Name}, Born: {member.DateOfBirth.ToShortDateString()}, Alive: {member.IsAlive}";
            }
            else
            {
                SearchResult.Text = "Member not found.";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var name = AddNameBox.Text;
            var dob = AddDOBPicker.SelectedDate ?? DateTime.Now;
            var isAlive = AddAliveCheckBox.IsChecked == true;

            var newMember = new RoyalFamilyMember(name, dob, isAlive);
            // Adding the new member under the monarch for simplicity
            _familyTree.AddFamilyMember(_familyTree.Root.Member, newMember);

            // Refresh the family tree display
            DisplayFamilyTree(_familyTree.Root);
        }
    }
}