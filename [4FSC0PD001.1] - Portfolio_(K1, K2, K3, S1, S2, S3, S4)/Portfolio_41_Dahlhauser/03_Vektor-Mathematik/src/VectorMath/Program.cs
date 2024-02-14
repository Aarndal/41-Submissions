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

            Vector vector3 = new(1, 0);
            Vector vector4 = new(-1, 1);

            Console.WriteLine($"{vector3.GetAngleTo(vector4)}");

            Console.WriteLine($"{positiveAngle} & {negativeAngle}");

            Console.ReadKey();
        }
    }
}