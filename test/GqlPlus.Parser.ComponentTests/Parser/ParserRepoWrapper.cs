using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Parser;

internal sealed class ParserRepoWrapper(
  IMap<DiTree> relationships,
  IParserRepository repo
) : IParserRepository
{
  public static void WriteTree(string label, ILoggerFactory loggerFactory, Action<IParserRepositoryBuilder> configure)
  {
    ParserRepositoryBuilder repoBuilder = new();
    configure(repoBuilder);

    Map<DiTree> relationships = [];
    IParserRepository repo = new ParserRepoWrapper(relationships, new ParserRepository(repoBuilder, loggerFactory));

    foreach (Factory<object, IParserRepository> factory in repoBuilder.AllFactories) {
      factory(repo);
    }

    DiFluid.WriteTree(label + "Repo", relationships);
  }

  public Parser<T>.LA ArrayFor<T>([CallerMemberName] string callerName = "")
    => repo.ArrayFor<T>(callerName);
  public IEnumerable<IParseDeclaration> GetDeclarations([CallerMemberName] string callerName = "")
    => repo.GetDeclarations(callerName);
  public IEnumerable<IParseDomain> GetDomains([CallerMemberName] string callerName = "")
    => repo.GetDomains(callerName);
  public T GetName<T>([CallerMemberName] string callerName = "")
    where T : INameParser
    => repo.GetName<T>(callerName);
  public Parser<T>.L ParserFor<T>([CallerMemberName] string callerName = "")
  {
    string targetName = typeof(T).SafeTypeName();
    StackFrame frame = new(1);
    MethodBase? method = frame.GetMethod();
    Type? callerType = method?.DeclaringType;
    if (callerType is not null) {
      string name = callerType.SafeTypeName();
      if (relationships.TryGetValue(name, out DiTree? tree)) {
        tree.Requires.TryAdd(callerName, targetName);
      } else {
        relationships[name] = new DiTree(name, false, 0) {
          Requires = [targetName.ToPair(callerName)]
        };
      }
    }

    return repo.ParserFor<T>(callerName);
  }

  ParserArray<TInterface, TFor>.LA IParserRepository.ArrayFor<TInterface, TFor>(string callerName)
    => repo.ArrayFor<TInterface, TFor>(callerName);
  Parser<TInterface, TFor>.L IParserRepository.ParserFor<TInterface, TFor>(string callerName)
    => repo.ParserFor<TInterface, TFor>(callerName);
}
