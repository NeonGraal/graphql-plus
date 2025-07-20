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
    context.AppendLine("");

    TypeHeader(ast, context);
    context.AppendLine("{");
    TypeBody(ast, context);
    context.AppendLine("}");
  }

  protected virtual void TypeBody(T ast, GqlpGeneratorContext context)
  {
    foreach (MapPair<string> item in TypeMembers(ast, context)) {
      TypeMember(item, context);
    }
  }

  protected virtual void TypeHeader(T ast, GqlpGeneratorContext context)
    => context.AppendLine($"public interface I{ast.Name}");

  protected virtual void TypeMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.AppendLine($"  {item.Value} {item.Key} {{ get; }}");

  internal abstract IEnumerable<MapPair<string>> TypeMembers(T ast, GqlpGeneratorContext context);
}
