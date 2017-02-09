namespace ExoPwAm
{
    public class OtherPricer : IPricer
    {
        public int Price(int superficie)
        {
            return superficie * 4;
        }
    }
}
