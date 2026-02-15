
namespace GqlPlus.Generating.Simple;

internal abstract class GenerateForSimple<TSimple>
  : GenerateForClass<TSimple, MapPair<string>>
  where TSimple : IGqlpSimple
{
  protected override void ClassHeader(TSimple ast, GqlpGeneratorContext context)
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
  protected override void ClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public {item.Value} {item.Key} {{ get; set; }}");

  protected override void InterfaceHeader(TSimple ast, GqlpGeneratorContext context)
  {
    base.InterfaceHeader(ast, context);

    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent, "I"));
    } else if (HasDefaultParent(out string? defaultParent)) {
      context.Write("  : I" + defaultParent);
    }
  }

  protected override void InterfaceMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value} {item.Key} {{ get; }}");

  protected abstract bool HasDefaultParent(out string? defaultParent);
}
