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
  public Parser<T>.L ParserFor<T>([CallerMemberName] string callerName = "")
    => (Parser<T>.D)(() => Cached<T, Parser<T>.I>(builder.Singles, "single parser for " + callerName, this));

  public Parser<T>.LA ArrayFor<T>([CallerMemberName] string callerName = "")
    => (Parser<T>.DA)(() => Cached<T, Parser<T>.IA>(builder.Arrays, "array parser for " + callerName, this));

  public Parser<TInterface, TFor>.L ParserFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, Parser<TFor>.I
    => (Parser<TInterface, TFor>.D)(() => Cached<TInterface, TInterface>(builder.InterfaceSingles, "interface parser for " + callerName, this));
  public ParserArray<TInterface, TFor>.LA ArrayFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, Parser<TFor>.IA
    => (ParserArray<TInterface, TFor>.DA)(() => Cached<TInterface, TInterface>(builder.InterfaceArrays, "interface array parser for " + callerName, this));

  public IEnumerable<IParseDeclaration> GetDeclarations([CallerMemberName] string callerName = "")
    => builder.Declarations.Keys.Select(f => (IParseDeclaration)Cached(builder.Declarations, f, f, "declaration parsers for " + callerName, this));

  public IEnumerable<IParseDomain> GetDomains([CallerMemberName] string callerName = "")
    => builder.Domains.Select(t => (IParseDomain)Cached(builder.Singles, t.Key, t.Value, "domain parsers for " + callerName, this));
  public T GetName<T>([CallerMemberName] string callerName = "")
    where T : INameParser
    => Cached<T, T>(builder.InterfaceSingles, "name parser for " + callerName, this);
}
