namespace GqlPlus.Generating.Simple;

internal sealed class DomainNumberInterfaceGenerator()
  : GenerateBaseDomain<IAstDomainRange>(DomainKind.Number)
{
  protected override void Generate(IAstDomain<IAstDomainRange> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainNumberModelGenerator()
  : GenerateBaseDomain<IAstDomainRange>(DomainKind.Number)
{
  protected override void Generate(IAstDomain<IAstDomainRange> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}

internal sealed class DomainNumberDecoderGenerator()
  : GenerateBaseDomain<IAstDomainRange>(DomainKind.Number)
{
  protected override void Generate(IAstDomain<IAstDomainRange> ast, GqlpGeneratorContext context)
    => GenerateDomainDecoder(ast, context);
}

internal sealed class DomainNumberEncoderGenerator()
  : GenerateBaseDomain<IAstDomainRange>(DomainKind.Number)
{
  protected override void Generate(IAstDomain<IAstDomainRange> ast, GqlpGeneratorContext context)
    => GenerateDomainEncoder(ast, context, "new(input.Value)");
}
