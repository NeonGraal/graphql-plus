namespace GqlPlus.Matching;

public interface IMatcherRepository
{
  Matcher<T>.D MatcherFor<T>();
}
