namespace GqlPlus.Generating;

internal abstract class GenerateForClass<T>
  : GenerateForType<T>
  where T : IGqlpType
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
    => context.AppendLine($"public class {TypePrefix}{ast.Name}");

  protected virtual void ClassMember(MapPair<string> item, GeneratorContext context)
    => context.AppendLine($"  public {item.Value} {item.Key} {{ get; set; }}");
}
