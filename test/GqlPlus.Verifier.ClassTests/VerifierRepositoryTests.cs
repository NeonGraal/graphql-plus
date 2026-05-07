using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying;

namespace GqlPlus;

public class VerifierRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact]
  public void Matchers()
    => MatcherRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddConstraintMatchers());

  [Fact]
  public void Verifiers()
    => VerifierRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaVerifiers(),
      m => m.AddConstraintMatchers(),
      m => m.AddSchemaMergers());
}
