namespace _01.ClassBoxData;

public class Box
{
    private double length;
    private double width;
    private double height;
    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get
        {
            return length;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length cannot be zero or negative.");
            }
            length = value;
        }
    }
    public double Width
    {
        get
        {
            return width;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative.");
            }
            width = value;
        }
    }
    public double Height
    {
        get
        {
            return height;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative.");
            }
            height = value;
        }
    }
    public double Surface()
        => 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
    public double LateralSurfaceArea()
        => 2 * Length * Height + 2 * Width * Height;
    public double Volume()
        => Length * Width * Height;

    public override string ToString()
    {
        return $"Surface Area - {Surface():F2}\n" +
            $"Lateral Surface Area - {LateralSurfaceArea():F2}\n" +
            $"Volume - {Volume():F2}";
    }
}
