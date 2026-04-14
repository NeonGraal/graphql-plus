namespace GqlPlus.Generating.Simple;

internal abstract class GenerateBaseDomain<TItem>(
  DomainKind kind
) : GenerateForSimple<IAstDomain<TItem>>
  where TItem : IAstDomainItem
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IAstDomain<TItem> ast, GqlpGeneratorTypes types)
    => [];

  protected override bool HasDefaultParent(out string? defaultParent)
  {
    defaultParent = $"GqlpDomain{kind}";

    return true;
  }

  protected void GenerateDomainDecoder(IAstDomain<TItem> ast, GqlpGeneratorContext context)
  {
    GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);

    string typeName = context.TypeName(ast, "");
    string interfaceType = context.TypeName(ast, "I");
    context.RegisterDecoder($".AddDecoder<{interfaceType}>(_ => new {typeName}Decoder())");
  }

  protected void GenerateDomainEncoder(IAstDomain<TItem> ast, GqlpGeneratorContext context, string encodeBody)
  {
    string typeName = context.TypeName(ast, "");
    string interfaceName = context.TypeName(ast, "I");
    context.Write("");
    context.Write($"internal class {typeName}Encoder : IEncoder<{interfaceName}>");
    context.Write("{");
    context.Write($"  public Structured Encode({interfaceName} input)");
    context.Write($"    => {encodeBody};");
    context.Write("}");

    context.RegisterEncoder($".AddEncoder<{interfaceName}>(_ => new {typeName}Encoder())");
  }
}
