
namespace GqlPlus.Generating.Simple;

internal abstract class GenerateForSimple<T>
  : GenerateForClass<T>
  where T : IGqlpSimple
{
  protected override void ClassHeader(T ast, GqlpGeneratorContext context)
  {
    base.ClassHeader(ast, context);

    string interfaceSep = ":";

    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent, ""));
      interfaceSep = ",";
    } else if (HasDefaultParent(out string? defaultParent)) {
      context.Write("  : " + defaultParent);
      interfaceSep = ",";
    }

    context.Write("  " + interfaceSep + " " + context.TypeName(ast, "I"));
  }

  protected override void InterfaceHeader(T ast, GqlpGeneratorContext context)
  {
    base.InterfaceHeader(ast, context);

    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent, "I"));
    } else if (HasDefaultParent(out string? defaultParent)) {
      context.Write("  : I" + defaultParent);
    }
  }

  protected abstract bool HasDefaultParent(out string? defaultParent);
}
