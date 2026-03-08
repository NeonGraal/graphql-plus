using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

public interface IParserRepository
{
  Parser<T>.L ParserFor<T>();
  Parser<T>.LA ArrayFor<T>();
  Parser<TInterface, TFor>.L ParserFor<TInterface, TFor>()
    where TInterface : class, Parser<TFor>.I;
  ParserArray<TInterface, TFor>.LA ArrayFor<TInterface, TFor>()
    where TInterface : class, Parser<TFor>.IA;

  IEnumerable<IParseDeclaration> GetDeclarations();
  IEnumerable<IParseDomain> GetDomains();
  T GetName<T>()
    where T : INameParser;
}
