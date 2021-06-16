using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BoxData
{
    private double lenght;
    private double width;
    private double height;

    public BoxData(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;
    }
    private double Lenght
    {
        get
        {
            return this.lenght;
        }
        set
        {
            this.lenght = value;
            if (lenght <= 0)
            {
                throw new Exception("Value of lenght cannot be 0 or lower!");
            }
        }
    }

    private double Width
    {
        get
        {
            return width;
        }
        set
        {
            width = value;
            if (width <= 0)
            {
                //Console.WriteLine("aaaaa");
                throw new Exception("Value of width cannot be 0 or lower!");
            }
        }
    }

    private double Height
    {
        get
        {
            return height;
        }
        set
        {
            height = value;
            if (height <= 0)
            {
                throw new Exception("Value of height cannot be 0 or lower!");
            }
        }
    }

    public double surfaceArea()
    {
        return (2 * lenght * width) + (2 * lenght * height) + (2 * width * height);
    }

    public double lateralSurfaceArea()
    {
        return (2 * lenght * height) + (2 * width * height);
    }

    public double volume()
    {
        return lenght * width * height;
    }

}

class MainClass
{
    public static void Main()
    {
        double lenght = int.Parse(Console.ReadLine());
        double width = int.Parse(Console.ReadLine());
        double height = int.Parse(Console.ReadLine());
        BoxData box = new BoxData(lenght, width, height);
        Console.WriteLine("Surface Area - " + String.Format("{0:0.00}", box.surfaceArea()));
        Console.WriteLine("Lateral Surface Area - " + String.Format("{0:0.00}", box.lateralSurfaceArea()));
        Console.WriteLine("Volume - " + String.Format("{0:0.00}", box.volume()));
    }
}
