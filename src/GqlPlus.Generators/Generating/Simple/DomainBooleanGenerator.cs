namespace GqlPlus.Generating.Simple;

internal sealed class DomainBooleanInterfaceGenerator()
  : GenerateBaseDomain<IAstDomainTrueFalse>(DomainKind.Boolean)
{
  protected override void Generate(IAstDomain<IAstDomainTrueFalse> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainBooleanModelGenerator()
  : GenerateBaseDomain<IAstDomainTrueFalse>(DomainKind.Boolean)
{
  protected override void Generate(IAstDomain<IAstDomainTrueFalse> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}

internal sealed class DomainBooleanDecoderGenerator()
  : GenerateBaseDomain<IAstDomainTrueFalse>(DomainKind.Boolean)
{
  protected override void Generate(IAstDomain<IAstDomainTrueFalse> ast, GqlpGeneratorContext context)
    => GenerateDomainDecoder(ast, context);
}

internal sealed class DomainBooleanEncoderGenerator()
  : GenerateBaseDomain<IAstDomainTrueFalse>(DomainKind.Boolean)
{
  protected override void Generate(IAstDomain<IAstDomainTrueFalse> ast, GqlpGeneratorContext context)
    => GenerateDomainEncoder(ast, context, "input.Value!.Encode()");
}
