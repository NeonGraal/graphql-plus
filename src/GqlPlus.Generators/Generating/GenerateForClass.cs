namespace GqlPlus.Generating;

internal abstract class GenerateForClass<T>
  : GenerateForType<T>
  where T : IGqlpType
{
  protected override void Generate(T ast, GqlpGeneratorContext context)
  {
    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Interface) {
      base.Generate(ast, context);
    }

    if (context.GeneratorOptions.GeneratorType == GqlpGeneratorType.Implementation) {
      ClassHeader(ast, context);
      context.Write("{");
      ClassBody(ast, context);
      context.Write("}");
    }
  }

  protected virtual void ClassBody(T ast, GqlpGeneratorContext context)
  {
    foreach (MapPair<string> item in TypeMembers(ast, context)) {
      ClassMember(item, context);
    }
  }

  protected virtual void ClassHeader(T ast, GqlpGeneratorContext context)
    => context.Write($"public class {TypePrefix}{ast.Name}");

  protected virtual void ClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public {item.Value} {item.Key} {{ get; set; }}");
}
