namespace ifst.API.ifst.Domain.Common;

[AttributeUsage(AttributeTargets.Class)]
public class DisplayNameAttribute : Attribute
{
    public string Name { get; }
    public DisplayNameAttribute(string name)
    {
        Name = name;
    }
}