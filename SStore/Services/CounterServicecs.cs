namespace SStore.Services
{
    public interface ICounterServicecs
    {
        int Increment(int num);
        int Decrement(int num);
    }
    public class CounterServicecs : ICounterServicecs
    {
        public int Increment(int num)
        {
            num++;
            return num;
        }

        public int Decrement(int num)
        {
            num--;
            return num;
        }




    }

}

