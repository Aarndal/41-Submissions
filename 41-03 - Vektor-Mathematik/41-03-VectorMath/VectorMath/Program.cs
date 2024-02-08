namespace VectorMath
{
    internal class Program
    {
        static void Main()
        {
            Vector vector1 = new(1, 0, 1);
            Vector vector2 = new(0, 1, 1);

            float positiveAngle = Vector.GetSignedAngleBetween(vector1, vector2, Vector.CartesianAxis.ZAxis);
            float negativeAngle = Vector.GetSignedAngleBetween(vector2, vector1, Vector.CartesianAxis.ZAxis);

            Console.WriteLine($"{positiveAngle} & {negativeAngle}");

            Console.ReadKey();
        }
    }
}