using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Matching;

public static class AllMatchers
{
  public static IServiceCollection AddMatchers(this IServiceCollection services)
    => services
      .AddMatcher<IGqlpType, AnyTypeMatcher>()

      .AddMatcher<IGqlpTypeArg, TypeArgMatcher>()

      .AddSingleton<ITypeMatcher, AlternateConstraintMatcher>()
      .AddSingleton<ITypeMatcher, EnumConstraintMatcher>()
      .AddSingleton<ITypeMatcher, SpecialConstraintMatcher>()
      .AddSingleton<ITypeMatcher, UnionConstraintMatcher>()

      .AddTypeMatcher<IGqlpDomain, DomainMatcher>()
      .AddSimpleMatcher<IGqlpDomain>()
      .AddSimpleMatcher<IGqlpEnum>()
      .AddSimpleMatcher<IGqlpTypeSpecial>()
      .AddSimpleMatcher<IGqlpUnion>()

      .AddObjectMatcher<IGqlpDualField, ObjectParentMatcher<IGqlpDualField>>()
      .AddObjectDualMatcher<IGqlpInputField>()
      .AddObjectDualMatcher<IGqlpOutputField>()
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

  private static IServiceCollection AddSimpleMatcher<TType>(this IServiceCollection services)
    where TType : IGqlpSimple
    => services.AddTypeMatcher<TType, SimpleParentMatcher<TType>>();

  private static IServiceCollection AddObjectMatcher<TField, TMatcher>(this IServiceCollection services)
    where TField : IGqlpObjField
    where TMatcher : class, Matcher<IGqlpObject<TField>>.I, ITypeMatcher
    => services.AddTypeMatcher<IGqlpObject<TField>, TMatcher>();

  private static IServiceCollection AddObjectDualMatcher<TField>(this IServiceCollection services)
    where TField : class, IGqlpObjField
    => services.AddObjectMatcher<TField, MatchObjectParentDualBase<TField>>();

  private static Matcher<TValue>.D GetMatcher<TService, TValue>(IServiceProvider provider)
    where TService : class, Matcher<TValue>.I
    => provider.GetRequiredService<TService>;
}
