namespace GqlPlus;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class CheckTestsForAttribute(
  string target,
  Type? checks = null
) : Attribute
{
  public string Target { get; } = target;
  public Type? Checks { get; } = checks;

  public bool Inherited { get; set; }
}
