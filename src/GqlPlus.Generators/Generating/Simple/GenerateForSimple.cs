
namespace GqlPlus.Generating.Simple;

internal abstract class
  GenerateForSimple<T>
  : GenerateForClass<T>
  where T : IGqlpSimple
{
  protected override void ClassHeader(T ast, GqlpGeneratorContext context)
  {
    base.ClassHeader(ast, context);

    string interfaceSep = ":";

    if (ast.Parent is not null) {
      context.Write("  : " + TypePrefix + context.TypeName(ast.Parent));
      interfaceSep = ",";
    } else if (HasDefaultParent(out string? defaultParent)) {
      context.Write("  : " + defaultParent);
      interfaceSep = ",";
    }

    context.Write("  " + interfaceSep + " I" + context.TypeName(ast));
  }

  protected override void InterfaceHeader(T ast, GqlpGeneratorContext context)
  {
    base.InterfaceHeader(ast, context);

    if (ast.Parent is not null) {
      context.Write("  : I" + context.TypeName(ast.Parent));
    } else if (HasDefaultParent(out string? defaultParent)) {
      context.Write("  : I" + defaultParent);
    }
  }

  protected virtual bool HasDefaultParent(out string? defaultParent)
  {
    defaultParent = null;
    return false;
  }
}
