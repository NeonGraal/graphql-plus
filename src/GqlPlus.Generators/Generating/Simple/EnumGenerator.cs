
namespace GqlPlus.Generating.Simple;

internal sealed class EnumGenerator
  : GenerateForType<IGqlpEnum>
{
  public override string TypePrefix => "Enum";

  protected override void Generate(IGqlpEnum ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Enum) {
      base.Generate(ast, context);
    }
  }

  private static IEnumerable<MapPair<string>> ParentItems(string? parent, GqlpGeneratorContext context)
  {
    IGqlpEnum? ast = context.GetTypeAst<IGqlpEnum>(parent);
    if (parent is null || ast is null) {
      return [];
    }

    IEnumerable<MapPair<string>> members = ast.Items.SelectMany(item => {
      string suffix = " = " + parent + "." + item.Name;
      return item.Aliases
        .Select(alias => new MapPair<string>(alias, suffix))
        .Prepend(new MapPair<string>(item.Name, suffix));
    });

    return ParentItems(ast.Parent?.Name, context).Concat(members);
  }

  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpEnum ast, GqlpGeneratorContext context)
  {
    IEnumerable<MapPair<string>> members = ast.Items.SelectMany(item =>
      item.Aliases
        .Select(alias => new MapPair<string>(alias, " = " + item.Name))
        .Prepend(new MapPair<string>(item.Name, "")));

    return ParentItems(ast.Parent?.Name, context).Concat(members);
  }

  protected override void TypeHeader(IGqlpEnum ast, GqlpGeneratorContext context)
    => context.AppendLine($"public enum {ast.Name}");

  protected override void TypeMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.AppendLine("  " + item.Key + item.Value + ",");
}
