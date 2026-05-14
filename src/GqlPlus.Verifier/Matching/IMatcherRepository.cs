using System.Runtime.CompilerServices;

namespace GqlPlus.Matching;

public interface IMatcherRepository
  : IRepository
{
  Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "");

  DeferList<ITypeMatcher>.D TypeMatchers([CallerMemberName] string callerName = "");
}
