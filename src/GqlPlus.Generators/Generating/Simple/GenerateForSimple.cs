namespace GqlPlus.Generating.Simple;

internal abstract class GenerateForSimple<T>
  : GenerateForClass<T>
  where T : IGqlpSimple
{
  protected override void ClassHeader(T ast, GeneratorContext context)
  {
    base.ClassHeader(ast, context);

    if (!string.IsNullOrWhiteSpace(ast.Parent?.Name)) {
      context.AppendLine("  : " + TypePrefix + ast.Parent);
      context.AppendLine("  , I" + ast.Name);
    } else {
      context.AppendLine("  : I" + ast.Name);
    }
  }

  protected override void TypeHeader(T ast, GeneratorContext context)
  {
    base.TypeHeader(ast, context);

    if (!string.IsNullOrWhiteSpace(ast.Parent?.Name)) {
      context.AppendLine("  : I" + ast.Parent);
    }
  }
}
