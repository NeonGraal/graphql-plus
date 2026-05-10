using System.Runtime.CompilerServices;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

internal class ParserRepository(
  ParserRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IParserRepository>(loggerFactory)
  , IParserRepository
{
  public ParserOne<T>.D ParserFor<T>([CallerMemberName] string callerName = "")
    => () => Cached<T, IParser<T>>(builder.Singles, "single parser for " + callerName, this);

  public ParserArray<T>.D ArrayFor<T>([CallerMemberName] string callerName = "")
    => () => Cached<T, IParserArray<T>>(builder.Arrays, "array parser for " + callerName, this);

  public Parser<TInterface, TFor>.D ParserFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, IParser<TFor>
    => () => Cached<TInterface, TInterface>(builder.InterfaceSingles, "interface parser for " + callerName, this);
  public ParserArray<TInterface, TFor>.D ArrayFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, IParserArray<TFor>
    => () => Cached<TInterface, TInterface>(builder.InterfaceArrays, "interface array parser for " + callerName, this);

  public DeferList<IParseDeclaration>.D GetDeclarations([CallerMemberName] string callerName = "")
    => () => builder.Declarations.Keys.Select(f
      => (IParseDeclaration)Cached(builder.Declarations, f, f, "declaration parsers for " + callerName, this));

  public DeferList<IParseDomain>.D GetDomains([CallerMemberName] string callerName = "")
    => () => builder.Domains.Select(t
      => (IParseDomain)Cached(builder.Singles, t.Key, t.Value, "domain parsers for " + callerName, this));
  public DeferOne<T>.D GetName<T>([CallerMemberName] string callerName = "")
    where T : class, INameParser
    => () => Cached<T, T>(builder.InterfaceSingles, "name parser for " + callerName, this);
}
