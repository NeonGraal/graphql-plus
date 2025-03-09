namespace GqlPlus.Generating;

internal abstract class GenerateForType<TAst>
  : ITypeGenerator
  where TAst : IGqlpType
{
  public bool ForType(IGqlpType ast)
    => ast is TAst;

  public void GenerateType(IGqlpType ast, GeneratorContext context)
    => Generate((TAst)ast, context);

  protected abstract void Generate(TAst ast, GeneratorContext context);
}
