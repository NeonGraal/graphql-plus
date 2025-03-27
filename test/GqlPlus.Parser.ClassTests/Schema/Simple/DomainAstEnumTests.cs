using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class DomainAstEnumTests
  : AstDomainTests<DomainLabelInput>
{
  [Theory, RepeatData]
  public void Inequality_BetweenSpecifcMembers(string name, string type1, string type2, string member)
    => Checks.Inequality_BetweenMembers(name, new(type1, member), new(type2, member));

  internal override IAstDomainChecks<DomainLabelInput> Checks => _checks;

  private readonly DomainAstEnumChecks _checks = new();
}

internal sealed class DomainAstEnumChecks()
 : AstDomainChecks<DomainLabelInput, DomainLabelAst, IGqlpDomainLabel>(DomainKind.Enum)
{
  protected override DomainLabelAst[] DomainLabels(DomainLabelInput input)
    => [new(AstNulls.At, "", false, input.EnumLabel)];

  protected override string MembersString(string name, DomainLabelInput input)
    => $"( !Do {name} Enum !DE {input.EnumLabel} )";

  protected override AstDomain<DomainLabelAst, IGqlpDomainLabel> NewDomain(string name, DomainLabelAst[] list)
    => new(AstNulls.At, name, Kind, list);

  protected override bool SkipEquals(DomainLabelInput input1, DomainLabelInput input2)
    => input1.EnumLabel == input2.EnumLabel;
}

public record struct DomainLabelInput(string EnumType, string EnumLabel);
