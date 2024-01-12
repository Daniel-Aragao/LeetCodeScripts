/// <summary>
/// An image is represented by an m x n integer grid image where image[i][j] represents the pixel value of the image.
/// You are also given three integers sr, sc, and color. You should perform a flood fill on the image starting from the pixel image[sr][sc].
/// To perform a flood fill, consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color), and so on. Replace the color of all of the aforementioned pixels with color.
/// Return the modified image after performing the flood fill.
/// Input: image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, color = 2
/// Output: [[2,2,2],[2,2,0],[2,0,1]]
/// Explanation: From the center of the image with position (sr, sc) = (1, 1) (i.e., the red pixel), all pixels connected by a path of the same color as the starting pixel (i.e., the blue pixels) are colored with the new color.
/// Note the bottom corner is not colored 2, because it is not 4-directionally connected to the starting pixel.
/// </summary>
public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var stack = new Stack<(int, int)>();
        stack.Push((sr, sc));

        var stacked = new List<(int, int)>() { (sr, sc) };

        var floodColor = image[sr][sc];
        image[sr][sc] = color;

        while(stack.Count > 0)
        {
            var (i, j) = stack.Pop();

            var list = new List<(int, int)>()
            {
                (i - 1, j), // up
                (i + 1, j), // down
                (i, j + 1), // right
                (i, j - 1)  // left
            };

            list.ForEach(tuple => {
                var (i, j) = tuple;

                if(i >= 0 && j >= 0 && i < image.Count() && j < image[i].Count())
                {
                    if(image[i][j] == floodColor)
                    {
                        image[i][j] = color;
                        
                        if(!stacked.Any((tuple) => tuple.Item1 == i && tuple.Item2 == j))
                        {
                            stacked.Add((i, j));
                            stack.Push((i,j));
                        }
                    }
                }
            });
        }

        return image;
    }
}

public void printMatrix(int[][] matrix)
{
    var maxJ = 0;
    for(var i = 0; i < matrix.Count(); i++)
    {
        for(var j = 0; j < matrix.Count(); j++)
        {
            Console.Write(matrix[i][j].ToString() + " ");

            if(j > maxJ)
            {
                maxJ = j;
            }
        }

        Console.WriteLine();
    }

    Console.WriteLine(new string('-', 2 * maxJ + 1));
}

int[][] image = [[1,1,1],[1,1,0],[1,0,1]];
printMatrix(image);

var matrix = new Solution().FloodFill(image, 1, 1, 2);

printMatrix(matrix);

