namespace GqlPlus.Generating.Simple;

internal sealed class DomainBooleanInterfaceGenerator()
  : GenerateBaseDomain<IGqlpDomainTrueFalse>(DomainKind.Boolean)
{
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;

  protected override void Generate(IGqlpDomain<IGqlpDomainTrueFalse> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainBooleanModelGenerator()
  : GenerateBaseDomain<IGqlpDomainTrueFalse>(DomainKind.Boolean)
{
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;

  protected override void Generate(IGqlpDomain<IGqlpDomainTrueFalse> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}
