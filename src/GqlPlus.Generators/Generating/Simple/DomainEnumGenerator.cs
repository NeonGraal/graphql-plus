namespace GqlPlus.Generating.Simple;

internal sealed class DomainEnumInterfaceGenerator()
  : GenerateBaseDomain<IAstDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);

  internal override IEnumerable<MapPair<string>> TypeMembers(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorTypes types)
  {
    string[] enumTypes = [.. ast.Items
      .Select(i => i.EnumType)
      .Where(t => !string.IsNullOrWhiteSpace(t))
      .Distinct()];

    if (enumTypes.Length != 1) {
      return [];
    }

    string csharpType = "new " + types.TypeName(enumTypes[0], "") + "?";

    return [new MapPair<string>("Value", csharpType)];
  }
}

internal sealed class DomainEnumModelGenerator()
  : GenerateBaseDomain<IAstDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);

  internal override IEnumerable<MapPair<string>> TypeMembers(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorTypes types)
  {
    string[] enumTypes = [.. ast.Items
      .Select(i => i.EnumType)
      .Where(t => !string.IsNullOrWhiteSpace(t))
      .Distinct()];

    if (enumTypes.Length != 1) {
      return [];
    }

    string csharpType = "new " + types.TypeName(enumTypes[0], "") + "?";

    return [new MapPair<string>("Value", csharpType)];
  }
}

internal sealed class DomainEnumDecoderGenerator()
  : GenerateBaseDomain<IAstDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class DomainEnumEncoderGenerator()
  : GenerateBaseDomain<IAstDomainLabel>(DomainKind.Enum)
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
  {
    string typeName = context.TypeName(ast, "");
    string interfaceName = context.TypeName(ast, "I");
    context.Write("");
    context.Write($"internal class {typeName}Encoder : IEncoder<{interfaceName}>");
    context.Write("{");
    context.Write($"  public Structured Encode({interfaceName} input)");
    context.Write("    => new((decimal?)input.Value);");
    context.Write("}");
  }
}
