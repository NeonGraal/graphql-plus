using GqlPlus.Merging;
using GqlPlus.Parsing;

namespace GqlPlus;

public class ParserRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact]
  public void CommonParsers()
    => ParserRepoWrapper.WriteTree("Common", outputHelper.ToLoggerFactory(), b => b.AddCommonParsers());

  [Fact]
  public void OperationParsers()
    => ParserRepoWrapper.WriteTree("Operation", outputHelper.ToLoggerFactory(), b => b.AddOperationParsers());

  [Fact]
  public void SchemaParsers()
    => ParserRepoWrapper.WriteTree("Schema", outputHelper.ToLoggerFactory(), b => b.AddSchemaParsers());

  [Fact]
  public void Mergers()
    => MergerRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(), b => b.AddSchemaMergers());
}
