namespace ServiceB;

public class Query
{
    public Bar GetBarByCommonField(string commonField)
    {
        return new Bar(commonField, "barFieldValue");
    }

    public Fizz GetFizzByCommonField(string commonField)
    {
        return new Fizz(commonField, "barFieldValue");
    }
}