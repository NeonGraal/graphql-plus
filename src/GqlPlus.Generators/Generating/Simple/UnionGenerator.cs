using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating.Simple;

internal abstract class UnionGeneratorBase
  : GenerateForSimple<IAstUnion>
{
  protected override bool HasDefaultParent(out string? defaultParent)
  {
    defaultParent = null;
    return false;
  }

  internal override IEnumerable<MapPair<string>> TypeMembers(IAstUnion ast, GqlpGeneratorTypes types)
    => ast.Items.Select(item => new MapPair<string>("As" + item.Name, item.Name));
}

internal sealed class UnionInterfaceGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class UnionModelGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}

internal sealed class UnionDecoderGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class UnionEncoderGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EncoderHeader, TypeMembers, ClassMember);
}
