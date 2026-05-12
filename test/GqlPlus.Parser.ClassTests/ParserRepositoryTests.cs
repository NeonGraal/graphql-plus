using GqlPlus.Ast.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class ParserRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact, Trait("Generate", "Html")]
  public void CommonParsers()
    => ParserRepoWrapper.WriteTree("Common", outputHelper.ToLoggerFactory(), b => b.AddCommonParsers());

  [Fact, Trait("Generate", "Html")]
  public void OperationParsers()
    => ParserRepoWrapper.WriteTree("Operation", outputHelper.ToLoggerFactory(), b => b.AddOperationParsers());

  [Fact, Trait("Generate", "Html")]
  public void SchemaParsers()
    => ParserRepoWrapper.WriteTree("Schema", outputHelper.ToLoggerFactory(), b => b.AddSchemaParsers());

  [Fact, Trait("Generate", "Html")]
  public void Mergers()
    => MergerRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(), b => b.AddSchemaMergers());

  [Fact]
  public void MergerRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMergers(b => { })
      .BuildServiceProvider();

    services.GetService<IMergerRepository>()
        .ShouldNotBeNull()
        .AllMergersFor<IAstEnum>()()
        .ShouldNotBeNull()
        .ShouldBeEmpty();
  }

  [Fact]
  public void ParserRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddParsers(b => { })
      .BuildServiceProvider();

    services.GetService<IParserRepository>()
        .ShouldNotBeNull();
  }

  private const string TestSchema = """
    domain TestDom { string /test/ }
    dual TestDual { | TestDom }
    """;

  [Fact]
  public void GetSchemaParser()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddParsers(b => b
        .AddCommonParsers()
        .AddSchemaParsers())
      .BuildServiceProvider();

    ParserOne<IAstSchema> schemaParser = services.GetService<IParserRepository>()
        .ShouldNotBeNull()
        .ParserFor<IAstSchema>();

    IResult<IAstSchema> result = schemaParser.Parse(new Tokenizer(TestSchema), "Test")
        .ShouldNotBeNull();
  }
}
