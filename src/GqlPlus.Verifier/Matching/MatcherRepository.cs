using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

internal class MatcherRepository(IServiceProvider services) : IMatcherRepository
{
  public Matcher<T>.D MatcherFor<T>()
    => services.GetRequiredService<Matcher<T>.D>();
}
