using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public partial class DomainLabelAstTests
{
  [Theory, RepeatData]
  public void SetEnumType_WhenCurrentlyEmpty_SetsValue(string enumType, string enumLabel)
  {
    IGqlpDomainLabel ast = new DomainLabelAst(AstNulls.At, "", false, enumLabel);

    ast.SetEnumType(enumType);

    ast.EnumType.ShouldBe(enumType);
  }

  [Theory, RepeatData]
  public void SetEnumType_WhenCurrentlySet_SetsIsIgnored(string enumType, string enumLabel, string newType)
  {
    this.SkipEqual(enumType, newType);

    IGqlpDomainLabel ast = new DomainLabelAst(AstNulls.At, "", false, enumLabel) { EnumType = enumType };

    ast.SetEnumType(newType);

    ast.EnumType.ShouldBe(enumType);
  }

  [CheckTests(Inherited = true)]
  private IAstAbbreviatedChecks<string> AbbreviatedChecks { get; }
    = new AstAbbreviatedChecks<DomainLabelAst>(CreateLabel);

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, DomainLabelAst>(CreateLabel, CloneLabel);

  private static DomainLabelAst CloneLabel(DomainLabelAst original, string input)
    => original with { EnumItem = input };
  private static DomainLabelAst CreateLabel(string input)
    => new(AstNulls.At, "", false, input);
}
