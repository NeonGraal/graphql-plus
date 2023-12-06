namespace GqlPlus.Verifier.Ast.Schema;

public class EnumAstTests : BaseAliasedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithExtends(string name, string extends)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name) { Extends = extends });

  [Theory, RepeatData(Repeats)]
  public void String_WithExtends(string name, string extends)
    => _checks.String(
      () => new EnumDeclAst(AstNulls.At, name) { Extends = extends },
      $"( !E {name} :{extends} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithExtends(string name, string extends)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name) { Extends = extends });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenExtends(string name, string extends1, string extends2)
    => _checks.InequalityBetween(extends1, extends2,
      extends => new EnumDeclAst(AstNulls.At, name) { Extends = extends },
      extends1 == extends2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithLabels(string name, string[] labels)
      => _checks.HashCode(
        () => new EnumDeclAst(AstNulls.At, name) { Labels = labels.EnumLabels() });

  [Theory, RepeatData(Repeats)]
  public void String_WithLabels(string name, string[] labels)
    => _checks.String(
      () => new EnumDeclAst(AstNulls.At, name) { Labels = labels.EnumLabels() },
      $"( !E {name} {labels.Joined("!EL ")} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithLabels(string name, string[] labels)
    => _checks.Equality(
      () => new EnumDeclAst(AstNulls.At, name) { Labels = labels.EnumLabels() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenLabels(string name, string[] labels1, string[] labels2)
    => _checks.InequalityBetween(labels1, labels2,
      label => new EnumDeclAst(AstNulls.At, name) { Labels = label.EnumLabels() },
      labels1.SequenceEqual(labels2));

  private readonly BaseAliasedAstChecks<EnumDeclAst> _checks
    = new(name => new EnumDeclAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IBaseAliasedAstChecks<string> AliasedChecks => _checks;
}
