namespace GqlPlus.Generating.Simple;

internal abstract class GenerateForSimple<T>
  : GenerateForType<T>
  where T : IGqlpSimple
{
  protected override void Generate(T ast, GeneratorContext context)
  {
    base.Generate(ast, context);

    ClassHeader(ast, context);
    context.AppendLine("{");
    ClassBody(ast, context);
    context.AppendLine("}");
  }

  protected virtual void ClassBody(T ast, GeneratorContext context)
  {
    foreach (MapPair<string> item in TypeMembers(ast, context)) {
      ClassMember(item, context);
    }
  }

  protected virtual void ClassHeader(T ast, GeneratorContext context)
  {
    context.AppendLine($"public class {TypePrefix}{ast.Name}");

    if (!string.IsNullOrWhiteSpace(ast.Parent)) {
      context.AppendLine("  : " + TypePrefix + ast.Parent);
      context.AppendLine("  , I" + ast.Name);
    } else {
      context.AppendLine("  : I" + ast.Name);
    }
  }

  protected virtual void ClassMember(MapPair<string> item, GeneratorContext context)
    => context.AppendLine($"  public {item.Value} {item.Key} {{ get; set; }}");

  protected override void TypeHeader(T ast, GeneratorContext context)
  {
    base.TypeHeader(ast, context);

    if (!string.IsNullOrWhiteSpace(ast.Parent)) {
      context.AppendLine("  : I" + ast.Name);
    }
  }
}
