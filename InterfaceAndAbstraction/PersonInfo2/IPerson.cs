namespace PersonInfo2
{
    public interface IPerson : IBuyer
    {
        string Name { get; }

        int Age { get; }
    }
}
