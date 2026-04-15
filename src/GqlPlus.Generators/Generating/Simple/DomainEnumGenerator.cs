using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating.Simple;

internal sealed class DomainEnumInterfaceGenerator()
  : GenerateBaseDomain<IAstDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainEnumModelGenerator()
  : GenerateBaseDomain<IAstDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}

internal sealed class DomainEnumDecoderGenerator()
  : GenerateBaseDomain<IAstDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateDomainDecoder(ast, context);
}

internal sealed class DomainEnumEncoderGenerator()
  : GenerateBaseDomain<IAstDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateDomainEncoder(ast, context, "new((decimal?)input.Value)");
}
