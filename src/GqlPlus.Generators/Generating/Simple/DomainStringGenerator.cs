namespace GqlPlus.Generating.Simple;

internal sealed class DomainStringInterfaceGenerator()
  : DomainValueInterfaceGeneratorBase<IAstDomainRegex>(DomainKind.String)
{ }

internal sealed class DomainStringModelGenerator()
  : DomainValueModelGeneratorBase<IAstDomainRegex>(DomainKind.String)
{ }

internal sealed class DomainStringDecoderGenerator()
  : DomainValueDecoderGeneratorBase<IAstDomainRegex>(DomainKind.String)
{ }

internal sealed class DomainStringEncoderGenerator()
  : DomainValueEncoderGeneratorBase<IAstDomainRegex>(DomainKind.String)
{ }
