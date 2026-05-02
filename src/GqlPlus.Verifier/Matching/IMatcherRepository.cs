using System.Runtime.CompilerServices;

namespace GqlPlus.Matching;

public interface IMatcherRepository
{
  ILoggerFactory LoggerFactory { get; }

  IEnumerable<ITypeMatcher> TypeMatchers { get; }

  Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "");
}
