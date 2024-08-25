using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Task_3
{
    public class FamilyTree
    {
        public FamilyTreeNode Root { get; private set; }

        public FamilyTree(RoyalFamilyMember monarch)
        {
            Root = new FamilyTreeNode(monarch);
        }

        // Method to add a family member
        public void AddFamilyMember(RoyalFamilyMember parent, RoyalFamilyMember child)
        {
            var parentNode = FindNode(Root, parent);
            if (parentNode != null)
            {
                parentNode.AddChild(new FamilyTreeNode(child));
            }
        }

        private FamilyTreeNode FindNode(FamilyTreeNode node, RoyalFamilyMember member)
        {
            if (node.Member == member)
            {
                return node;
            }

            foreach (var child in node.Children)
            {
                var result = FindNode(child, member);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        public RoyalFamilyMember SearchMember(string name)
        {
            return SearchNode(Root, name)?.Member;
        }

        private FamilyTreeNode SearchNode(FamilyTreeNode node, string name)
        {
            if (node.Member.Name == name)
            {
                return node;
            }

            foreach (var child in node.Children)
            {
                var result = SearchNode(child, name);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
