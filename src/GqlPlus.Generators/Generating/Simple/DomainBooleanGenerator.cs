namespace GqlPlus.Generating.Simple;

internal sealed class DomainBooleanInterfaceGenerator()
  : GenerateBaseDomain<IGqlpDomainTrueFalse>(DomainKind.Boolean)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainTrueFalse> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainBooleanModelGenerator()
  : GenerateBaseDomain<IGqlpDomainTrueFalse>(DomainKind.Boolean)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainTrueFalse> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}
