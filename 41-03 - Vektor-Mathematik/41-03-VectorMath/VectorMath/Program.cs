namespace VectorMath
{
    internal class Program
    {
        static void Main()
        {
            Vector vector1 = new(1, 0);
            Vector vector2 = new(0, 1);

            float staticAngle = Vector.GetSignedAngleBetween(vector1, vector2, Vector.CartesianAxis.YAxis);
            float nonstaticAngle = vector1.GetSignedAngleTo(vector2);

            try
            {
                vector1 = Vector.GetUnitVector(vector1);
            }
            catch (ArithmeticException _exception)
            {
                Console.WriteLine(_exception.Message);
                Console.WriteLine(_exception.StackTrace);
            }

            Console.WriteLine($"{staticAngle} & {nonstaticAngle}");

            Console.ReadKey();
        }
    }
}