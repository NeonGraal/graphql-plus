namespace GqlPlus.Generating;

internal interface ITypeGenerator
{
  bool ForType(IGqlpType ast);
  void GenerateType(IGqlpType ast, GeneratorContext context);
}
