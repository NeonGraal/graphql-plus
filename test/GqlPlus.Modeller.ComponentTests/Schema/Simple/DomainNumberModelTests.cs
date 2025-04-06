using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class DomainNumberModelTests(
  IDomainNumberModelChecks checks
) : TestDomainModel<DomainRangeInput, IGqlpDomainRange, DomainRangeModel>(checks)
{ }

internal sealed class DomainNumberModelChecks(
  CheckDomainInputs<IGqlpDomainRange, DomainRangeModel> inputs
) : CheckDomainModel<DomainRangeInput, DomainRangeAst, IGqlpDomainRange, DomainRangeModel>(DomainKind.Number, inputs)
  , IDomainNumberModelChecks
{
  protected override string[] ExpectedItem(DomainRangeInput input, string exclude, string[] domain)
    => ["  - !_DomainRange", .. domain, exclude, $"    from: {input.Lower:0.#####}", $"    to: {input.Upper:0.#####}"];

  protected override DomainRangeAst[]? DomainItems(DomainRangeInput[]? inputs)
    => inputs?.DomainRanges();
}

public interface IDomainNumberModelChecks
  : ICheckDomainModel<DomainRangeInput, IGqlpDomainRange, DomainRangeModel>
{ }
