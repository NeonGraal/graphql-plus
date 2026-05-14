using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Parsing;

internal sealed class ParserRepoWrapper(
  IParserRepository repo
) : RepositoryWrapperBase<IParserRepository, ParserRepoWrapper>(repo)
  , IParserRepository
{
  protected override IParserRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public static void WriteTree(string label, ILoggerFactory loggerFactory, Action<IParserRepositoryBuilder> configure)
  {
    ParserRepositoryBuilder repoBuilder = new();
    configure(repoBuilder);

    ParserRepoWrapper repo = new(new ParserRepository(repoBuilder, loggerFactory));
    repo.WriteFactories(label + "Parser", repoBuilder.AllFactories);
  }

  public ParserArray<T>.D ArrayFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .ArrayFor<T>(callerName);
  public DeferList<IParseDeclaration>.D GetDeclarations([CallerMemberName] string callerName = "")
    => AddRelationship<IParseDeclaration>(callerName)
      .GetDeclarations(callerName);
  public DeferList<IParseDomain>.D GetDomains([CallerMemberName] string callerName = "")
    => repo // AddRelationship<IParseDomain>(callerName)
      .GetDomains(callerName);
  public ParserName<T>.D GetName<T>([CallerMemberName] string callerName = "")
    where T : class, INameParser
    => AddRelationship<T>(callerName)
      .GetName<T>(callerName);
  public ParserOne<T>.D ParserFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .ParserFor<T>(callerName);

  public DeferOne<TInterface>.D ArrayFor<TInterface, TFor>(string callerName)
    where TInterface : class, IParserArray<TFor>
    => AddRelationship<TInterface>(callerName)
      .ArrayFor<TInterface, TFor>(callerName);
  public ParserOne<TInterface, TFor>.D ParserFor<TInterface, TFor>(string callerName)
    where TInterface : class, IParser<TFor>
    => AddRelationship<TInterface>(callerName)
      .ParserFor<TInterface, TFor>(callerName);
}
