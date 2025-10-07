using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

public static class AllMatchers
{
  public static IServiceCollection AddMatchers(this IServiceCollection services)
    => services
      .AddMatcher<IGqlpType, AnyTypeMatcher>()

      .AddMatcher<IGqlpObjTypeArg, ObjTypeArgMatcher>()

      .AddSingleton<ITypeMatcher, AlternateConstraintMatcher>()
      .AddSingleton<ITypeMatcher, EnumConstraintMatcher>()
      .AddSingleton<ITypeMatcher, SpecialConstraintMatcher>()
      .AddSingleton<ITypeMatcher, UnionConstraintMatcher>()

      .AddTypeMatcher<IGqlpDomain, DomainMatcher>()
      .AddParentMatcher<IGqlpDomain, SimpleParentMatcher<IGqlpDomain>>()
      .AddParentMatcher<IGqlpEnum, SimpleParentMatcher<IGqlpEnum>>()
      .AddParentMatcher<IGqlpTypeSpecial, SimpleParentMatcher<IGqlpTypeSpecial>>()
      .AddParentMatcher<IGqlpUnion, SimpleParentMatcher<IGqlpUnion>>()

      .AddParentMatcher<IGqlpDualObject, ObjectParentMatcher<IGqlpDualObject>>()
      .AddParentMatcher<IGqlpInputObject, MatchObjectParentDualBase<IGqlpInputObject>>()
      .AddParentMatcher<IGqlpOutputObject, MatchObjectParentDualBase<IGqlpOutputObject>>()
    ;

  private static IServiceCollection AddMatcher<TType, TMatcher>(this IServiceCollection services)
    where TMatcher : class, Matcher<TType>.I
    => services
      .AddSingleton<TMatcher>()
      .AddSingleton(GetMatcher<TMatcher, TType>);

  private static IServiceCollection AddTypeMatcher<TType, TMatcher>(this IServiceCollection services)
    where TType : IGqlpType
    where TMatcher : class, Matcher<TType>.I, ITypeMatcher
    => services
      .AddMatcher<TType, TMatcher>()
      .AddProvider<TMatcher, ITypeMatcher>();

  private static IServiceCollection AddParentMatcher<TType, TMatcher>(this IServiceCollection services)
    where TType : IGqlpType
    where TMatcher : class, Matcher<TType>.I, ITypeMatcher
    => services.AddTypeMatcher<TType, TMatcher>();

  private static Matcher<TValue>.D GetMatcher<TService, TValue>(IServiceProvider provider)
    where TService : class, Matcher<TValue>.I
    => provider.GetRequiredService<TService>;
}
