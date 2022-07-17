using System;

namespace Is_Graph_Bipartite
{
  class Program
  {
    static void Main(string[] args)
    {
      var graph = new int[4][] { new int[] { 1, 3 }, new int[] { 0 , 2 },
      new int[] { 1, 3 }, new int[] { 0, 2 }};
      Solution s = new Solution();
      var answer =  s.IsBipartite(graph);
      Console.WriteLine(answer);
    }
  }

  // Time = O(V + e)
  // Space = O(V)
  public class Solution
  {
    // colors
    // 0 - no color
    // 1 - blue
    // -1 - red
    public bool IsBipartite(int[][] graph)
    {
      int row = graph.Length;
      int[] color = new int[row];

      // loop through for each node and color the current node as blue(1) and neighbours as red(-1)
      for (int i = 0; i < row; i++)
      {
        if (color[i] == 0 && !IsValid_DFS(graph, 1, color, i)) return false;
      }
      return true;
    }

    private bool IsValid_DFS(int[][] graph, int currentColor, int[] color, int currentNode)
    {
      if (color[currentNode] != 0)
        return color[currentNode] == currentColor;
      color[currentNode] = currentColor;
      foreach (int n in graph[currentNode])
      {
        // neighbours colored as currentcolor * -1
        if (!IsValid_DFS(graph, -currentColor, color, n)) return false;
      }
      return true;
    }
  }
}
