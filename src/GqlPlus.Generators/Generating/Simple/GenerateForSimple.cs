
namespace GqlPlus.Generating.Simple;

internal abstract class GenerateForSimple<TSimple>
  : GenerateForClass<TSimple, MapPair<string>>
  where TSimple : IGqlpSimple
{
  protected override void ClassHeader(TSimple ast, GqlpGeneratorContext context)
  {
    context.Write("public class " + context.TypeName(ast, ""));

    string interfaceSep = ":";

    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent, ""));
      interfaceSep = ",";
    } else if (HasDefaultParent(out string? defaultParent)) {
      context.Write("  : " + defaultParent);
      interfaceSep = ",";
    } else if (context.GeneratorOptions.BaseType == GqlpBaseType.Class) {
      context.Write("  : " + context.GeneratorOptions.BaseName);
      interfaceSep = ",";
    } else {
      context.Write($"  // No Base because it's {context.GeneratorOptions.BaseType}");
    }

    context.Write("  " + interfaceSep + " " + context.TypeName(ast, "I"));
  }
  protected override void ClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public {item.Value} {item.Key} {{ get; set; }}");

  protected override void InterfaceHeader(TSimple ast, GqlpGeneratorContext context)
  {
    context.Write("public interface " + context.TypeName(ast, "I"));
    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent, "I"));
    } else if (HasDefaultParent(out string? defaultParent)) {
      context.Write("  : I" + defaultParent);
    } else if (context.GeneratorOptions.BaseType == GqlpBaseType.Interface) {
      context.Write("  : " + context.GeneratorOptions.BaseName);
    } else {
      context.Write($"  // No Base because it's {context.GeneratorOptions.BaseType}");
    }
  }

  protected override void InterfaceMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value} {item.Key} {{ get; }}");

  protected abstract bool HasDefaultParent(out string? defaultParent);
}
