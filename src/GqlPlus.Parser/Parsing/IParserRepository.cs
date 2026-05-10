using System.Runtime.CompilerServices;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

public interface IParserRepository
  : IRepository
{
  ParserOne<T>.D ParserFor<T>([CallerMemberName] string callerName = "");
  ParserArray<T>.D ArrayFor<T>([CallerMemberName] string callerName = "");
  ParserOne<TInterface, TFor>.D ParserFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, IParser<TFor>;
  ParserArray<TInterface, TFor>.D ArrayFor<TInterface, TFor>([CallerMemberName] string callerName = "")
    where TInterface : class, IParserArray<TFor>;

  DeferList<IParseDeclaration>.D GetDeclarations([CallerMemberName] string callerName = "");
  DeferList<IParseDomain>.D GetDomains([CallerMemberName] string callerName = "");
  DeferOne<T>.D GetName<T>([CallerMemberName] string callerName = "")
    where T : class, INameParser;
}
