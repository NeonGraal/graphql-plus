using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Matching;

public static class AllMatchers
{
  public static IMatcherRepositoryBuilder AddConstraintTypeMatchers([NotNull] this IMatcherRepositoryBuilder builder)
    => builder
          .AddMatcher(AnyTypeMatcher.Factory)
          .AddMatcher(TypeArgMatcher.Factory)

          .AddConstraintMatchers()

          .AddTypeMatcher<IAstDomain, DomainMatcher>(DomainMatcher.Factory)
          .AddSimpleMatcher<IAstDomain>()
          .AddSimpleMatcher<IAstEnum>()
          .AddSimpleMatcher<IAstTypeSpecial>()
          .AddSimpleMatcher<IAstUnion>()

          .AddObjectMatcher<IAstDualField, ObjectParentMatcher<IAstDualField>>(ObjectParentMatcher<IAstDualField>.Factory)
          .AddObjectDualMatcher<IAstInputField>()
          .AddObjectDualMatcher<IAstOutputField>();

  public static IMatcherRepositoryBuilder AddConstraintMatchers([NotNull] this IMatcherRepositoryBuilder builder)
    => builder
          .AddConstraintMatcher(AlternateConstraintMatcher.Factory)
          .AddConstraintMatcher(EnumConstraintMatcher.Factory)
          .AddConstraintMatcher(SpecialConstraintMatcher.Factory)
          .AddConstraintMatcher(UnionConstraintMatcher.Factory);

  public static IServiceCollection AddMatchers(this IServiceCollection services, Action<IMatcherRepositoryBuilder> config)
  {
    MatcherRepositoryBuilder builder = new();
    config?.Invoke(builder);
    services.AddSingleton(builder);
    services.TryAddSingleton<IMatcherRepository, MatcherRepository>();
    return services;
  }

  private static IMatcherRepositoryBuilder AddSimpleMatcher<TType>(this IMatcherRepositoryBuilder builder)
    where TType : IAstSimple
    => builder.AddTypeMatcher<TType, SimpleParentMatcher<TType>>(SimpleParentMatcher<TType>.Factory);

  private static IMatcherRepositoryBuilder AddObjectMatcher<TField, TMatcher>(this IMatcherRepositoryBuilder builder, Factory<TMatcher, IMatcherRepository> factory)
    where TField : IAstObjField
    where TMatcher : class, Matcher<IAstObject<TField>>.I, ITypeMatcher
    => builder.AddTypeMatcher<IAstObject<TField>, TMatcher>(factory);

  private static IMatcherRepositoryBuilder AddObjectDualMatcher<TField>(this IMatcherRepositoryBuilder builder)
    where TField : class, IAstObjField
    => builder.AddObjectMatcher<TField, MatchObjectParentDualBase<TField>>(MatchObjectParentDualBase<TField>.Factory);
}
