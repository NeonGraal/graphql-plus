namespace GqlPlus.Generating;

internal interface ITypeGenerator
{
  bool ForType(IGqlpType ast, GqlpGeneratorType generatorType);
  void GenerateType(IGqlpType ast, GqlpGeneratorContext context);
}
