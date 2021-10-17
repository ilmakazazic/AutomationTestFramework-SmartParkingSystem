
namespace SmartParkingSystem.Test.Helpers
{
    public class Random
    {
        public static int GetInteger(int upperBound)
        {
            var r = new System.Random();
            return r.Next(0, upperBound);
        }
    }
}
