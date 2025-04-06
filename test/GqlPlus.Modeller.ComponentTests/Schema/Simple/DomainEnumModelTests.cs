using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class DomainEnumModelTests(
  IDomainEnumModelChecks checks
) : TestDomainModel<string, IGqlpDomainLabel, DomainLabelModel>(checks)
{ }

internal sealed class DomainEnumModelChecks(
  CheckDomainInputs<IGqlpDomainLabel, DomainLabelModel> inputs
) : CheckDomainModel<string, DomainLabelAst, IGqlpDomainLabel, DomainLabelModel>(DomainKind.Enum, inputs)
  , IDomainEnumModelChecks
{
  protected override string[] ExpectedItem(string input, string exclude, string[] domain)
    => [
      "  - !_DomainLabel",
      .. domain,
      exclude,
      "    value: !_EnumValue",
      "      label: " + input,
      "      typeKind: !_SimpleKind Enum"
      ];

  protected override DomainLabelAst[]? DomainItems(string[]? inputs)
    => inputs?.DomainLabels();
}

public interface IDomainEnumModelChecks
  : ICheckDomainModel<string, IGqlpDomainLabel, DomainLabelModel>
{ }
