namespace GqlPlus.Generating.Simple;

internal sealed class UnionGenerator
  : GenerateForSimple<IGqlpUnion>
{
  public override string TypePrefix => "Union";

  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpUnion ast, GeneratorContext context)
    => ast.Items.Select(item => new MapPair<string>("As" + item.Name, item.Name));
}
