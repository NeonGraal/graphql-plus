namespace GqlPlus.Generating.Simple;

internal abstract class GenerateForSimple<TSimple>
  : GenerateForClass<TSimple, MapPair<string>>
  where TSimple : IAstSimple
{
  protected override void ClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public {item.Value} {item.Key} {{ get; set; }}");

  protected abstract bool HasDefaultParent(out string? defaultParent);

  protected override string TypeHeader(TSimple ast, GqlpGeneratorContext context, string type, string prefix, GqlpBaseType baseType)
  {
    context.Write($"public {type} " + context.TypeName(ast, prefix));

    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent, prefix));
      return ",";
    }

    if (HasDefaultParent(out string? defaultParent)) {
      context.Write("  : " + prefix + defaultParent);
      return ",";
    }

    if (context.GeneratorOptions.BaseType == baseType) {
      context.Write("  : " + context.GeneratorOptions.BaseName);
      return ",";
    }

    context.Write($"  // No Base because it's {context.GeneratorOptions.BaseType}");
    return ":";
  }
}
