namespace GqlPlus.Generating;

internal interface ITypeGenerator
{
  GqlpGeneratorType GeneratorType { get; }
  bool ForType(IGqlpType ast, GqlpGeneratorType generatorType);
  void GenerateType(IGqlpType ast, GqlpGeneratorContext context);
}
