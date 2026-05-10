using System.Runtime.CompilerServices;

namespace GqlPlus.Matching;

public interface IMatcherRepository
  : IRepository
{
  DeferList<ITypeMatcher>.D TypeMatchers([CallerMemberName] string callerName = "");

  MatcherOne<T>.D MatcherFor<T>([CallerMemberName] string callerName = "");
}
