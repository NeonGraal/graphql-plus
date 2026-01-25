using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public class DomainAstEnumTests
  : AstDomainBaseTests<DomainLabelInput>
{
  [Theory, RepeatData]
  public void Inequality_BetweenSpecifcItems(string name, string type1, string type2, string label)
    => Checks.Inequality_BetweenItems(name, new(type1, label), new(type2, label));

  internal override IAstDomainChecks<DomainLabelInput> Checks => _checks;

  private readonly DomainAstEnumChecks _checks = new();
}

internal sealed class DomainAstEnumChecks()
 : AstDomainChecks<DomainLabelInput, DomainLabelAst, IGqlpDomainLabel>(DomainKind.Enum)
{
  protected override DomainLabelAst[] DomainItems(DomainLabelInput input)
    => [new(AstNulls.At, string.Empty, false, input.EnumLabel)];

  protected override string ItemsString(string name, DomainLabelInput input)
    => $"( !Do {name} Enum !DE {input.EnumLabel} )";

  protected override AstDomain<DomainLabelAst, IGqlpDomainLabel> NewDomain(string name, DomainLabelAst[] list)
    => new(AstNulls.At, name, Kind, list);

  protected override bool SkipEquals(DomainLabelInput input1, DomainLabelInput input2)
    => input1.EnumLabel == input2.EnumLabel;
}

public record struct DomainLabelInput(string EnumType, string EnumLabel);
