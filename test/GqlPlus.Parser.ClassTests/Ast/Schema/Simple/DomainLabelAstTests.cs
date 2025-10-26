using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public class DomainLabelAstTests
  : AstAbbreviatedTests
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

  private readonly AstAbbreviatedChecks<DomainLabelAst> _checks
    = new(label => new DomainLabelAst(AstNulls.At, "", false, label));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
