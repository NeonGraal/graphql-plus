
namespace GqlPlus.Generating.Simple;

// Unsealed to allow EnumDecoderGenerator and EnumEncoderGenerator to extend it
internal class EnumGenerator
  : GenerateForType<IGqlpEnum>
{
  protected override void Generate(IGqlpEnum ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EnumHeader, EnumMembers, EnumMember);

  private void EnumHeader(IGqlpEnum ast, GqlpGeneratorContext context)
    => context.Write($"public enum " + context.TypeName(ast, ""));

  private void EnumMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write("  " + item.Key + item.Value + ",");

  internal static void EnumClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public string {item.Key} {{ get; set; }}");

  private static IEnumerable<MapPair<string>> ParentItems(string? parent, GqlpGeneratorTypes types)
  {
    if (!types.GetTypeAst(parent, out IGqlpEnum ast)) {
      return [];
    }

    IEnumerable<MapPair<string>> members = ast!.Items.SelectMany(item => {
      string suffix = " = " + types.TypeName(parent!, "") + "." + item.Name;
      return item.Aliases
        .Select(alias => new MapPair<string>(alias, suffix))
        .Prepend(new MapPair<string>(item.Name, suffix));
    });

    return ParentItems(ast.Parent?.Name, types).Concat(members);
  }

  internal IEnumerable<MapPair<string>> EnumMembers(IGqlpEnum ast, GqlpGeneratorContext context)
  {
    IEnumerable<MapPair<string>> members = ast.Items.SelectMany(item =>
      item.Aliases
        .Select(alias => new MapPair<string>(alias, " = " + item.Name))
        .Prepend(new MapPair<string>(item.Name, "")));

    return ParentItems(ast.Parent?.Name, context).Concat(members);
  }
}

internal sealed class EnumDecoderGenerator
  : EnumGenerator
{
  protected override void Generate(IGqlpEnum ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, DecoderHeader, EnumMembers, EnumClassMember);
}

internal sealed class EnumEncoderGenerator
  : EnumGenerator
{
  protected override void Generate(IGqlpEnum ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EncoderHeader, EnumMembers, EnumClassMember);
}
