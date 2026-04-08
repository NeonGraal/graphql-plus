namespace GqlPlus.Generating.Simple;

internal sealed class DomainEnumInterfaceGenerator()
  : GenerateBaseDomain<IGqlpDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainEnumModelGenerator()
  : GenerateBaseDomain<IGqlpDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}

internal sealed class DomainEnumDecoderGenerator()
  : GenerateBaseDomain<IGqlpDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class DomainEnumEncoderGenerator()
  : GenerateBaseDomain<IGqlpDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EncoderHeader, TypeMembers, ClassMember);
}
