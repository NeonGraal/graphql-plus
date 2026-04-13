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
