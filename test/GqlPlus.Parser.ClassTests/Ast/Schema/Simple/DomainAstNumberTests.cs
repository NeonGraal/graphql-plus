using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public class DomainAstNumberTests
  : AstDomainBaseTests<DomainRangeInput>
{
  internal override IAstDomainChecks<DomainRangeInput> Checks => _checks;

  private readonly DomainAstNumberChecks _checks = new();
}

internal sealed class DomainAstNumberChecks()
 : AstDomainChecks<DomainRangeInput, DomainRangeAst, IGqlpDomainRange>(DomainKind.Number)
{
  protected override DomainRangeAst[] DomainItems(DomainRangeInput input)
  => [new(AstNulls.At, string.Empty, false, null, input.Lower),
    new(AstNulls.At, string.Empty, true, input.Lower, input.Upper),
    new(AstNulls.At, string.Empty, false, input.Upper, null)];

  protected override string ItemsString(string name, DomainRangeInput input)
    => $"( !Do {name} Number !DN <{input.Lower:0.#####} !DN !{input.Lower:0.#####}~{input.Upper:0.#####} !DN {input.Upper:0.#####}> )";

  protected override AstDomain<DomainRangeAst, IGqlpDomainRange> NewDomain(string name, DomainRangeAst[] list)
    => new(AstNulls.At, name, Kind, list);
}
