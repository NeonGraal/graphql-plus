using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

public static class AllMatchers
{
  public static IServiceCollection AddMatchers(this IServiceCollection services)
    => services
      .AddSingleton<IMatch<IGqlpType>, AnyTypeMatcher>()
      .AddSameMatcher<IGqlpTypeSpecial, SimpleSameMatcher<IGqlpTypeSpecial>>()
      .AddMatcher<IGqlpDomain, DomainSpecialMatcher>()
      .AddSameMatcher<IGqlpDomain, SimpleSameMatcher<IGqlpDomain>>()
      .AddSameMatcher<IGqlpEnum, SimpleSameMatcher<IGqlpEnum>>()
      .AddMatcher<IGqlpDomain, DomainEnumMatcher>()
      .AddSameMatcher<IGqlpUnion, SimpleSameMatcher<IGqlpUnion>>()
    ;

  private static IServiceCollection AddMatcher<TType, TMatcher>(this IServiceCollection services)
    where TType : IGqlpType
    where TMatcher : class, IMatch<TType>, IMatcher
    => services
      .AddSingleton<TMatcher>()
      .AddProvider<TMatcher, IMatch<TType>>()
      .AddProvider<TMatcher, IMatcher>();

  private static IServiceCollection AddSameMatcher<TType, TMatcher>(this IServiceCollection services)
    where TType : IGqlpType
    where TMatcher : class, IMatch<TType>, IMatcher
    => services.AddMatcher<TType, TMatcher>();
}
