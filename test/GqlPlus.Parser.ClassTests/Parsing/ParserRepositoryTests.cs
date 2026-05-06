using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Parsing;

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

internal sealed class ParserRepoWrapper(
  IParserRepository repo
) : RepositoryWrapperBase<IParserRepository, ParserRepoWrapper>(repo)
  , IParserRepository
{
  public override IParserRepository Wrapper => this;

  public static void WriteTree(string label, ILoggerFactory loggerFactory, Action<IParserRepositoryBuilder> configure)
  {
    ParserRepositoryBuilder repoBuilder = new();
    configure(repoBuilder);

    ParserRepoWrapper repo = new(new ParserRepository(repoBuilder, loggerFactory));
    repo.WriteFactories(label, repoBuilder.AllFactories);
  }

  public Parser<T>.LA ArrayFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .ArrayFor<T>(callerName);
  public IEnumerable<IParseDeclaration> GetDeclarations([CallerMemberName] string callerName = "")
    => AddRelationship<IParseDeclaration>(callerName)
      .GetDeclarations(callerName);
  public IEnumerable<IParseDomain> GetDomains([CallerMemberName] string callerName = "")
    => repo // AddRelationship<IParseDomain>(callerName)
      .GetDomains(callerName);
  public T GetName<T>([CallerMemberName] string callerName = "")
    where T : INameParser
    => AddRelationship<T>(callerName)
      .GetName<T>(callerName);
  public Parser<T>.L ParserFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .ParserFor<T>(callerName);

  public ParserArray<TInterface, TFor>.LA ArrayFor<TInterface, TFor>(string callerName)
    where TInterface : class, Parser<TFor>.IA
    => AddRelationship<TInterface>(callerName)
      .ArrayFor<TInterface, TFor>(callerName);
  public Parser<TInterface, TFor>.L ParserFor<TInterface, TFor>(string callerName)
    where TInterface : class, Parser<TFor>.I
    => AddRelationship<TInterface>(callerName)
      .ParserFor<TInterface, TFor>(callerName);
}
