namespace VectorMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(0, 0);
            Vector vector2 = new Vector(0, 1);
            float angle = Vector.GetSignedAngleBetween(vector2, vector1, Vector.CartesianAxis.Z);
            
            float staticDistance = Vector.GetDistanceBetween(vector1, vector2);
            float nonstaticDistance = vector1.GetDistanceTo(vector2);

            try
            {
                vector1 = Vector.GetUnitVector(vector1);
            }
            catch (ArithmeticException _exception)
            {
                Console.WriteLine(_exception.Message);
                Console.WriteLine(_exception.StackTrace);
            }

            Console.WriteLine($"{staticDistance} & {nonstaticDistance}");

            Console.ReadKey();
        }
    }
}