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

  protected void InterfaceMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value} {item.Key} {{ get; }}");

  protected void GenerateDomainInterface(IAstDomain<TItem> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);

  protected void GenerateDomainModel(IAstDomain<TItem> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);

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

  protected void GenerateDomainValueEncoder(IAstDomain<TItem> ast, GqlpGeneratorContext context)
    => GenerateDomainEncoder(ast, context, "input.Value!.Encode()");
}
