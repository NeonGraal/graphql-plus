namespace GqlPlus.Generating.Simple;

internal sealed class DomainBooleanInterfaceGenerator()
  : DomainValueInterfaceGeneratorBase<IAstDomainTrueFalse>(DomainKind.Boolean)
{ }

internal sealed class DomainBooleanModelGenerator()
  : DomainValueModelGeneratorBase<IAstDomainTrueFalse>(DomainKind.Boolean)
{ }

internal sealed class DomainBooleanDecoderGenerator()
  : DomainValueDecoderGeneratorBase<IAstDomainTrueFalse>(DomainKind.Boolean)
{ }

internal sealed class DomainBooleanEncoderGenerator()
  : DomainValueEncoderGeneratorBase<IAstDomainTrueFalse>(DomainKind.Boolean)
{ }
