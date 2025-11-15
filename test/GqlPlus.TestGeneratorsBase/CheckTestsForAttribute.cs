namespace GqlPlus;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class CheckTestsForAttribute : Attribute
{
  public string Target { get; }
  public Type? Checks { get; }

  public CheckTestsForAttribute(string target, Type? checks = null)
  {
    Target = target;
    Checks = checks;
  }
}
