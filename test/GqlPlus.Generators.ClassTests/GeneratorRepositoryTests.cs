using GqlPlus.Generating;

namespace GqlPlus;

public class GeneratorRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact]
  public void Generators()
    => GeneratorRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(), b => b.AddSchemaGenerators());
}
