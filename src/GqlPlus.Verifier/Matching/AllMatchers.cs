using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

public static class AllMatchers
{
  public static IServiceCollection AddMatchers(this IServiceCollection services)
    => services
      .AddSingleton<IMatch<IGqlpType, IGqlpType>, AnyTypeMatcher>()
      .AddSameMatcher<IGqlpTypeSpecial, SimpleSameMatcher<IGqlpTypeSpecial>>()
      .AddMatcher<IGqlpDomain, IGqlpTypeSpecial, DomainSpecialMatcher>()
      .AddSameMatcher<IGqlpDomain, SimpleSameMatcher<IGqlpDomain>>()
      .AddSameMatcher<IGqlpEnum, SimpleSameMatcher<IGqlpEnum>>()
      .AddMatcher<IGqlpDomain, IGqlpEnum, DomainEnumMatcher>()
      .AddSameMatcher<IGqlpUnion, SimpleSameMatcher<IGqlpUnion>>()
    ;

  private static IServiceCollection AddMatcher<TType, TConstraint, TMatcher>(this IServiceCollection services)
    where TType : IGqlpType
    where TConstraint : IGqlpType
    where TMatcher : class, IMatch<TType, TConstraint>, IMatcher
    => services
      .AddSingleton<TMatcher>()
      .AddProvider<TMatcher, IMatch<TType, TConstraint>>()
      .AddProvider<TMatcher, IMatcher>();

  private static IServiceCollection AddSameMatcher<TType, TMatcher>(this IServiceCollection services)
    where TType : IGqlpType
    where TMatcher : class, IMatch<TType, TType>, IMatcher
    => services.AddMatcher<TType, TType, TMatcher>();
}
