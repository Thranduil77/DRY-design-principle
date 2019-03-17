namespace DRY_Design_Principle.IfStatements
{
    #region Using

    #endregion

    public abstract class ShapeGood
    {
        public abstract double CalculateAreaGood();
    }

    public class TriangleGood : ShapeGood
    {
        public int Base { get; set; }
        public int Height { get; set; }

        #region Overrides of ShapeGood

        public override double CalculateAreaGood()
        {
            return Base * Height / 2;
        }

        #endregion
    }

    public class RectangleGood : ShapeGood
    {
        public int Width { get; set; }
        public int Height { get; set; }

        #region Overrides of ShapeGood

        public override double CalculateAreaGood()
        {
            return Width * Height;
        }

        #endregion
    }
}