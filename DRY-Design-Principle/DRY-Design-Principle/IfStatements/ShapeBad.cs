namespace DRY_Design_Principle.IfStatements
{
    public abstract class ShapeBad
    {
    }

    public class TriangleBad : ShapeBad
    {
        public int Base { get; set; }
        public int Height { get; set; }
    }

    public class RectangleBad : ShapeBad
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}