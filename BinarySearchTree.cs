using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Node
    {
        public int  Key;
        public Node left;
        public Node right;
        public Node parent;
        public Node node;
        public int  count;

        public Node()
        {

        }
        public Node(int val,Node node)
        {
            Key = val;
            count = 1;
            parent = node;

        }
        public void Insert(int val)
        {
            if (val == Key)
            {
                count++;
            }
            else if (val > Key)
            {
                node = this;
                if (right == null)
                {
                    right = new Node(val, node);
                }

                else
                {
                    right.Insert(val);
                }
            }
            else
            {
                node = this;
                if (left == null)
                    left = new Node(val,node);
                else
                {
                    node = this;
                    left.Insert(val);
                }
            }

        }
        public void inorder(Node root)
        {
            if (root != null)
            {
                inorder(root.left);
                Console.Write(root.Key + " ");
                inorder(root.right);
            }
            
        }

        public void postorder(Node root)
        {
            if (root != null)
            {
                postorder(root.left);
                postorder(root.right);
                Console.Write(root.Key + " ");
            }
        }

        public Node find(Node root, int val)
        {
            if (root == null)
            {
                return root;
            }
            if (root.Key == val)
            {
                return root;
            }
            if (val < root.Key)
            {
                return find(root.left, val);
            }
            else
            {
                return find(root.right, val);
            }


        }

        public int FindMin()
        {

            if(left==null)
            {
                int x = Key;
                return x;
            }
            return left.FindMin();
        }

        public int FindMax()
        {
            if(right==null)
            {
                int x = Key;
                return x;
            }
            return right.FindMax();
        }
    }

    class BinaryTree
    {
        public Node root;
        // Insert new element in tree 
        public void insert(int val)
        {
            if (root != null)
                root.Insert(val);
            else
                root = new Node(val, null);
        }
        // Inorder Traverse
        public void Inorder()
        {
            if (root != null)
            {
                root.inorder(root);
                Console.WriteLine();
            }
        }
        // postorder Traverse
        public void Postorder()
        {
            root.postorder(root);
            Console.WriteLine();
        }
        // search for element and return True if found else return false 
        public Node Find(int val)
        {
            return root.find(root, val);
        }
        //Find minimum value in the tree
        public int Min()
        {
            return root.FindMin();
        }
        //Find maximum value in the tree
        public int Max()
        {
            return root.FindMax();
        }
        //Find The Successor value of node 
        public Node GetSuccessor(Node node)
        {
            Node parentOfSuccessor = node;
            Node successor = node;
            Node current = node.right;
            if (current != null)
            {
                // get the min value of the right sub tree
                while (current != null)
                {
                    parentOfSuccessor = successor;
                    successor = current;
                    current = current.left;
                }
                //  Console.WriteLine(successor.Key);
                return successor;
            }
            parentOfSuccessor = node.parent;
            while (parentOfSuccessor != null && node == parentOfSuccessor.right)
            {
                node = parentOfSuccessor;
                parentOfSuccessor = parentOfSuccessor.parent;
            }
            //  Console.WriteLine(parentOfSuccessor.Key);
            return parentOfSuccessor;
        }

        public void Delete(int val)
        {
            Node node;
            node = root.find(root, val);
            if (node == null)
                return;
            // in case  the node to be deleted is a leaf node
            if (node.right == null && node.left == null)
            {
                if (node != root)
                {
                    if (node == node.parent.left)
                        node.parent.left = null;
                    else
                        node.parent.right = null;
                }
                else
                    root = null;
            }
            // in case  the node to be deleted has two children 
            else if (node.right !=null && node.left !=null)
            {
                Node successor = GetSuccessor(node);
                int data = successor.Key;
                int cnt = successor.count;
                Delete(data);
                node.Key = data;
                node.count = cnt;
            }
            // in case node has only one child 
            else
            {
                if (node != root)
                {
                    if (node.left == null && node.right != null)
                    {
                        node.right.parent = node.parent;
                        node.parent.right = node.right;
                    }
                    else
                    {
                        node.left.parent = node.parent;
                        node.parent.left = node.left;
                    }
                }
                else
                {
                    Node child = (node.left != null) ? node.left : node.right;
                    root = child;
                }
            }

        }

    }
   
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree b = new BinaryTree();
            b.insert(8);
            b.insert(10);
            b.insert(10);
            //b.insert(15);
            //b.insert(11);
            //b.insert(9);
            //b.insert(26);
            b.insert(4);
            //b.insert(6);
            //b.insert(2);
            //b.insert(2);

            b.Inorder();
            b.Postorder();
            //Console.WriteLine(b.Min());
            //Console.WriteLine(b.Max());
            b.Delete(99);

            b.Inorder();
        }
    }
}
