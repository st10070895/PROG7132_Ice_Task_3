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
        private Tree<string> familyTree;

        public MainWindow()
        {
            InitializeComponent();
            InitializeFamilyTree();
            PopulateTreeView();
        }

        private void InitializeFamilyTree()
        {
            // Initialize the royal family tree
            familyTree = new Tree<string>();
            familyTree.Root = new TreeNode<string>() { Data = "Queen Elizabeth II" };

            // Add children of Queen Elizabeth II
            familyTree.Root.Children = new List<TreeNode<string>>
            {
                new TreeNode<string>() { Data = "Charles, Prince of Wales", Parent = familyTree.Root },
                new TreeNode<string>() { Data = "Anne, Princess Royal", Parent = familyTree.Root },
                new TreeNode<string>() { Data = "Prince Andrew, Duke of York", Parent = familyTree.Root },
                new TreeNode<string>() { Data = "Prince Edward, Earl of Wessex", Parent = familyTree.Root }
            };

            // Add children of Charles
            familyTree.Root.Children[0].Children = new List<TreeNode<string>>()
            {
                new TreeNode<string> { Data = "Prince William, Duke of Cambridge", Parent = familyTree.Root.Children[0] },
                new TreeNode<string> { Data = "Prince Harry, Duke of Sussex", Parent = familyTree.Root.Children[0] }
            };
        }

        private void PopulateTreeView()
        {
            if (familyTree.Root != null)
            {
                TreeViewItem rootItem = new TreeViewItem { Header = familyTree.Root.Data };
                FamilyTreeView.Items.Add(rootItem);
                AddTreeItems(rootItem, familyTree.Root);
            }
        }

        private void AddTreeItems(TreeViewItem parentItem, TreeNode<string> parentNode)
        {
            foreach (var child in parentNode.Children)
            {
                TreeViewItem childItem = new TreeViewItem { Header = child.Data };
                parentItem.Items.Add(childItem);
                AddTreeItems(childItem, child);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = SearchBox.Text;
            TreeNode<string> foundNode = familyTree.FindNode(familyTree.Root, searchQuery);

            if (foundNode != null)
            {
                SearchResult.Text = $"{foundNode.Data} found in the tree!";
            }
            else
            {
                SearchResult.Text = $"{searchQuery} not found.";
            }
        }
    }
}