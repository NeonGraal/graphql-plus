namespace GqlPlus.Generating.Simple;

internal sealed class UnionGenerator
  : GenerateForSimple<IGqlpUnion>
{
  protected override bool HasDefaultParent(out string? defaultParent)
  {
    defaultParent = null;
    return false;
  }

  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpUnion ast, GqlpGeneratorContext context)
    => ast.Items.Select(item => new MapPair<string>("As" + item.Name, item.Name));
}
