using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating.Simple;

internal sealed class DomainStringInterfaceGenerator()
  : GenerateBaseDomain<IAstDomainRegex>(DomainKind.String)
{
  protected override void Generate(IAstDomain<IAstDomainRegex> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainStringModelGenerator()
  : GenerateBaseDomain<IAstDomainRegex>(DomainKind.String)
{
  protected override void Generate(IAstDomain<IAstDomainRegex> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}

internal sealed class DomainStringDecoderGenerator()
  : GenerateBaseDomain<IAstDomainRegex>(DomainKind.String)
{
  protected override void Generate(IAstDomain<IAstDomainRegex> ast, GqlpGeneratorContext context)
    => GenerateDomainDecoder(ast, context);
}

internal sealed class DomainStringEncoderGenerator()
  : GenerateBaseDomain<IAstDomainRegex>(DomainKind.String)
{
  protected override void Generate(IAstDomain<IAstDomainRegex> ast, GqlpGeneratorContext context)
    => GenerateDomainEncoder(ast, context, "new(input.Value)");
}
