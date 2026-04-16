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
    string decoderName = context.TypeName(ast, "") + "Decoder";
    GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember,
      (_, c) => {
        c.Write("");
        c.Write($"  internal static {decoderName} Factory(IDecoderRepository _) => new();");
      });

    string interfaceType = context.TypeName(ast, "I");
    context.RegisterDecoder(interfaceType, decoderName);
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
    context.Write("");
    context.Write($"  internal static {typeName}Encoder Factory(IEncoderRepository _) => new();");
    context.Write("}");

    context.RegisterEncoder(interfaceName, typeName + "Encoder");
  }
}
