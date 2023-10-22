namespace GqlPlus.Verifier.Ast.Schema;

public class DirectiveAstTests : BaseAliasedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithOption(string name, DirectiveOption option)
      => _checks.HashCode(
        () => new DirectiveAst(AstNulls.At, name) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void String_WithOption(string name, DirectiveOption option)
    => _checks.String(
      () => new DirectiveAst(AstNulls.At, name) { Option = option },
      $"( !D {name} ({option}) None )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOption(string name, DirectiveOption option)
    => _checks.Equality(
      () => new DirectiveAst(AstNulls.At, name) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenOptions(string name, DirectiveOption option1, DirectiveOption option2)
    => _checks.InequalityBetween(option1, option2,
      option => new DirectiveAst(AstNulls.At, name) { Option = option },
      option1 == option2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParameter(string name, string param)
      => _checks.HashCode(
        () => new DirectiveAst(AstNulls.At, name) { Parameter = new ParameterAst(AstNulls.At, param) });

  [Theory, RepeatData(Repeats)]
  public void String_WithParameter(string name, string param)
    => _checks.String(
      () => new DirectiveAst(AstNulls.At, name) { Parameter = new ParameterAst(AstNulls.At, param) },
      $"( !D {name} ( !P !IR {param} ) (Unique) None )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParameter(string name, string param)
    => _checks.Equality(
      () => new DirectiveAst(AstNulls.At, name) { Parameter = new ParameterAst(AstNulls.At, param) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenParameters(string name, string param1, string param2)
    => _checks.InequalityBetween(param1, param2,
      param => new DirectiveAst(AstNulls.At, name) { Parameter = new ParameterAst(AstNulls.At, param) },
      param1 == param2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithLocations(string name, DirectiveLocation location)
      => _checks.HashCode(
        () => new DirectiveAst(AstNulls.At, name) { Locations = location });

  [Theory, RepeatData(Repeats)]
  public void String_WithLocations(string name, DirectiveLocation location)
    => _checks.String(
      () => new DirectiveAst(AstNulls.At, name) { Locations = location },
      $"( !D {name} (Unique) {location} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithLocations(string name, DirectiveLocation location)
    => _checks.Equality(
      () => new DirectiveAst(AstNulls.At, name) { Locations = location });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenLocationss(string name, DirectiveLocation location1, DirectiveLocation location2)
    => _checks.InequalityBetween(location1, location2,
      location => new DirectiveAst(AstNulls.At, name) { Locations = location },
      location1 == location2);

  protected override string InputString(string input)
    => $"( !D {input} (Unique) None )";

  protected override string AliasesString(string input, params string[] aliases)
    => $"( !D {input} [ {string.Join(" ", aliases)} ] (Unique) None )";

  private readonly BaseAliasedAstChecks<DirectiveAst> _checks
    = new(name => new DirectiveAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IBaseAliasedAstChecks<string> AliasedChecks => _checks;
}
