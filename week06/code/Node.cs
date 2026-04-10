using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1


        while (!this.Contains(value))
        {
            if (value < Data)
            {
                // Insert to the left
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
            else
            {
                // Insert to the right
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }
        // Duplicate found, do nothing
        return;
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        int? curr = this.Data;

        while (curr != null)
        {
            if (curr == value)
            {
                return true;
            }
            else
            {
                // try the left side for posible matches
                // Debug.WriteLine($"curr={curr} / value={value} - try the left side for posible matches");
                if (Left != null && Left.Contains(value))
                {
                    return true;
                }

                // then try the right side for posible matches
                // Debug.WriteLine($"curr={curr} / value={value} - then try the right side for posible matches");
                if (Right != null && Right.Contains(value))
                {
                    return true;
                }

                return false;
            }
        }
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        int RightHeight = 0;
        int leftHeight = 0;

        if (Left is not null)
        {
            leftHeight = SubtreeHeight(this.Left, 0);
            // Debug.WriteLine($"==leftHeight:{leftHeight}==");
        }

        if (Right is not null)
        {
            RightHeight = SubtreeHeight(this.Right, 0);
            // Debug.WriteLine($"==RightHeight:{RightHeight}==");
        }

        if (leftHeight > RightHeight)
        {
            Debug.WriteLine("");
            // Debug.WriteLine($"=RESULT: return leftHeight({leftHeight})");
            return leftHeight;
        }
        else if (leftHeight < RightHeight)
        {
            Debug.WriteLine("");
            // Debug.WriteLine($"=RESULT: return RightHeight({RightHeight})");
            return RightHeight;
        }
        else
        {
            Debug.WriteLine("");
            // Debug.WriteLine($"=RESULT: return leftHeight({leftHeight})=");
            return leftHeight;
        }
    }

    // HELPER METHOD:
    public int SubtreeHeight(Node node, int counter)
    {
        while (node.Left != null || node.Right != null)
        {
            // try the left side for posible matches
            // Debug.WriteLine($"curr={node.Data} / counter={counter} - try the left side for posible matches");
            if (node.Left != null)
            {
                counter += SubtreeHeight(node.Left, counter);
            }

            // then try the right side for posible matches
            // Debug.WriteLine($"curr={node.Data} / counter={counter} - try the right side for posible matches");
            if (node.Right != null)
            {
                counter += SubtreeHeight(node.Right, counter);
            }

            // Debug.WriteLine($"curr={node.Data} / counter={counter} - INSIDE return counter;");
            return counter;
        }
        // Debug.WriteLine($"curr={node.Data} / counter={counter} - OUTSIDE return counter +1 ");
        return counter + 1;
    }
}