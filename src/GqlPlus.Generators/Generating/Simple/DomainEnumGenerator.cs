using System.Runtime.InteropServices.ComTypes;

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

    string valueType = "new " + types.TypeName(enumTypes[0], "") + "?";

    return [new MapPair<string>("Value", valueType)];
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

    string valueType = "new " + types.TypeName(enumTypes[0], "") + "?";
    return [new MapPair<string>("Value", valueType)];
  }
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
  {
    string[] enumTypes = [.. ast.Items
      .Select(i => i.EnumType)
      .Where(t => !string.IsNullOrWhiteSpace(t))
      .Distinct()];

    if (enumTypes.Length != 1) {
      return;
    }

    string valueType = context.TypeName(enumTypes[0], "");
    GenerateDomainEncoder(ast, context, $"new(input.ToString(), \"{valueType}\")");
  }
}
