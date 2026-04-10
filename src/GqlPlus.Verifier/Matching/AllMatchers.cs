using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Matching;

public static class AllMatchers
{
  public static IMatcherRepositoryBuilder AddConstraintTypeMatchers([NotNull] this IMatcherRepositoryBuilder builder)
    => builder
          .AddMatcher(m => new AnyTypeMatcher(m))
          .AddMatcher(m => new TypeArgMatcher(m))

          .AddConstraintMatchers()

          .AddTypeMatcher<IAstDomain, DomainMatcher>(m => new DomainMatcher(m))
          .AddSimpleMatcher<IAstDomain>()
          .AddSimpleMatcher<IAstEnum>()
          .AddSimpleMatcher<IAstTypeSpecial>()
          .AddSimpleMatcher<IAstUnion>()

          .AddObjectMatcher<IGqlpDualField, ObjectParentMatcher<IGqlpDualField>>(m => new ObjectParentMatcher<IGqlpDualField>(m))
          .AddObjectDualMatcher<IGqlpInputField>()
          .AddObjectDualMatcher<IGqlpOutputField>();

  public static IMatcherRepositoryBuilder AddConstraintMatchers([NotNull] this IMatcherRepositoryBuilder builder)
    => builder
          .AddConstraintMatcher(m => new AlternateConstraintMatcher(m))
          .AddConstraintMatcher(m => new EnumConstraintMatcher(m))
          .AddConstraintMatcher(m => new SpecialConstraintMatcher(m))
          .AddConstraintMatcher(m => new UnionConstraintMatcher(m));

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
    => builder.AddTypeMatcher<TType, SimpleParentMatcher<TType>>(m => new SimpleParentMatcher<TType>(m));

  private static IMatcherRepositoryBuilder AddObjectMatcher<TField, TMatcher>(this IMatcherRepositoryBuilder builder, Factory<TMatcher, IMatcherRepository> factory)
    where TField : IGqlpObjField
    where TMatcher : class, Matcher<IGqlpObject<TField>>.I, ITypeMatcher
    => builder.AddTypeMatcher<IGqlpObject<TField>, TMatcher>(factory);

  private static IMatcherRepositoryBuilder AddObjectDualMatcher<TField>(this IMatcherRepositoryBuilder builder)
    where TField : class, IGqlpObjField
    => builder.AddObjectMatcher<TField, MatchObjectParentDualBase<TField>>(m => new MatchObjectParentDualBase<TField>(m));
}
