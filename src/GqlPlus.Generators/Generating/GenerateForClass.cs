namespace GqlPlus.Generating;

internal abstract class GenerateForClass<T>
  : GenerateForType<T>
  where T : IGqlpType
{
  protected override void Generate(T ast, GqlpGeneratorContext context)
  {
    base.Generate(ast, context);

    ClassHeader(ast, context);
    context.AppendLine("{");
    ClassBody(ast, context);
    context.AppendLine("}");
  }

  protected virtual void ClassBody(T ast, GqlpGeneratorContext context)
  {
    foreach (MapPair<string> item in TypeMembers(ast, context)) {
      ClassMember(item, context);
    }
  }

  protected virtual void ClassHeader(T ast, GqlpGeneratorContext context)
    => context.AppendLine($"public class {TypePrefix}{ast.Name}");

  protected virtual void ClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.AppendLine($"  public {item.Value} {item.Key} {{ get; set; }}");
}
