using System.Collections.Concurrent;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

internal class ParserRepository(
  ParserRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IParserRepository>(loggerFactory)
  , IParserRepository
{
  public Parser<T>.L ParserFor<T>()
    => new(() => Cached<T, Parser<T>.I>(builder.Singles, "single parser", this));

  public Parser<T>.LA ArrayFor<T>()
    => new(() => Cached<T, Parser<T>.IA>(builder.Arrays, "array parser", this));

  public Parser<TInterface, TFor>.L ParserFor<TInterface, TFor>()
    where TInterface : class, Parser<TFor>.I
    => new(() => Cached<TInterface, TInterface>(builder.InterfaceSingles, "interface parser", this));

  public ParserArray<TInterface, TFor>.LA ArrayFor<TInterface, TFor>()
    where TInterface : class, Parser<TFor>.IA
    => new(() => Cached<TInterface, TInterface>(builder.InterfaceArrays, "interface array parser", this));

  public IEnumerable<IParseDeclaration> GetDeclarations()
    => builder.Declarations.Keys.Select(f => (IParseDeclaration)Cached(builder.Declarations, f, f, "declaration parser", this));

  public IEnumerable<IParseDomain> GetDomains()
    => builder.Domains.Select(t => (IParseDomain)Cached(builder.Singles, t.Key, t.Value, "domain parser", this));
  public T GetName<T>()
    where T : INameParser
    => Cached<T, T>(builder.InterfaceSingles, "name parser", this);
}
