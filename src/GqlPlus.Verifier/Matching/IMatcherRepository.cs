using System.Runtime.CompilerServices;

namespace GqlPlus.Matching;

public interface IMatcherRepository
  : IRepository
{
  Defer<ITypeMatcher>.DA TypeMatchers([CallerMemberName] string callerName = "");

  Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "");
}
