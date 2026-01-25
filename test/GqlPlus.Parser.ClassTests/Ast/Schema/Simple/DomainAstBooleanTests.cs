using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public class DomainAstBooleanTests
  : AstDomainBaseTests<bool>
{
  internal override IAstDomainChecks<bool> Checks => _checks;

  private readonly DomainAstBooleanChecks _checks = new();
}

internal sealed class DomainAstBooleanChecks()
 : AstDomainChecks<bool, DomainTrueFalseAst, IGqlpDomainTrueFalse>(DomainKind.Boolean)
{
  protected override DomainTrueFalseAst[] DomainItems(bool input)
    => [new(AstNulls.At, string.Empty, false, input)];

  protected override string ItemsString(string name, bool input)
    => $"( !Do {name} Boolean !DT {input} )";

  protected override AstDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse> NewDomain(string name, DomainTrueFalseAst[] list)
    => new(AstNulls.At, name, Kind, list);
}
