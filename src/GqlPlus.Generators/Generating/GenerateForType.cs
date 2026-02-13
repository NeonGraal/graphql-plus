
namespace GqlPlus.Generating;

internal abstract class GenerateForType<T>
  : ITypeGenerator
  where T : IGqlpType
{
  public bool ForType(IGqlpType ast)
    => ast is T;

  public void GenerateType(IGqlpType ast, GqlpGeneratorContext context)
    => Generate((T)ast, context);

  protected delegate void GenerateDelegate(T ast, GqlpGeneratorContext context);
  protected delegate IEnumerable<MapPair<string>> GenerateMembers(T ast, GqlpGeneratorContext context);
  protected delegate void GenerateMember(MapPair<string> item, GqlpGeneratorContext context);

  protected Dictionary<GqlpGeneratorType, GenerateDelegate> _generators = [];

  protected GenerateForType()
    => _generators[GqlpGeneratorType.Interface] = GenerateBlock(InterfaceHeader, InterfaceMember);

  private void Generate(T ast, GqlpGeneratorContext context)
  {
    if (_generators.TryGetValue(context.GeneratorOptions.GeneratorType, out GenerateDelegate? generator)) {
      generator(ast, context);
    }
  }

  protected GenerateDelegate GenerateBlock(GenerateDelegate head, GenerateMember member)
    => (ast, context) => GenerateBlock(ast, context, head, TypeMembers, member);

  protected static void GenerateBlock(T ast, GqlpGeneratorContext context, GenerateDelegate head, GenerateMembers members, GenerateMember member)
  {
    context.Write("");
    head(ast, context);
    context.Write("{");
    foreach (MapPair<string> item in members(ast, context)) {
      member(item, context);
    }

    context.Write("}");
  }

  protected virtual void InterfaceHeader(T ast, GqlpGeneratorContext context)
    => context.Write("public interface " + context.TypeName(ast, "I"));

  protected virtual void InterfaceMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value} {item.Key} {{ get; }}");

  internal abstract IEnumerable<MapPair<string>> TypeMembers(T ast, GqlpGeneratorContext context);
}
