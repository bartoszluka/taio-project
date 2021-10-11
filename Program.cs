using System;

namespace TaioProject
{
    class Program
    {
        static void Main()
        {
            // var graph = new Graph(new bool[,]
            // {
            //     { false, true, true },
            //     { true, false, true },
            //     { true, true, false },
            // });

            var graph = new Graph(new bool[,]
            {
                { false, true, false },
                { true, false, false },
                { false, false, false },
            });

            Console.WriteLine(graph);
            graph.SwapVertices(2, 1);
            Console.WriteLine(graph);
        }
    }
}
