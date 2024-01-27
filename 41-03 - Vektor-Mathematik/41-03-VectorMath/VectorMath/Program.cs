namespace VectorMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(1, 0);
            Vector vector2 = new Vector(0, 1);
            float angle = Vector.GetAngleBetween(;

            //float staticAngle = Vector.GetSignedAngleBetween(vector1, vector2, Vector.CartesianAxis.Y);
            //float nonstaticAngle = vector1.GetSignedAngleTo(vector2);

            //try
            //{
            //    vector1 = Vector.GetUnitVector(vector1);
            //}
            //catch (ArithmeticException _exception)
            //{
            //    Console.WriteLine(_exception.Message);
            //    Console.WriteLine(_exception.StackTrace);
            //}

            //Console.WriteLine($"{staticAngle} & {nonstaticAngle}");

            Console.WriteLine(angle);

            Console.ReadKey();
        }
    }
}