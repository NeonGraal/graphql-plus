namespace GqlPlus.Ast.Schema.Simple;

public class DomainAstEnumTests
  : AstDomainBaseTests<EnumLabelInput>
{

  [Theory, RepeatData]
  public void Inequality_BetweenSpecificItems(string name, string type1, string type2)
    => Checks.Inequality_BetweenItems(name, new(type1, TestLabel), new(type2, TestLabel));

  internal override IAstDomainChecks<EnumLabelInput> Checks => _checks;

  private readonly DomainAstEnumChecks _checks = new();
}

internal sealed class DomainAstEnumChecks()
 : AstDomainChecks<EnumLabelInput, DomainLabelAst, IAstDomainLabel>(DomainKind.Enum)
{
  protected override DomainLabelAst[] DomainItems(EnumLabelInput input)
    => [new(AstNulls.At, string.Empty, false, input.Label) { EnumType = input.EnumType }];

  protected override string ItemsString(string name, EnumLabelInput input)
    => $"( !Do {name} Enum !DE {input.EnumType} {input.Label} )";

  protected override AstDomain<DomainLabelAst, IAstDomainLabel> NewDomain(string name, DomainLabelAst[] list)
    => new(AstNulls.At, name, Kind, list);

  protected override bool SkipEquals(EnumLabelInput input1, EnumLabelInput input2)
    => input1 == input2;
}
