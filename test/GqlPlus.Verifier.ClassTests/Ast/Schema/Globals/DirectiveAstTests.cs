namespace GqlPlus.Verifier.Ast.Schema.Globals;

public class DirectiveAstTests : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithOption(string name, DirectiveOption option)
      => _checks.HashCode(
        () => new DirectiveDeclAst(AstNulls.At, name) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void String_WithOption(string name, DirectiveOption option)
    => _checks.Text(
      () => new DirectiveDeclAst(AstNulls.At, name) { Option = option },
      $"( !D {name} ({option}) None )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOption(string name, DirectiveOption option)
    => _checks.Equality(
      () => new DirectiveDeclAst(AstNulls.At, name) { Option = option });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenOptions(string name, DirectiveOption option1, DirectiveOption option2)
    => _checks.InequalityBetween(option1, option2,
      option => new DirectiveDeclAst(AstNulls.At, name) { Option = option },
      option1 == option2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParameter(string name, string[] parameters)
      => _checks.HashCode(
        () => new DirectiveDeclAst(AstNulls.At, name) { Parameters = parameters.Parameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithParameters(string name, string[] parameters)
    => _checks.Text(
      () => new DirectiveDeclAst(AstNulls.At, name) { Parameters = parameters.Parameters() },
      $"( !D {name} ( {parameters.Joined(s => "!P " + s)} ) (Unique) None )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParameter(string name, string[] parameters)
    => _checks.Equality(
      () => new DirectiveDeclAst(AstNulls.At, name) { Parameters = parameters.Parameters() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParameters(string name, string[] parameters1, string[] parameters2)
    => _checks.InequalityBetween(parameters1, parameters2,
      parameters => new DirectiveDeclAst(AstNulls.At, name) { Parameters = parameters.Parameters() },
      parameters1.SequenceEqual(parameters2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithLocations(string name, DirectiveLocation location)
      => _checks.HashCode(
        () => new DirectiveDeclAst(AstNulls.At, name) { Locations = location });

  [Theory, RepeatData(Repeats)]
  public void String_WithLocations(string name, DirectiveLocation location)
    => _checks.Text(
      () => new DirectiveDeclAst(AstNulls.At, name) { Locations = location },
      $"( !D {name} (Unique) {location} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithLocations(string name, DirectiveLocation location)
    => _checks.Equality(
      () => new DirectiveDeclAst(AstNulls.At, name) { Locations = location });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenLocations(string name, DirectiveLocation location1, DirectiveLocation location2)
    => _checks.InequalityBetween(location1, location2,
      location => new DirectiveDeclAst(AstNulls.At, name) { Locations = location },
      location1 == location2);

  protected override string AliasesString(string input, string aliases)
    => $"( !D {input}{aliases} (Unique) None )";

  private readonly AstAliasedChecks<DirectiveDeclAst> _checks
    = new(name => new DirectiveDeclAst(AstNulls.At, name));

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
