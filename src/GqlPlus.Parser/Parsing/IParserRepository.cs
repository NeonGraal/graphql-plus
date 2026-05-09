using System.Runtime.CompilerServices;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

public interface IParserRepository
  : IRepository
{
  Parser<T>.D ParserFor<T>([CallerMemberName] string callerName = "");
  Parser<T>.DA ArrayFor<T>([CallerMemberName] string callerName = "");
  Parser<TInterface, TFor>.D ParserFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, Parser<TFor>.I;
  ParserArray<TInterface, TFor>.DA ArrayFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, Parser<TFor>.IA;

  Defer<IParseDeclaration>.DA GetDeclarations([CallerMemberName] string callerName = "");
  Defer<IParseDomain>.DA GetDomains([CallerMemberName] string callerName = "");
  Defer<T>.D GetName<T>([CallerMemberName] string callerName = "")
    where T : class, INameParser;
}
