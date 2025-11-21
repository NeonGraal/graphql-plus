using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Globals;

public partial class DirectiveDeclAstTests
{
  [Theory, RepeatData]
  public void HashCode_WithOption(string name, DirectiveOption option)
      => _checks.HashCode(
        () => new DirectiveDeclAst(AstNulls.At, name) { Option = option });

  [Theory, RepeatData]
  public void Text_WithOption(string name, DirectiveOption option)
    => _checks.Text(
      () => new DirectiveDeclAst(AstNulls.At, name) { Option = option },
      $"( !Di {name} ({option}) None )");

  [Theory, RepeatData]
  public void Equality_WithOption(string name, DirectiveOption option)
    => _checks.Equality(
      () => new DirectiveDeclAst(AstNulls.At, name) { Option = option });

  [Theory, RepeatData]
  public void Inequality_BetweenOptions(string name, DirectiveOption option1, DirectiveOption option2)
    => _checks.InequalityBetween(option1, option2,
      option => new DirectiveDeclAst(AstNulls.At, name) { Option = option },
      option1 == option2);

  [Theory, RepeatData]
  public void HashCode_WithParam(string name, string[] parameters)
      => _checks.HashCode(
        () => new DirectiveDeclAst(AstNulls.At, name) { Params = parameters.Params() });

  [Theory, RepeatData]
  public void Text_WithParams(string name, string[] parameters)
    => _checks.Text(
      () => new DirectiveDeclAst(AstNulls.At, name) { Params = parameters.Params() },
      $"( !Di {name} ( {parameters.Joined(s => "!Pa " + s)} ) (Unique) None )");

  [Theory, RepeatData]
  public void Equality_WithParam(string name, string[] parameters)
    => _checks.Equality(
      () => new DirectiveDeclAst(AstNulls.At, name) { Params = parameters.Params() });

  [Theory, RepeatData]
  public void Inequality_BetweenParams(string name, string[] parameters1, string[] parameters2)
    => _checks.InequalityBetween(parameters1, parameters2,
      parameters => new DirectiveDeclAst(AstNulls.At, name) { Params = parameters.Params() },
      parameters1.SequenceEqual(parameters2));

  [Theory, RepeatData]
  public void HashCode_WithLocations(string name, DirectiveLocation location)
      => _checks.HashCode(
        () => new DirectiveDeclAst(AstNulls.At, name) { Locations = location });

  [Theory, RepeatData]
  public void Text_WithLocations(string name, DirectiveLocation location)
    => _checks.Text(
      () => new DirectiveDeclAst(AstNulls.At, name) { Locations = location },
      $"( !Di {name} (Unique) {location} )");

  [Theory, RepeatData]
  public void Equality_WithLocations(string name, DirectiveLocation location)
    => _checks.Equality(
      () => new DirectiveDeclAst(AstNulls.At, name) { Locations = location });

  [Theory, RepeatData]
  public void Inequality_BetweenLocations(string name, DirectiveLocation location1, DirectiveLocation location2)
    => _checks.InequalityBetween(location1, location2,
      location => new DirectiveDeclAst(AstNulls.At, name) { Locations = location },
      location1 == location2);

  private readonly DirectiveDeclAstChecks _checks = new();

  [CheckTests(Inherited = true)]
  internal IAstAliasedChecks<string> AliasedChecks => _checks;

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, DirectiveDeclAst>(
      CreateDirective,
      (original, input) => original with { Name = input });

  internal static DirectiveDeclAst CreateDirective(string input)
    => new(AstNulls.At, input);
}

internal sealed class DirectiveDeclAstChecks()
  : AstAliasedChecks<DirectiveDeclAst>(DirectiveDeclAstTests.CreateDirective)
{
  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} (Unique) None )";

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
