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
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class DomainStringEncoderGenerator()
  : GenerateBaseDomain<IAstDomainRegex>(DomainKind.String)
{
  protected override void Generate(IAstDomain<IAstDomainRegex> ast, GqlpGeneratorContext context)
  {
    string typeName = context.TypeName(ast, "");
    string interfaceName = context.TypeName(ast, "I");
    context.Write("");
    context.Write($"internal class {typeName}Encoder : IEncoder<{interfaceName}>");
    context.Write("{");
    context.Write($"  public Structured Encode({interfaceName} input)");
    context.Write("    => new(input.Value);");
    context.Write("}");
  }
}
