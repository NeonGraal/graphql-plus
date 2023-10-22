namespace GqlPlus.Verifier.Ast.Schema;

public class EnumAstTests : BaseAliasedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithExtends(string name, string extends)
      => _checks.HashCode(
        () => new EnumAst(AstNulls.At, name) { Extends = extends });

  [Theory, RepeatData(Repeats)]
  public void String_WithExtends(string name, string extends)
    => _checks.String(
      () => new EnumAst(AstNulls.At, name) { Extends = extends },
      $"( !E {name} :{extends} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithExtends(string name, string extends)
    => _checks.Equality(
      () => new EnumAst(AstNulls.At, name) { Extends = extends });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenExtends(string name, string extends1, string extends2)
    => _checks.InequalityBetween(extends1, extends2,
      extends => new EnumAst(AstNulls.At, name) { Extends = extends },
      extends1 == extends2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithLabels(string name, string label)
      => _checks.HashCode(
        () => new EnumAst(AstNulls.At, name) { Labels = label.EnumLabels() });

  [Theory, RepeatData(Repeats)]
  public void String_WithLabels(string name, string label)
    => _checks.String(
      () => new EnumAst(AstNulls.At, name) { Labels = label.EnumLabels() },
      $"( !E {name} !EL {label} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithLabels(string name, string label)
    => _checks.Equality(
      () => new EnumAst(AstNulls.At, name) { Labels = label.EnumLabels() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenLabelss(string name, string label1, string label2)
    => _checks.InequalityBetween(label1, label2,
      label => new EnumAst(AstNulls.At, name) { Labels = label.EnumLabels() },
      label1 == label2);

  private readonly BaseAliasedAstChecks<EnumAst> _checks
    = new(name => new EnumAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IBaseAliasedAstChecks<string> AliasedChecks => _checks;
}
