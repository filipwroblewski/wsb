using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K27Graphs
{
    interface GraphR    //implementacja metody
    {
        int Order();    //okreslenie rzedu grafu
        void AddEdge(int v, int u);     //dodawanie krawedzi
        bool HasEdge(int v, int u);     //test czy krawedz jest w grafie
        IEnumerable<int> Successors(int v);   //iteracja po wszystkich następnikach  danego wieszcholka
    }

    class AdjacencyMatrix : GraphR  //macierz sasiedztwa
    {
        private int[,] matrix;  //fizyczna reprezentacja grafu
        public AdjacencyMatrix(int order)   //inicjalizacja, przyjmuje rzad grafu
        {
            matrix = new int[order, order]; //inicjalizacja macierzy - wypelnienie jej zerami
        }

        public void AddEdge(int v, int u)   //dodawanie krawędzi
        {
            matrix[v, u] = 1;
            matrix[u, v] = -1;
            //te zapisy umozliwiaja polaczenie pomiedzy wieszcholkami w ramach tej reprezentacji
        }

        public bool HasEdge(int v, int u)   //czy wystepuje powiązanie pomiędzy wieszcholkami
        {
            return matrix[v, u] == 1;   //jezeli jest 1 to oznacza ze mamy krawedz pomiedzy wieszcholkiem v, a wieszcholkiem u
        }

        public int Order()  //rzad grafu
        {
            return matrix.GetLength(0); //zwraca rozmiar ktoregos z wymiarow macierzy
        }

        public IEnumerable<int> Successors(int v)
        {
            List<int> successors = new List<int>();     // lista następników danego wieszcholka
            for (int u = 0; u < matrix.GetLength(0); u++)   //iteracja po wszystkich mozliwych nastepnikach
            {
                if (matrix[v, u] == 1)
                {
                    successors.Add(u);
                }
            }
            return successors;
        }
    }

    class IncidenceMatrix : GraphR  //macierz incydencji
    {
        List<int[]> matrix = new List<int[]>(); //informacje o pojedynczych krawedziach
        int order;
        public IncidenceMatrix(int order)   //inicjalizacja, przyjmuje rzad grafu
        {
            this.order = order;
        }

        public void AddEdge(int v, int u)   //dodanie pojedynczej krawedzi
        {
            int[] edge = new int[order];
            edge[v] = 1;
            edge[u] = -1;
            matrix.Add(edge);
        }

        public bool HasEdge(int v, int u) //weryfikacja czy mamy krawedz pomiedzy wieszcholkami v i u
        {
            foreach (var edge in matrix)    //itearcja po wszystkich krawedziach
            {
                if (edge[v] == 1 && edge[u] == -1)
                    return true;
            }
            return false;
        }

        public int Order()  //rzad grafu
        {
            return order;
        }

        public IEnumerable<int> Successors(int v)
        {
            List<int> successors = new List<int>();
            foreach (var edge in matrix)
            {
                if (edge[v] == 1)
                {
                    for (int u = 0; u < edge.Length; u++)
                    {
                        if (edge[u] == -1)
                        {
                            successors.Add(u);
                        }
                    }
                }
            }
            return successors;
        }
    }

    class EdgeList : GraphR // lista krawedzi
    {
        // 1->2->3  [(1,2), (2,3)]
        class Edge
        {
            public int pred;
            public int succ;
        }
        LinkedList<Edge> edges = new LinkedList<Edge>();
        int order;

        public EdgeList(int order)
        {
            this.order = order;
        }

        public void AddEdge(int v, int u)
        {
            edges.AddLast(new Edge { pred = v, succ = u });
        }

        public bool HasEdge(int v, int u)
        {
            foreach (var edge in edges)
            {
                if (v == edge.pred && u == edge.succ)
                {
                    return true;
                }
            }
            return false;
        }

        public int Order()
        {
            return order;
        }

        public IEnumerable<int> Successors(int v)
        {
            LinkedList<int> successors = new LinkedList<int>();
            foreach (var edge in edges)
            {
                if (edge.pred == v)
                {
                    successors.AddLast(edge.succ);
                }
            }
            return successors;
        }
    }

    class IncidenceLists : GraphR
    {
        LinkedList<int>[] successors;

        public IncidenceLists(int order)
        {
            successors = new LinkedList<int>[order];
            for (int i = 0; i < order; i++)
            {
                successors[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int v, int u)
        {
            successors[v].AddLast(u);
        }

        public bool HasEdge(int v, int u)
        {
            foreach (var succ in successors[v])
            {
                if (succ == u)
                {
                    return true;
                }
            }
            return false;
        }

        public int Order()
        {
            return successors.Length;
        }

        public IEnumerable<int> Successors(int v)
        {
            return successors[v];
        }
    }

    class ForwardStar : GraphR
    {
        SortedSet<int>[] successors;

        public ForwardStar(int order)
        {
            successors = new SortedSet<int>[order];
            for (int i = 0; i < order; i++)
            {
                successors[i] = new SortedSet<int>();
            }
        }

        public void AddEdge(int v, int u)
        {
            successors[v].Add(u);
        }

        public bool HasEdge(int v, int u)
        {
            return successors[v].Contains(u);
        }

        public int Order()
        {
            return successors.Length;
        }

        public IEnumerable<int> Successors(int v)
        {
            return successors[v];
        }
    }

    class Algorithms
    {
        public static void DFS(GraphR g)
        {
            SortedSet<int> unvisted = new SortedSet<int>();
            for (int v = 0; v < g.Order(); v++)
            {
                unvisted.Add(v);
            }
            while (unvisted.Count != 0)
            {
                DFSVisit(unvisted, g, unvisted.Min);
            }
        }

        private static void DFSVisit(SortedSet<int> unvisted, GraphR g, int v)
        {
            if (!unvisted.Contains(v))
                return;
            Console.WriteLine(v);
            unvisted.Remove(v);
            foreach (var succ in g.Successors(v))
            {
                DFSVisit(unvisted, g, succ);
            }
        }

        public static void BFS(GraphR g)
        {
            SortedSet<int> unvisted = new SortedSet<int>();
            for (int v = 0; v < g.Order(); v++)
            {
                unvisted.Add(v);
            }
            Queue<int> queue = new Queue<int>();
            while (unvisted.Count != 0)
            {
                queue.Enqueue(unvisted.Min);
                while (queue.Count != 0)
                {
                    int v = queue.Dequeue();
                    if (!unvisted.Contains(v))
                        continue;
                    Console.WriteLine(v);
                    unvisted.Remove(v);
                    foreach (var succ in g.Successors(v))
                    {
                        queue.Enqueue(succ);
                    }
                }
            }
        }
    }

    class KahnTopSort : ITopologicalSort
    {
        GraphR g;

        public void SetGraph(GraphR g)  //przekazanie grafu do posortowania
        {
            this.g = g;
        }

        public IEnumerable<int> GetOrder()  //rozwiozanie: kolejnosc wiecholków (kazdy element jest zalezny co najwyzej od poprzedniego elementu)
        {
            List<int> result = new List<int>(); // przechowanie rozwiązania
            int[] pred = new int[g.Order()];    // info o poprzednikach wieszcholka, jesli pred=0 to znaczy ze wieszcholek jest niezalezny
            Queue<int> q = new Queue<int>();       // zbior niezaleznych elementow
            for (int v = 0; v != g.Order(); v++)    //iteracja po all krawedziach grafu
            {
                foreach (var u in g.Successors(v))  // sprawdzenie all nastepnikow wieszcholka
                {
                    pred[u]++;  //zwiekszenie liczby poprzedzajacej dany wieszcholek
                }
            }
            //sprawdzenie niezaleznych elementow
            for (int v = 0; v != g.Order(); v++)
            {
                if (pred[v] == 0) // jesli nie ma poprzednikow to wieszcholek jest niezalezny
                {
                    q.Enqueue(v);   //dodanie do niezaleznych elementow
                }
            }
            while (q.Count != 0)    //dopoki kolejka posiada jakies elementy
            {
                int v = q.Dequeue();   // ununiecie  pojedynczego, niezaleznego elementu
                result.Add(v);  //dodanie elementu na koniec do wyniku
                foreach (var u in g.Successors(v))  //iteracja w celu usuniecie zaleznosci wieszcholka
                {
                    pred[u]--;  // usuniecie zaleznosci wieszcholka
                    if (pred[u] == 0)   // skoro jest niezalezny to...
                    {
                        q.Enqueue(u);   //...mozna go dodac do niezaleznych wieszcholkow
                    }
                }
            }
            //graf cykliczny nie moze zostac posortowany topologicznie
            if (result.Count != g.Order())  //jezeli po usunieciu wieszcholka powstanie cykl w grafie
                throw new Exception();//CycleFoundException
            return result;
        }
    }
    
        class DFSTopSort : ITopologicalSort
        {
            enum Color  //dozwolone kolory do kolorowania
            {
                GREY,
                BLACK
            }

            GraphR g;
            Stack<int> result;  //rozwiazanie, stos bo uzupelniamy od ostatniego i konczymy na 1st elemencie
            SortedSet<int> unpainted;   //niepolanowane wieszcholki
            SortedDictionary<int, Color> painted;   //pomalowane wieszcholki

            public IEnumerable<int> GetOrder()  //implementacja algorytmu
            {
                //deklaracje wszystkich kolekcji
                result = new Stack<int>();
                unpainted = new SortedSet<int>();   // trzeba wypelnic kolekcje nieposortowanych wieszcholkow
                painted = new SortedDictionary<int, Color>();

                for (int v = 0; v != g.Order(); v++)    //iterazja po all wieszcholkach
                {
                    unpainted.Add(v);   //dodanie wszystkich wieszcholkow
                }
                //jezeli jakis wieszcholek jest niepomalowany to znaczy ze jest jeszcze nieodwiedzony
                while (unpainted.Count != 0)
                {
                    Visit(unpainted.Min);//odwiedzamy niepomalowany wieszcholek
                }
                return result;
            }

            private void Visit(int v)
            {
                if (painted.ContainsKey(v)) //sprawdzenie czy wieszcholek jest pomalowany
                {
                    if (painted[v] == Color.BLACK)//jesli pomalowany na blk to znaczy ze juz byl wiele razy zalezny od innych wieszcholkow
                    {
                        return;
                    }
                    // if (painted[v] == Color.GREY) 
                    throw new Exception();//CycleFoundException();  znaleziono cykl
                }
                painted.Add(v, Color.GREY);
                unpainted.Remove(v);
                foreach (var u in g.Successors(v))//wizytacja all sasiadow wieszcholka
                {
                    Visit(u);
                }
                //skoro odwiedzamy jego wieszcholki to znaczy ze jest on najbardziej zalezny z tych ktore mamy 
                result.Push(v);//wiec go dodajemy do rozwiazania
                painted[v] = Color.BLACK;
            }

            public void SetGraph(GraphR g)
            {
                this.g = g;
            }
        }

        class GraphManager  //generowanie grafu losowego, acyklicznego
        {
            class Edge
            {
                public int v;
                public int u;
            }
            static void Shuffle(List<Edge> edges)   //potasowanie listy
            {
                Random random = new Random();
                for (int i = 0; i < edges.Count - 1; i++)
                {
                    int j = random.Next(i + 1, edges.Count - 1);//wygenerowanie nowych wartosci
                    (edges[i], edges[j]) = (edges[j], edges[i]);//zamiana elementow z nowo-wygenerowanymi
                }
            }

            //generowanie grafu (rzad, nasycenie)
            public static GraphR GenerateGraph<GraphType>(int order, int saturation) where GraphType : GraphR
            {
                GraphR g = (GraphType)Activator.CreateInstance(typeof(GraphType), order);   //utworzenie grafu, zeby user nie musial tworzyc samemu instancji grafu
                List<Edge> edges = new List<Edge>();
                //jesli bedzie generowac krawedzie od wiescholka mniejszego do wiekszego nie bedzie cyklu
                //tworzenie maxymalnego grafu acyklicznego
                for (int v = 0; v < order; v++)
                {
                    for (int u = v + 1; u < order; u++)
                    {
                        edges.Add(new Edge { v = v, u = u });
                    }
                }
                Shuffle(edges);     // nadanie losowosci
                int m = order * (order - 1) / 2 * saturation / 100; //maxymalna liczba krawedzi bez cyklu * % nasycenia
                for (int e = 0; e < m; e++)
                {
                    g.AddEdge(edges[e].v, edges[e].u);  //dodalnie all krawedzi do grafu
                }
                return g;   //zwrocenie grafu
            }

            public static void SaveGraph(GraphR g, string path) //zapis grafu do pliku
            {
                StreamWriter writer = new StreamWriter(path);
                writer.WriteLine(g.Order());    // wypisanie rzedu
                for (int v = 0; v < g.Order(); v++) //iteracja po all wieszcholkach
                {
                    foreach (var u in g.Successors(v))  // iteracja po all nastepnikach
                    {
                        writer.WriteLine($"{v} {u}");   //wypisanie wieszcholkow
                    }
                }
                writer.Close();
            }

            public static GraphR LoadGraph<GraphType>(string path) where GraphType : GraphR //wczytanie danych z pliku
            {
                StreamReader reader = new StreamReader(path);
                int order = int.Parse(reader.ReadLine());
                GraphR g = (GraphType)Activator.CreateInstance(typeof(GraphType), order);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] vs = line.Split(' ');  //podzielenie po znakach spacji
                    int v = int.Parse(vs[0]);
                    int u = int.Parse(vs[1]);
                    g.AddEdge(v, u);    // dodanie elementow jako poprzednika i nastepnika
                }
                return g;
            }
        }

    class Program
    {


        static void Main(string[] args)
        {
            //reprezentacje start
            /*GraphR g = new AdjacencyMatrix(6);

            g.AddEdge(0, 4);
            g.AddEdge(0, 1);
            g.AddEdge(1, 5);
            g.AddEdge(3, 4);
            g.AddEdge(4, 5);

            foreach (var succ in g.Successors(0))
            {
                Console.WriteLine(succ);
            }*/
            //reprezentacje end

            //sortowanie topologiczne start
            /*GraphR g = new ForwardStar(6);

            g.AddEdge(0, 4);
            g.AddEdge(0, 1);
            g.AddEdge(1, 5);
            g.AddEdge(3, 4);
            g.AddEdge(4, 5);
            //g.AddEdge(5, 0);

            ITopologicalSort topsort = new DFSTopSort();
            topsort.SetGraph(g);
            foreach (var v in topsort.GetOrder())
            {
                Console.WriteLine(v);
            }*/
            //sortowanie topologiczne end

            //generowanie grafu start
            GraphR g = GraphManager.GenerateGraph<ForwardStar>(10, 50); //wielkosc 10, wypelnienie w 50%
            GraphManager.SaveGraph(g, "graf1.txt");

            //GraphR g = GraphManager.LoadGraph<ForwardStar>("graf1.txt");  //ladowanie grafu z pliku

            //Algorithms.BFS(g);
            ITopologicalSort topsort = new DFSTopSort();
            topsort.SetGraph(g);
            foreach (var v in topsort.GetOrder())
            {
                Console.WriteLine(v);
            }

            Console.ReadKey();

        }
    }
}
