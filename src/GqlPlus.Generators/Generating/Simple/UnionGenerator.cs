namespace GqlPlus.Generating.Simple;

internal abstract class UnionGeneratorBase
  : GenerateForSimple<IGqlpUnion>
{
  protected override bool HasDefaultParent(out string? defaultParent)
  {
    defaultParent = null;
    return false;
  }

  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpUnion ast, GqlpGeneratorTypes types)
    => ast.Items.Select(item => new MapPair<string>("As" + item.Name, item.Name));
}

internal sealed class UnionInterfaceGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IGqlpUnion ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class UnionModelGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IGqlpUnion ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}
