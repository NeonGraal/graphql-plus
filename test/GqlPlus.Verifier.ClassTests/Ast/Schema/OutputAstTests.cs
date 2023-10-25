﻿namespace GqlPlus.Verifier.Ast.Schema;

public class OutputAstTests : BaseAliasedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlternates(string name, string alternate)
      => _checks.HashCode(
        () => new OutputAst(AstNulls.At, name) { Alternates = alternate.OutputReferences() });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlternates(string name, string alternate)
    => _checks.String(
      () => new OutputAst(AstNulls.At, name) { Alternates = alternate.OutputReferences() },
      $"( !O {name} | {alternate} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlternates(string name, string alternate)
    => _checks.Equality(
      () => new OutputAst(AstNulls.At, name) { Alternates = alternate.OutputReferences() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenAlternates(string name, string alternate1, string alternate2)
    => _checks.InequalityBetween(alternate1, alternate2,
      alternate => new OutputAst(AstNulls.At, name) { Alternates = alternate.OutputReferences() },
      alternate1 == alternate2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithExtends(string name, string extends)
      => _checks.HashCode(
        () => new OutputAst(AstNulls.At, name) { Extends = new(AstNulls.At, extends) });

  [Theory, RepeatData(Repeats)]
  public void String_WithExtends(string name, string extends)
    => _checks.String(
      () => new OutputAst(AstNulls.At, name) { Extends = new(AstNulls.At, extends) },
      $"( !O {name} {extends} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithExtends(string name, string extends)
    => _checks.Equality(
      () => new OutputAst(AstNulls.At, name) { Extends = new(AstNulls.At, extends) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenExtends(string name, string extends1, string extends2)
    => _checks.InequalityBetween(extends1, extends2,
      extends => new OutputAst(AstNulls.At, name) { Extends = new(AstNulls.At, extends) },
      extends1 == extends2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string name, string field)
      => _checks.HashCode(
        () => new OutputAst(AstNulls.At, name) { Fields = field.OutputFields("String") });

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string name, string field)
    => _checks.String(
      () => new OutputAst(AstNulls.At, name) { Fields = field.OutputFields("String") },
      $"( !O {name} {{ !OF {field} : String }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string name, string field)
    => _checks.Equality(
      () => new OutputAst(AstNulls.At, name) { Fields = field.OutputFields("String") });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, string field1, string field2)
    => _checks.InequalityBetween(field1, field2,
      field => new OutputAst(AstNulls.At, name) { Fields = field.OutputFields("String") },
      field1 == field2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParameters(string name, string parameter)
      => _checks.HashCode(
        () => new OutputAst(AstNulls.At, name) { Parameters = parameter.TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithParameters(string name, string parameter)
    => _checks.String(
      () => new OutputAst(AstNulls.At, name) { Parameters = parameter.TypeParameters() },
      $"( !O {name} < ${parameter} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParameters(string name, string parameter)
    => _checks.Equality(
      () => new OutputAst(AstNulls.At, name) { Parameters = parameter.TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenParameterss(string name, string parameter1, string parameter2)
    => _checks.InequalityBetween(parameter1, parameter2,
      parameter => new OutputAst(AstNulls.At, name) { Parameters = parameter.TypeParameters() },
      parameter1 == parameter2);

  protected override string InputString(string input)
    => $"( !O {input} )";

  private readonly BaseAliasedAstChecks<OutputAst> _checks
    = new(regex => new OutputAst(AstNulls.At, regex));

  internal override IBaseAliasedAstChecks AliasedChecks => _checks;
}
