namespace GqlPlus.Generating;

internal abstract class GenerateForType<T>
  : ITypeGenerator
  where T : IGqlpType
{
  public abstract string TypePrefix { get; }

  public bool ForType(IGqlpType ast)
    => ast is T;

  public void GenerateType(IGqlpType ast, GeneratorContext context)
    => Generate((T)ast, context);

  protected virtual void Generate(T ast, GeneratorContext context)
  {
    context.AppendLine("");

    TypeHeader(ast, context);
    context.AppendLine("{");
    TypeBody(ast, context);
    context.AppendLine("}");
  }

  protected virtual void TypeBody(T ast, GeneratorContext context)
  {
    foreach (MapPair<string> item in TypeMembers(ast, context)) {
      TypeMember(item, context);
    }
  }

  protected virtual void TypeHeader(T ast, GeneratorContext context)
    => context.AppendLine($"public interface I{ast.Name}");

  protected virtual void TypeMember(MapPair<string> item, GeneratorContext context)
    => context.AppendLine($"  {item.Value} {item.Key} {{ get; }}");

  internal abstract IEnumerable<MapPair<string>> TypeMembers(T ast, GeneratorContext context);
}
