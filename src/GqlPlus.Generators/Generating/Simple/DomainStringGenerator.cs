namespace GqlPlus.Generating.Simple;

internal sealed class DomainStringInterfaceGenerator()
  : GenerateBaseDomain<IGqlpDomainRegex>(DomainKind.String)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainRegex> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainStringModelGenerator()
  : GenerateBaseDomain<IGqlpDomainRegex>(DomainKind.String)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainRegex> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}

internal sealed class DomainStringDecoderGenerator()
  : GenerateBaseDomain<IGqlpDomainRegex>(DomainKind.String)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainRegex> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class DomainStringEncoderGenerator()
  : GenerateBaseDomain<IGqlpDomainRegex>(DomainKind.String)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainRegex> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EncoderHeader, TypeMembers, ClassMember);
}
