namespace GqlPlus.Generating.Simple;

internal abstract class DomainEnumGeneratorBase()
  : GenerateBaseDomain<IAstDomainLabel>(DomainKind.Enum)
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorTypes types)
  {
    string[] enumTypes = [.. ast.Items
      .Select(i => i.EnumType)
      .Where(t => !string.IsNullOrWhiteSpace(t))
      .Distinct()];

    if (enumTypes.Length != 1) {
      return [];
    }

    string valueType = "new " + types.TypeName(enumTypes[0], "") + "?";
    return [new MapPair<string>("Value", valueType)];
  }
}

internal sealed class DomainEnumInterfaceGenerator()
  : DomainEnumGeneratorBase
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class DomainEnumModelGenerator()
  : DomainEnumGeneratorBase
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}

internal sealed class DomainEnumDecoderGenerator()
  : DomainEnumGeneratorBase
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorTypes types)
    => base.TypeMembers(ast, types)
      .Select(m => m.Value.StartsWith("new ", StringComparison.Ordinal)
        ? new MapPair<string>(m.Key, m.Value.Substring(4))
        : m);

  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
    => GenerateDomainDecoder(ast, context);
}

internal sealed class DomainEnumEncoderGenerator()
  : DomainEnumGeneratorBase
{
  protected override void Generate(IAstDomain<IAstDomainLabel> ast, GqlpGeneratorContext context)
  {
    string[] enumTypes = [.. ast.Items
      .Select(i => i.EnumType)
      .Where(t => !string.IsNullOrWhiteSpace(t))
      .Distinct()];

    if (enumTypes.Length == 1) {
      string valueType = context.TypeName(enumTypes[0], "");
      GenerateDomainEncoder(ast, context, $"input.Value?.EncodeEnum(\"{valueType}\")!");
      return;
    }

    GenerateDomainEncoder(ast, context, $"input.Value?.EncodeEnum(\"{ast.Name}\")!");
  }
}
