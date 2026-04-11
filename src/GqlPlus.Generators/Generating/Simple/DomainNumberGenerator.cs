using GqlPlus.Ast.Schema;

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
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class DomainNumberEncoderGenerator()
  : GenerateBaseDomain<IAstDomainRange>(DomainKind.Number)
{
  protected override void Generate(IAstDomain<IAstDomainRange> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EncoderHeader, TypeMembers, ClassMember);
}
