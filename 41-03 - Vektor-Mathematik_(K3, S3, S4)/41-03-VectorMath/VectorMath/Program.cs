namespace VectorMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(1, 0);
            Vector vector2 = new Vector(0, 1);
            float angle = Vector.GetSignedAngleBetween(vector2, vector1, Vector.CartesianAxis.Z);


            Console.WriteLine($"{angle}");
        }
    }
}