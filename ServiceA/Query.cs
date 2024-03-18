namespace ServiceA;

public class Query
{
    public List<Foo> GetFoos()
    {
        return new List<Foo>
        {
            new Foo("commonFieldValue")
        };
    }
}