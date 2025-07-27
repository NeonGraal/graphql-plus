namespace GqlPlus.Generating.Simple;

internal abstract class GenerateForSimple<T>
  : GenerateForClass<T>
  where T : IGqlpSimple
{
  protected override void ClassHeader(T ast, GqlpGeneratorContext context)
  {
    base.ClassHeader(ast, context);

    if (!string.IsNullOrWhiteSpace(ast.Parent?.Name)) {
      context.Write("  : " + TypePrefix + ast.Parent!.Name);
      context.Write("  , I" + ast.Name);
    } else {
      context.Write("  : I" + ast.Name);
    }
  }

  protected override void InterfaceHeader(T ast, GqlpGeneratorContext context)
  {
    base.InterfaceHeader(ast, context);

    if (!string.IsNullOrWhiteSpace(ast.Parent?.Name)) {
      context.Write("  : I" + ast.Parent!.Name);
    }
  }
}
