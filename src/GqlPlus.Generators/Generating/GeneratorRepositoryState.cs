namespace GqlPlus.Generating;

internal sealed class GeneratorRepositoryState(
  BaseFactory<IGeneratorRepository>.FactoryDict generators,
  List<Factory<ITypeGenerator, IGeneratorRepository>> typeGeneratorFactories
) : BaseFactory<IGeneratorRepository>
{
  internal FactoryDict Generators { get; } = generators;
  internal List<Factory<ITypeGenerator, IGeneratorRepository>> TypeGeneratorFactories { get; } = typeGeneratorFactories;
}