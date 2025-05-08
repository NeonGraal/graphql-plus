﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Globals;

public class DirectiveAstTests : AstAliasedTests
{
  [Theory, RepeatData]
  public void HashCode_WithOption(string name, DirectiveOption option)
      => _checks.HashCode(
        () => new DirectiveDeclAst(AstNulls.At, name) { Option = option });

  [Theory, RepeatData]
  public void String_WithOption(string name, DirectiveOption option)
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
  public void String_WithParams(string name, string[] parameters)
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
  public void String_WithLocations(string name, DirectiveLocation location)
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

  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} (Unique) None )";

  private readonly AstAliasedChecks<DirectiveDeclAst> _checks
    = new(name => new DirectiveDeclAst(AstNulls.At, name));

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
