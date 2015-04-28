namespace ATM
{
    interface IParser<out TOut>
    {
        TOut Parse(string data);
    }
}
