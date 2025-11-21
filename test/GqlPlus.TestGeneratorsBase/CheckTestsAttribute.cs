namespace GqlPlus;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
public sealed class CheckTestsAttribute(
  Type? checks = null
) : Attribute
{
  public Type? Checks { get; } = checks;

  public bool Inherited { get; set; }
}
