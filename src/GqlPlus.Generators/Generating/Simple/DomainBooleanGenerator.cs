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
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class DomainBooleanEncoderGenerator()
  : GenerateBaseDomain<IAstDomainTrueFalse>(DomainKind.Boolean)
{
  protected override void Generate(IAstDomain<IAstDomainTrueFalse> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EncoderHeader, TypeMembers, ClassMember);
}
