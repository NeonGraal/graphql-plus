namespace GqlPlus.Generating.Simple;

internal sealed class DomainBooleanGenerator()
  : GenerateBaseDomain<IGqlpDomainTrueFalse>(DomainKind.Boolean)
{ }
