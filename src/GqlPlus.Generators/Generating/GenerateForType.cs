
namespace GqlPlus.Generating;

internal abstract class GenerateForType<TType>
  : ITypeGenerator
  where TType : IGqlpType
{
  public bool ForType(IGqlpType ast)
  => ast is TType;

  public void GenerateType(IGqlpType ast, GqlpGeneratorContext context)
    => Generate((TType)ast, context);

  protected delegate void GenerateDelegate(TType ast, GqlpGeneratorContext context);
  protected delegate IEnumerable<TItem> GenerateMembers<TItem>(TType ast, GqlpGeneratorContext context);
  protected delegate void GenerateMember<TItem>(TItem item, GqlpGeneratorContext context);

  protected Dictionary<GqlpGeneratorType, GenerateDelegate> _generators = [];

  private void Generate(TType ast, GqlpGeneratorContext context)
  {
    if (_generators.TryGetValue(context.GeneratorOptions.GeneratorType, out GenerateDelegate? generator)) {
      generator(ast, context);
    }
  }

  protected static GenerateDelegate GenerateBlock<TItem>(GenerateDelegate head, GenerateMembers<TItem> members, GenerateMember<TItem> member)
    => (ast, context) => GenerateBlock(ast, context, head, members, member);

  protected static void GenerateBlock<TItem>(TType ast, GqlpGeneratorContext context, GenerateDelegate head, GenerateMembers<TItem> members, GenerateMember<TItem> member)
  {
    context.Write("");
    head(ast, context);
    context.Write("{");
    foreach (TItem item in members(ast, context)) {
      member(item, context);
    }

    context.Write("}");
  }
}
