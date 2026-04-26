namespace GqlPlus.Generating;

internal abstract class GenerateForType<TType>
  : ITypeGenerator
  where TType : IAstType
{
  public bool ForType(IAstType ast)
    => ast is TType;

  public void GenerateType(IAstType ast, GqlpGeneratorContext context)
  {
    if (ast is TType type) {
      Generate(type, context);
    }
  }

  protected abstract void Generate(TType ast, GqlpGeneratorContext context);

  protected virtual void DecoderHeader(TType ast, GqlpGeneratorContext context)
    => context.Write("internal class " + context.TypeName(ast, "") + "Decoder");

  protected delegate void GenerateDelegate(TType ast, GqlpGeneratorContext context);
  protected delegate IEnumerable<TItem> GenerateMembers<TItem>(TType ast, GqlpGeneratorContext context);
  protected delegate void GenerateMember<TItem>(TItem item, GqlpGeneratorContext context);

  protected static void GenerateBlock<TItem>(
    TType ast,
    GqlpGeneratorContext context,
    GenerateDelegate head,
    GenerateMembers<TItem> members,
    GenerateMember<TItem> member,
    GenerateDelegate? tail = null)
  {
    context.Write("");
    head(ast, context);
    context.Write("{");
    foreach (TItem item in members(ast, context)) {
      member(item, context);
    }

    tail?.Invoke(ast, context);
    context.Write("}");
  }
}
