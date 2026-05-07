using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Generating;

public class GeneratorRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact]
  public void Generators()
    => GeneratorRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(), b => b.AddSchemaGenerators());
}

internal sealed class GeneratorRepoWrapper(
  IGeneratorRepository repo
) : RepositoryWrapperBase<IGeneratorRepository, GeneratorRepoWrapper>(repo)
  , IGeneratorRepository
{
  public override IGeneratorRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public static void WriteTree(ILoggerFactory loggerFactory, Action<IGeneratorRepositoryBuilder> configure)
  {
    GeneratorRepositoryBuilder repoBuilder = new();
    configure(repoBuilder);

    GeneratorRepoWrapper repo = new(new GeneratorRepository(repoBuilder, loggerFactory));
    repo.WriteFactories("Generator", repoBuilder.AllFactories);
  }

  public IGenerator<TAst> GeneratorFor<TAst>([CallerMemberName] string callerName = "")
    where TAst : IAstError
    => AddRelationship<TAst>(callerName)
      .GeneratorFor<TAst>(callerName);
  public IEnumerable<ITypeGenerator> TypeGenerators(GqlpGeneratorType generatorType, [CallerMemberName] string callerName = "")
    => AddRelationship<ITypeGenerator>(callerName)
      .TypeGenerators(generatorType, callerName);
}
