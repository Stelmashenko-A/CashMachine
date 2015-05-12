namespace ATM.Input
{//csv

    public interface IReader<out TOut>
    {
        TOut Read(string fileName);
    }
}
