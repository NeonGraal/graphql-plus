namespace GqlPlus.Verifier.Ast;

internal interface BaseNamedAstChecks
{
  void HashCode(string name);
  void String(string name, string expected);
  void Equality(string name);
  void Inequality(string name1, string name2);
  string ExpectedString(string name);
}

internal class BaseNamedAstChecks<T> : BaseNamedAstChecks
  where T : AstBase
{
  internal delegate T CreateByName(string name);

  internal Func<string, string, bool> SameName { get; init; }
    = (string name1, string name2) => name1 == name2;

  protected readonly CreateByName CreateName;
  protected readonly string Abbr;

  public BaseNamedAstChecks(CreateByName createName)
    => (CreateName, Abbr) = (createName, createName("").Abbr);

  public void HashCode(string name)
    => TestHashCode(() => CreateName(name));

  public void String(string name, string expected)
    => CreateName(name).TestString(expected);

  public void Equality(string name)
  {
    var left = CreateName(name);
    var right = CreateName(name);

    left!.Equals(right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  public void Inequality(string name1, string name2)
  {
    if (SameName(name1, name2)) {
      return;
    }

    var left = CreateName(name1);
    var right = CreateName(name2);

    left!.Equals(right).Should().BeFalse();
  }

  public string ExpectedString(string name)
    => $"( !{Abbr} {name} )";
}
