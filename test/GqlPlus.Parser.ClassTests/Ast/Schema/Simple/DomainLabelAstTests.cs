using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public partial class DomainLabelAstTests
{
  [Theory, RepeatData]
  public void SetEnumType_WhenCurrentlyEmpty_SetsValue(string enumType, string enumLabel, string type)
  {
    IGqlpDomainLabel ast = new DomainLabelAst(AstNulls.At, type, false, enumLabel);

    ast.SetEnumType(enumType);

    ast.EnumType.ShouldBe(enumType);
  }

  [Theory, RepeatData]
  public void SetEnumType_WhenCurrentlySet_SetsIsIgnored(string enumType, string enumLabel, string newType, string type)
  {
    this.SkipEqual(enumType, newType);

    IGqlpDomainLabel ast = new DomainLabelAst(AstNulls.At, type, false, enumLabel) { EnumType = enumType };

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
    => new(AstNulls.At, input, false, input);
}
