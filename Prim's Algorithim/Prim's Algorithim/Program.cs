using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prim_s_Algorithim
{
    internal class Program
    {
        static void Main(string[] args)
        {

			int[,] graph = {
								{ 4, 1, 3, 2, 7 },
								{ 2, 0, 3, 8, 5 },
								{ 2, 3, 2, 0, 7 },
								{ 0, 5, 7, 9, 0 },
								{ 0, 2, 1, 4, 9 },
							};
			Prim(graph, 5);
			Console.ReadKey();
		}

		private static int MinKey(int[] key, bool[] set, int numberOfVertices)
		{
			// Setting all Nodes to Maximum Values
			int min = int.MaxValue, minIndex = 0;

			for (int v = 0; v < numberOfVertices; ++v)
			{
				if (set[v] == false && key[v] < min)
				{
					min = key[v];
					minIndex = v;
				}
			}

			return minIndex;
		}

		private static void displayResults(int[] parent, int[,] graph, int numberOfVertices)
		{
			Console.WriteLine("\t  Edge\t\t         Weight \n");
			// Number Of Edges in MST is : E = V - 1
			for (int i = 1; i < numberOfVertices; ++i)
				Console.WriteLine("from vertex {0} -  to vertex {1}  the Weight is  {2}", parent[i], i, graph[i, parent[i]]);
		}

		public static void Prim(int[,] graph, int numberOfVertices)
		{
			int[] parent = new int[numberOfVertices];
			int[] key = new int[numberOfVertices];
			bool[] mstSet = new bool[numberOfVertices];

			for (int i = 0; i < numberOfVertices; ++i)
			{
				key[i] = int.MaxValue;
				mstSet[i] = false;
			}

			key[0] = 0;
			parent[0] = -1;

			for (int count = 0; count < numberOfVertices - 1; ++count)
			{
				int u = MinKey(key, mstSet, numberOfVertices);
				mstSet[u] = true;

				for (int v = 0; v < numberOfVertices; ++v)
				{
				    // weight = 0 means vertex to itself which must be cancelled so we converted to bool
					if (Convert.ToBoolean(graph[u, v]) && mstSet[v] == false && graph[u, v] < key[v])
					{
						parent[v] = u;
						key[v] = graph[u, v];
					}
				}
			}
			displayResults(parent, graph, numberOfVertices);
		}
	}
}
