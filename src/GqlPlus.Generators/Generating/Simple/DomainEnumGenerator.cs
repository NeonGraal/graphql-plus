namespace GqlPlus.Generating.Simple;

internal sealed class DomainEnumGenerator()
  : GenerateBaseDomain<IGqlpDomainLabel>(DomainKind.Enum)
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpDomain<IGqlpDomainLabel> ast, GqlpGeneratorTypes types)
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
