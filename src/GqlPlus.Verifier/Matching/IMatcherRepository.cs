using System.Runtime.CompilerServices;

namespace GqlPlus.Matching;

public interface IMatcherRepository
  : IRepository
{
  IEnumerable<Factory<ITypeMatcher, IMatcherRepository>> TypeMatchers { get; }

  Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "");
}
