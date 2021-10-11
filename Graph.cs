using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#nullable enable

namespace TaioProject
{
    public class Graph
    {
        private readonly bool[,] adjecencyMatrix;
        public int Size => adjecencyMatrix.GetLength(0);
        public Graph(bool[,] adjecencyMatrix)
        {
            this.adjecencyMatrix = adjecencyMatrix;
        }

        public static bool operator ==(Graph g1, Graph g2)
        {
            if (g1.Size != g2.Size)
            {
                return false;
            }
            int size = g1.Size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (g1.adjecencyMatrix[i, j] != g2.adjecencyMatrix[i, j])
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    sb.Append(adjecencyMatrix[i, j] ? "1" : "0");
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public static bool operator !=(Graph g1, Graph g2) => !(g1 == g2);
        public void SwapVertices(int v1, int v2)
        {
            if (v1 == v2
                || v1 < 0
                || v2 < 0
                || v1 > Size
                || v2 > Size)
                return;

            //swaps rows
            for (int i = 0; i < Size; i++)
            {
                (adjecencyMatrix[i, v1], adjecencyMatrix[i, v2]) = (adjecencyMatrix[i, v2], adjecencyMatrix[i, v1]);
            }

            //swaps columns
            for (int i = 0; i < Size; i++)
            {
                (adjecencyMatrix[v1, i], adjecencyMatrix[v2, i]) = (adjecencyMatrix[v2, i], adjecencyMatrix[v1, i]);
            }
        }

        private static bool[,] CopyArray(bool[,] matrix)
        {
            var newMatrix = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// This function is to show a linq way but is far less efficient
        /// From: StackOverflow user: Pengyang : http://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public Graph SwapVerticesCopy(int v1, int v2)
        {
            var newMatrix = CopyArray(adjecencyMatrix);

            //swaps rows
            for (int i = 0; i < Size; i++)
            {
                (newMatrix[i, v1], newMatrix[i, v2]) = (newMatrix[i, v2], newMatrix[i, v1]);
            }

            //swaps columns
            for (int i = 0; i < Size; i++)
            {
                (newMatrix[v1, i], newMatrix[v2, i]) = (newMatrix[v2, i], newMatrix[v1, i]);
            }
            return new Graph(newMatrix);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj switch
            {
                Graph g => g == this,
                _ => false
            };
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}