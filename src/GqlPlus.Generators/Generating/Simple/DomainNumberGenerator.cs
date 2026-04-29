namespace GqlPlus.Generating.Simple;

internal sealed class DomainNumberInterfaceGenerator()
  : DomainValueInterfaceGeneratorBase<IAstDomainRange>(DomainKind.Number)
{ }

internal sealed class DomainNumberModelGenerator()
  : DomainValueModelGeneratorBase<IAstDomainRange>(DomainKind.Number)
{ }

internal sealed class DomainNumberDecoderGenerator()
  : DomainValueDecoderGeneratorBase<IAstDomainRange>(DomainKind.Number)
{ }

internal sealed class DomainNumberEncoderGenerator()
  : DomainValueEncoderGeneratorBase<IAstDomainRange>(DomainKind.Number)
{ }
