using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class ParserRepositoryTests(
  ITestOutputHelper outputHelper
) : SubstituteBase
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
  public void GetDomainMerger()
  {
    // Arrange
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMergers(b => b.AddSchemaMergers())
      .BuildServiceProvider();

    MergerOne<IAstDomain> merger = services.GetService<IMergerRepository>()
        .ShouldNotBeNull()
        .MergerFor<IAstDomain>();

    IAstDomainRegex domainRegex1 = A.ItemRegex("Test1");
    IAstDomainRegex domainRegex2 = A.ItemRegex("Test2");
    IAstDomain domain1 = new AstDomain<DomainRegexAst, IAstDomainRegex>(AstNulls.At, "Test", DomainKind.String, [domainRegex1]);
    IAstDomain domain2 = A.Domain("Test", DomainKind.String, domainRegex2);

    // Act
    IEnumerable<IAstDomain> result = merger.ShouldNotBeNull()
      .Merge([domain1, domain2]);

    result.ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        d => d.Name.ShouldBe("Test"),
        d => d.DomainKind.ShouldBe(DomainKind.String));
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
