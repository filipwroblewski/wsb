//using MiniProjekt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    class BinarySearchTree<Key, Value> : IEnumerable<KeyValuePair<Key, Value>> where Key : IComparable<Key>
    {
        class Node
        {
            public Key Key;
            public Value Value;
            public Node Left, Right, Parent;

            //rekurencyjne przejscie po drzewie (lewa -> prawa)
            public IEnumerable<KeyValuePair<Key, Value>> Visit()
            {
                IEnumerable<KeyValuePair<Key, Value>> result = Enumerable.Empty<KeyValuePair<Key, Value>>();
                if (Left != null)
                {
                    result = result.Union(Left.Visit());
                }
                result = result.Union(new List<KeyValuePair<Key, Value>> { new KeyValuePair<Key, Value>(Key, Value) });
                if (Right != null)
                {
                    result = result.Union(Right.Visit());
                }
                return result;
            }

        }

        Node Root;

        private ref Node Find(Key key, ref Node parent)
        {
            if (Root == null || Root.Key.CompareTo(key) == 0)
            {
                parent = null;
                return ref Root;
            }
            parent = Root;
            while (parent.Key.CompareTo(key) != 0)
            {
                if (parent.Key.CompareTo(key) > 0)
                    if (parent.Left == null || parent.Left.Key.CompareTo(key) == 0)
                        return ref parent.Left;
                    else
                    {
                        parent = parent.Left;
                        continue;
                    }
                else
                {
                    if (parent.Right == null || parent.Right.Key.CompareTo(key) == 0)
                        return ref parent.Right;
                    else
                    {
                        parent = parent.Right;
                        continue;
                    }
                }
            }
            throw new Exception();  //UndefinedException();
        }

        public void Add(Key key, Value value)
        {
            Node parent = null;
            ref Node node = ref Find(key, ref parent);
            if (node == null)
            {
                node = new Node { Key = key, Value = value, Parent = parent };
                return;
            }
            throw new Exception();  //DuplicateKeyException();
        }

        public void Remove(Key key)
        {
            Node parent = null;
            ref Node node = ref Find(key, ref parent);
            if (node == null)
            {
                return;
            }
            if (node.Right == null && node.Left == null)
            {
                node = null;
                return;
            }
            if (node.Left != null && node.Right == null)
            {
                node.Left.Parent = node.Parent;
                node = node.Left;
                return;
                //node.Parent = parent;
            }
            if (node.Left == null && node.Right != null)
            {
                node.Right.Parent = node.Parent;
                node = node.Right;
                return;
            }
            if (node.Left != null && node.Right != null)
            {
                Node max = node.Left;
                while (max.Right != null)
                {
                    max = max.Right;
                }
                Remove(max.Key);
                node.Key = max.Key;
                node.Value = max.Value;
            }
        }

        public IEnumerator<KeyValuePair<Key, Value>> GetEnumerator()
        {
            if (Root == null)
            {
                return Enumerable.Empty<KeyValuePair<Key, Value>>().GetEnumerator();
            }
            return Root.Visit().GetEnumerator();
            //throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Value this[Key key]
        {
            get
            {
                Node parent = null;
                var node = Find(key, ref parent);
                if (node == null)
                {
                    throw new KeyNotFoundException();
                }
                return node.Value;
            }
            set
            {
                Node parent = null;
                var node = Find(key, ref parent);
                if (node == null)
                {
                    throw new KeyNotFoundException();
                }
                node.Value = value;
            }
        }
    }

    class SingleLinkedList<Key, Value> : IEnumerable<KeyValuePair<Key, Value>> where Key : IComparable<Key>
    {
        class Node
        {
            public Key Key;
            public Value Value;
            public Node Next;
        }

        Node Head;

        private ref Node Find(Key key)
        {
            if (Head == null || Head.Key.CompareTo(key) >= 0)
                return ref Head;
            Node buf = Head;
            while (buf.Next != null && buf.Next.Key.CompareTo(key) < 0)
                buf = buf.Next;
            return ref buf.Next;
        }

        public void Add(Key key, Value value)
        {
            ref Node node = ref Find(key);
            if (node == null)
            {
                node = new Node { Key = key, Value = value };
                return;
            }
            if (node.Key.CompareTo(key) == 0)
                throw new Exception();  //DuplicateKeyException();
            Node buffer = new Node { Key = key, Value = value, Next = node };
            node = buffer;
        }

        public IEnumerator<KeyValuePair<Key, Value>> GetEnumerator()
        {
            Node node = Head;
            while (node != null)
            {
                yield return new KeyValuePair<Key, Value>(node.Key, node.Value);
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Value this[Key key]
        {
            get
            {
                Node buf = Find(key);
                if (buf == null || buf.Key.CompareTo(key) != 0)
                    throw new KeyNotFoundException();
                return buf.Value;
            }
            set
            {
                Node buf = Find(key);
                if (buf == null || buf.Key.CompareTo(key) != 0)
                    throw new KeyNotFoundException();
                buf.Value = value;
            }
        }

        public void Remove(Key key)
        {
            ref Node buffer = ref Find(key);
            if (buffer == null || buffer.Key.CompareTo(key) != 0)
                return;
            buffer = buffer.Next;
        }
    }


    //dane losowe
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            BinarySearchTree<int, string> bst = new BinarySearchTree<int, string>();
            /*bst.Add(12, "abc");
            bst.Add(-1, "cde");
            bst.Add(-8, "cde");
            bst.Add(-9, "cde");
            bst.Add(18, "efg");
            bst.Add(19, "efg");
            bst.Add(17, "efg");
            bst.Remove(-1);*/

            int ile_elem = 5000;

            int[] daneWejsciowe = new int[ile_elem];
            Random gen = new Random();
            int n;
            bool flag;
            for (int i = 0; i < ile_elem; i++)
            {
                flag = true;
                while (flag)
                {
                    n = gen.Next(0, ile_elem * 2);

                    if (false == Array.Exists(daneWejsciowe, element => element == n))
                    {
                        daneWejsciowe[i] = n;
                        flag = false;
                    }
                }
            }
            /*
            foreach (var element in daneWejsciowe)
            {
                Console.WriteLine(element);
            }*/



            Console.WriteLine($"BST INSTANCJA: {ile_elem}");
            stopwatch.Start();
            foreach (var element in daneWejsciowe)
            {
                bst.Add(element, "abc");
            }
            stopwatch.Stop();
            Console.WriteLine($"Add {stopwatch.ElapsedMilliseconds} ms");

            string a;
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var element in daneWejsciowe)
            {
                a = bst[element];
            }
            stopwatch.Stop();
            Console.WriteLine($"dany elem  {stopwatch.ElapsedMilliseconds} ms");

            //stopwatch.Start();
            //bst.GetEnumerator();
            //stopwatch.Stop();
            //Console.WriteLine($"iteracja {stopwatch.ElapsedMilliseconds}ms");

            string b;
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var element in daneWejsciowe)
            {
                b = bst[element];
            }
            stopwatch.Stop();
            Console.WriteLine($"iteracja {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            foreach (var element in daneWejsciowe)
            {
                bst.Remove(element);
            }
            stopwatch.Stop();
            Console.WriteLine($"Remove all {stopwatch.ElapsedMilliseconds} ms");


            /*
            foreach (var element in bst)
            {
                Console.WriteLine($"{element.Key} {element.Value}");
            }
            */
            Console.WriteLine("\n\n");
            SingleLinkedList<int, string> sll = new SingleLinkedList<int, string>();

            int instancje_listy = ile_elem;
            Console.WriteLine($"SLL INSTANCJA: {instancje_listy}");
            stopwatch.Start();
            foreach (var element in daneWejsciowe)
            {
                sll.Add(element, "abc");
            }
            stopwatch.Stop();
            Console.WriteLine($"add  {stopwatch.ElapsedMilliseconds} ms");

            string la;
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var element in daneWejsciowe)
            {
                la = sll[element];
            }
            stopwatch.Stop();
            Console.WriteLine($"dany elem {stopwatch.ElapsedMilliseconds} ms");

            /*stopwatch.Reset();
            stopwatch.Start();
            sll.GetEnumerator();
            stopwatch.Stop();
            Console.WriteLine($"iteracja {stopwatch.ElapsedMilliseconds} ms");*/

            string lb;
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var element in daneWejsciowe)
            {
                lb = sll[element];
            }
            stopwatch.Stop();
            Console.WriteLine($"iteracja {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            foreach (var element in daneWejsciowe)
            {
                sll.Remove(element);
            }
            stopwatch.Stop();
            Console.WriteLine($"Remove all {stopwatch.ElapsedMilliseconds} ms");

            Console.WriteLine("\n\n");




            Console.ReadKey();
        }
    }
}
