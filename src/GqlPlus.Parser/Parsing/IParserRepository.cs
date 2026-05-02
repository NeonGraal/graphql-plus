using System.Runtime.CompilerServices;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

public interface IParserRepository
{
  Parser<T>.L ParserFor<T>([CallerMemberName] string callerName = "");
  Parser<T>.LA ArrayFor<T>([CallerMemberName] string callerName = "");
  Parser<TInterface, TFor>.L ParserFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, Parser<TFor>.I;
  ParserArray<TInterface, TFor>.LA ArrayFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, Parser<TFor>.IA;

  IEnumerable<IParseDeclaration> GetDeclarations([CallerMemberName] string callerName = "");
  IEnumerable<IParseDomain> GetDomains([CallerMemberName] string callerName = "");
  T GetName<T>([CallerMemberName] string callerName = "")
    where T : INameParser;
}
