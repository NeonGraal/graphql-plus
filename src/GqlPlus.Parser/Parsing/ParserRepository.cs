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
  public Parser<T>.D ParserFor<T>([CallerMemberName] string callerName = "")
    => () => Cached<T, Parser<T>.I>(builder.Singles, "single parser for " + callerName, this);

  public Parser<T>.DA ArrayFor<T>([CallerMemberName] string callerName = "")
    => () => Cached<T, Parser<T>.IA>(builder.Arrays, "array parser for " + callerName, this);

  public Parser<TInterface, TFor>.D ParserFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, Parser<TFor>.I
    => () => Cached<TInterface, TInterface>(builder.InterfaceSingles, "interface parser for " + callerName, this);
  public ParserArray<TInterface, TFor>.DA ArrayFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, Parser<TFor>.IA
    => () => Cached<TInterface, TInterface>(builder.InterfaceArrays, "interface array parser for " + callerName, this);

  public Defer<IParseDeclaration>.DA GetDeclarations([CallerMemberName] string callerName = "")
    => () => builder.Declarations.Keys.Select(f
      => (IParseDeclaration)Cached(builder.Declarations, f, f, "declaration parsers for " + callerName, this));

  public Defer<IParseDomain>.DA GetDomains([CallerMemberName] string callerName = "")
    => () => builder.Domains.Select(t
      => (IParseDomain)Cached(builder.Singles, t.Key, t.Value, "domain parsers for " + callerName, this));
  public Defer<T>.D GetName<T>([CallerMemberName] string callerName = "")
    where T : class, INameParser
    => () => Cached<T, T>(builder.InterfaceSingles, "name parser for " + callerName, this);
}
