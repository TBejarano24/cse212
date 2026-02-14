using System.Diagnostics;

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
        if (value == Data)
        {
            return;
        }
        // TODO Start Problem 1

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

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        }
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = 1;
        int rightHeight = 1;

        if (Left is not null)
        {
            leftHeight += Left.GetHeight();
        }
        if (Right is not null)
        {
            rightHeight += Right.GetHeight();
        }

        if (leftHeight > rightHeight)
        {
            return leftHeight;
        }
        else
        {
            return rightHeight;
        }
        // Replace this line with the correct return statement(s)
    }
}