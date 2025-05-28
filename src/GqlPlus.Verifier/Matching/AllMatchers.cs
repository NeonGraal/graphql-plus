using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

public static class AllMatchers
{
  public static IServiceCollection AddMatchers(this IServiceCollection services)
    => services
      .AddSingleton<IMatch<IGqlpType>, AnyTypeMatcher>()
    ;

  private static IServiceCollection AddMatcher<TConstraint, TMatcher>(this IServiceCollection services)
    where TConstraint : IGqlpType
    where TMatcher : class, IMatch<TConstraint>, IMatcher
    => services
      .AddSingleton<TMatcher>()
      .AddProvider<TMatcher, IMatch<TConstraint>>()
      .AddProvider<TMatcher, IMatcher>();
}
