namespace ATM
{
    interface IReader<in TIn, out TOut>
    {
        TOut Read(TIn input);
    }
}
