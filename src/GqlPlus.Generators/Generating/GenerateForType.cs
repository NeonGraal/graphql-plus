namespace GqlPlus.Generating;

internal abstract class GenerateForType<T>
  : ITypeGenerator
  where T : IGqlpType
{
  public abstract string TypePrefix { get; }

  public bool ForType(IGqlpType ast)
    => ast is T;

  public void GenerateType(IGqlpType ast, GqlpGeneratorContext context)
    => Generate((T)ast, context);

  protected virtual void Generate(T ast, GqlpGeneratorContext context)
  {
    context.Write("");

    TypeHeader(ast, context);
    context.Write("{");
    TypeBody(ast, context);
    context.Write("}");
  }

  protected virtual void TypeBody(T ast, GqlpGeneratorContext context)
  {
    foreach (MapPair<string> item in TypeMembers(ast, context)) {
      TypeMember(item, context);
    }
  }

  protected virtual void TypeHeader(T ast, GqlpGeneratorContext context)
    => context.Write($"public interface I{ast.Name}");

  protected virtual void TypeMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value} {item.Key} {{ get; }}");

  internal abstract IEnumerable<MapPair<string>> TypeMembers(T ast, GqlpGeneratorContext context);
}
