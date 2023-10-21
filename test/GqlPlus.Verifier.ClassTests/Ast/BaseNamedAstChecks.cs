using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Ast;

internal interface BaseNamedAstChecks
{
  void HashCode(string name);
  void String(string name, string expected);
  void Equality(string name);
  void Inequality(string name1, string name2);
  string ExpectedString(string name);
}

internal class BaseNamedAstChecks<T> : BaseAstChecks<T>, BaseNamedAstChecks
  where T : AstBase
{
  internal Func<string, string, bool> SameName { get; init; }
    = (string name1, string name2) => name1 == name2;

  protected readonly CreateByName CreateName;
  protected readonly string Abbr;
  private readonly string _createExpression;

  public BaseNamedAstChecks(CreateByName createName,
    [CallerArgumentExpression(nameof(createName))] string createExpression = "")
    => (CreateName, Abbr, _createExpression) = (createName, createName("").Abbr, createExpression);

  public void HashCode(string name)
    => HashCode(() => CreateName(name));

  public void String(string name, string expected)
    => String(() => CreateName(name), expected);

  public void Equality(string name)
  {
    var left = CreateName(name);
    var right = CreateName(name);

    var result = left!.Equals(right);

    result.Should().BeTrue(_createExpression);

    left.Should().NotBeSameAs(right);
  }

  public void Inequality(string name1, string name2)
  {
    if (SameName(name1, name2)) {
      return;
    }

    var left = CreateName(name1);
    var right = CreateName(name2);

    var result = left!.Equals(right);

    result.Should().BeFalse(_createExpression);
  }

  public void InequalityWith(string name, Creator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    var left = factory();
    var right = CreateName(name);

    var result = left!.Equals(right);

    result.Should().BeFalse(factoryExpression);
  }

  public string ExpectedString(string name)
    => $"( !{Abbr} {name} )";
}
