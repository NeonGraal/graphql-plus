using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

public static class AllMatchers
{
  public static IServiceCollection AddMatchers(this IServiceCollection services)
    => services
      .AddMatcher<IGqlpType, AnyTypeMatcher>()

      .AddMatcher<IGqlpDualArg, ObjArgMatcher<IGqlpDualArg>>()
      .AddMatcher<IGqlpInputArg, ObjArgMatcher<IGqlpInputArg>>()
      .AddMatcher<IGqlpOutputArg, ObjArgMatcher<IGqlpOutputArg>>()

      .AddSingleton<IMatcher, UnionConstraintMatcher>()

      .AddTypeMatcher<IGqlpDomain, DomainMatcher>()
      .AddSameMatcher<IGqlpDomain, SimpleSameMatcher<IGqlpDomain>>()
      .AddSameMatcher<IGqlpEnum, SimpleSameMatcher<IGqlpEnum>>()
      .AddSameMatcher<IGqlpTypeSpecial, SimpleSameMatcher<IGqlpTypeSpecial>>()
      .AddSameMatcher<IGqlpUnion, SimpleSameMatcher<IGqlpUnion>>()

      .AddSameMatcher<IGqlpDualObject, ObjectSameMatcher<IGqlpDualObject>>()
      .AddSameMatcher<IGqlpInputObject, ObjectSameMatcher<IGqlpInputObject>>()
      .AddSameMatcher<IGqlpOutputObject, ObjectSameMatcher<IGqlpOutputObject>>()
    ;

  private static IServiceCollection AddMatcher<TType, TMatcher>(this IServiceCollection services)
    where TMatcher : class, Matcher<TType>.I
    => services
      .AddSingleton<TMatcher>()
      .AddSingleton(GetMatcher<TMatcher, TType>);

  private static IServiceCollection AddTypeMatcher<TType, TMatcher>(this IServiceCollection services)
    where TType : IGqlpType
    where TMatcher : class, Matcher<TType>.I, IMatcher
    => services
      .AddMatcher<TType, TMatcher>()
      .AddProvider<TMatcher, IMatcher>();

  private static IServiceCollection AddSameMatcher<TType, TMatcher>(this IServiceCollection services)
    where TType : IGqlpType
    where TMatcher : class, Matcher<TType>.I, IMatcher
    => services.AddTypeMatcher<TType, TMatcher>();

  private static Matcher<TValue>.D GetMatcher<TService, TValue>(IServiceProvider provider)
    where TService : class, Matcher<TValue>.I
    => provider.GetRequiredService<TService>;
}
