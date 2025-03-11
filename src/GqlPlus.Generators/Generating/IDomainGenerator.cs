namespace GqlPlus.Generating;

internal interface IDomainGenerator
{
  bool ForDomain(IGqlpDomain ast);
  void GenerateDomain(IGqlpDomain ast, GeneratorContext context);
}
