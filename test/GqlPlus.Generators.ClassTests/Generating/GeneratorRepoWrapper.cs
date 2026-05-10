using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Generating;

internal sealed class GeneratorRepoWrapper(
  IGeneratorRepository repo
) : RepositoryWrapperBase<IGeneratorRepository, GeneratorRepoWrapper>(repo)
  , IGeneratorRepository
{
  protected override IGeneratorRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public static void WriteTree(ILoggerFactory loggerFactory, Action<IGeneratorRepositoryBuilder> configure)
  {
    GeneratorRepositoryBuilder repoBuilder = new();
    configure(repoBuilder);

    GeneratorRepoWrapper repo = new(new GeneratorRepository(repoBuilder, loggerFactory));
    repo.WriteFactories("Generator", repoBuilder.AllFactories);
  }

  public Defer<IGenerator<TAst>>.D GeneratorFor<TAst>([CallerMemberName] string callerName = "")
    where TAst : IAstError
    => AddRelationship<TAst>(callerName)
      .GeneratorFor<TAst>(callerName);

  public Defer<ITypeGenerator>.DA TypeGenerators(GqlpGeneratorType generatorType, [CallerMemberName] string callerName = "")
    => AddRelationship<ITypeGenerator>(callerName)
      .TypeGenerators(generatorType, callerName);
}
