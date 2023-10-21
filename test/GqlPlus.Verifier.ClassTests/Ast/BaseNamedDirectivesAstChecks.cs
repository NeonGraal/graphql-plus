namespace GqlPlus.Verifier.Ast;

internal interface BaseNamedDirectivesAstChecks : BaseNamedAstChecks
{
  void HashCode(string name, string directive);
  void String(string name, string directive, string expected);
  void Equality(string name, string directive);
  void Inequality_WithDirective(string name, string directive);
  void Inequality_ByNames(string name1, string name2, string directive);
  void Inequality_ByDirectives(string name, string directive1, string directive2);
  string ExpectedString(string name, string directive);
}

internal sealed class BaseNamedDirectivesAstChecks<T>
  : BaseNamedAstChecks<T>, BaseNamedDirectivesAstChecks
  where T : AstBase, AstDirectives
{
  public BaseNamedDirectivesAstChecks(CreateByName create)
    : base(create) { }

  public void HashCode(string name, string directive)
    => HashCode(() => CreateDirective(name, directive));

  public void Equality(string name, string directive)
  {
    var left = CreateDirective(name, directive);
    var right = CreateDirective(name, directive);

    left!.Equals(right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  public void Inequality_WithDirective(string name, string directive)
  {
    var left = CreateDirective(name, directive);
    var right = CreateName(name);

    (left != right).Should().BeTrue();
  }

  public void Inequality_ByDirectives(string name, string directive1, string directive2)
  {
    if (directive1 == directive2) {
      return;
    }

    var left = CreateDirective(name, directive1);
    var right = CreateDirective(name, directive2);

    (left != right).Should().BeTrue();
  }

  public void Inequality_ByNames(string name1, string name2, string directive)
  {
    if (name1 == name2) {
      return;
    }

    var left = CreateDirective(name1, directive);
    var right = CreateDirective(name2, directive);

    (left != right).Should().BeTrue();
  }

  public void String(string name, string directive, string expected)
    => String(() => CreateDirective(name, directive), expected);

  public string ExpectedString(string name, string directive)
    => $"( !{Abbr} {name} ( !D {directive} ) )";

  private T CreateDirective(string name, string directive)
  {
    var t = CreateName(name);
    t.Directives = directive.Directives();
    return t;
  }
}
