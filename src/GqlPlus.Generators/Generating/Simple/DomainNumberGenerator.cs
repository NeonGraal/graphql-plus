namespace GqlPlus.Generating.Simple;

internal sealed class DomainNumberInterfaceGenerator()
  : GenerateBaseDomain<IGqlpDomainRange>(DomainKind.Number)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainRange> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainNumberModelGenerator()
  : GenerateBaseDomain<IGqlpDomainRange>(DomainKind.Number)
{
  protected override void Generate(IGqlpDomain<IGqlpDomainRange> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}
