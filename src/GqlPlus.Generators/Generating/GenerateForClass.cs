namespace GqlPlus.Generating;

internal abstract class GenerateForClass<T>
  : GenerateForType<T>
  where T : IGqlpType
{
  protected GenerateForClass()
    => _generators[GqlpGeneratorType.Implementation] = GenerateBlock(ClassHeader, ClassMember);

  protected virtual void ClassHeader(T ast, GqlpGeneratorContext context)
    => context.Write("public class " + context.TypeName(ast, ""));

  protected virtual void ClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public {item.Value} {item.Key} {{ get; set; }}");
}
