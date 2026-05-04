namespace GqlPlus.Parser;

public class ParserRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact]
  public void CommonParsers()
    => ParserRepoWrapper.WriteTree("CommonParser", outputHelper.ToLoggerFactory(), b => b.AddCommonParsers());

  [Fact]
  public void OperationParsers()
    => ParserRepoWrapper.WriteTree("OperationParser", outputHelper.ToLoggerFactory(), b => b.AddOperationParsers());

  [Fact]
  public void SchemaParsers()
    => ParserRepoWrapper.WriteTree("SchemaParser", outputHelper.ToLoggerFactory(), b => b.AddSchemaParsers());
}
