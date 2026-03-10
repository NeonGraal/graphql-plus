using System.Reflection;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Globals;
using GqlPlus.Merging.Objects;
using GqlPlus.Merging.Simple;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Merging;

public static class AllMergers
{
  private static readonly MethodInfo s_registerMerge =
    typeof(AllMergers).GetMethod(nameof(RegisterMerge), BindingFlags.NonPublic | BindingFlags.Static)
    ?? throw new InvalidOperationException($"Method '{nameof(RegisterMerge)}' not found on '{nameof(AllMergers)}'.");

  public static IServiceCollection AddMergers(this IServiceCollection services)
    => services.AddMergers(b => b.AddSchemaMergers());

  public static IServiceCollection AddMergers(this IServiceCollection services, Action<IMergeRepositoryBuilder> config)
  {
    services.TryAddSingleton<IMergerRepository, MergerRepository>();
    ServiceDescriptor? descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(MergeRepositoryBuilder));
    if (descriptor?.ImplementationInstance is not MergeRepositoryBuilder builder) {
      builder = new();
      services.AddSingleton(builder);
      services.AddProvider<MergeRepositoryBuilder, IMergeRepositoryBuilder>();
    }

    config?.Invoke(builder);

    foreach (Type valueType in builder.MergerTypes.Keys) {
      s_registerMerge.MakeGenericMethod(valueType).Invoke(null, [services]);
    }

    return services;
  }

  private static void RegisterMerge<T>(IServiceCollection services)
    where T : IGqlpError
    => services
      .RemoveAll<IMerge<T>>()
      .AddSingleton<IMerge<T>, MergeProxy<T>>();

  public static IMergeRepositoryBuilder AddSchemaMergers(this IMergeRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge<IGqlpConstant>(_ => new MergeConstants())
      // Schema
      .AddMerge<IGqlpSchema>(m => new MergeSchemas(m))
      .AddMerge<IGqlpSchemaCategory>(m => new MergeCategories(m))
      .AddMerge<IGqlpSchemaDirective>(m => new MergeDirectives(m))
      .AddMerge<IGqlpSchemaOption>(m => new MergeOptions(m))
      .AddMerge<IGqlpSchemaSetting>(m => new MergeOptionSettings(m))
      // Types
      .AddMerge<IGqlpType>(m => new MergeAllTypes(m))
      // Simple
      .AddMergeAll<IGqlpDomain, IGqlpType, MergeAllDomains>(m => new MergeAllDomains(m))
      .AddMerge<IGqlpDomainLabel>(m => new MergeDomainLabels(m))
      .AddMergeAll<IGqlpDomain<IGqlpDomainLabel>, IGqlpDomain, MergeDomains<DomainLabelAst, IGqlpDomainLabel>>(
        m => new MergeDomains<DomainLabelAst, IGqlpDomainLabel>(m))
      .AddMerge<IGqlpDomainRange>(m => new MergeDomainRanges(m))
      .AddMergeAll<IGqlpDomain<IGqlpDomainRange>, IGqlpDomain, MergeDomains<DomainRangeAst, IGqlpDomainRange>>(
        m => new MergeDomains<DomainRangeAst, IGqlpDomainRange>(m))
      .AddMerge<IGqlpDomainRegex>(m => new MergeDomainRegexes(m))
      .AddMergeAll<IGqlpDomain<IGqlpDomainRegex>, IGqlpDomain, MergeDomains<DomainRegexAst, IGqlpDomainRegex>>(
        m => new MergeDomains<DomainRegexAst, IGqlpDomainRegex>(m))
      .AddMerge<IGqlpDomainTrueFalse>(m => new MergeDomainTrueFalse(m))
      .AddMergeAll<IGqlpDomain<IGqlpDomainTrueFalse>, IGqlpDomain, MergeDomains<DomainTrueFalseAst, IGqlpDomainTrueFalse>>(
        m => new MergeDomains<DomainTrueFalseAst, IGqlpDomainTrueFalse>(m))
      .AddMergeAll<IGqlpEnum, IGqlpType, MergeEnums>(m => new MergeEnums(m))
      .AddMerge<IGqlpEnumLabel>(m => new MergeEnumLabels(m))
      .AddMergeAll<IGqlpUnion, IGqlpType, MergeUnions>(m => new MergeUnions(m))
      .AddMerge<IGqlpUnionMember>(_ => new MergeUnionMembers())
      // Object types
      .AddMerge<IGqlpTypeParam>(_ => new MergeTypeParams())
      .AddMerge<IGqlpAlternate>(m => new MergeAlternates(m))
      .AddMergeAll<IGqlpObject<IGqlpDualField>, IGqlpType, AstObjectsMerger<IGqlpDualField>>(
        m => new AstObjectsMerger<IGqlpDualField>(m))
      .AddMerge<IGqlpDualField>(m => new MergeDualFields(m))
      .AddMergeAll<IGqlpObject<IGqlpInputField>, IGqlpType, AstObjectsMerger<IGqlpInputField>>(
        m => new AstObjectsMerger<IGqlpInputField>(m))
      .AddMerge<IGqlpInputField>(m => new MergeInputFields(m))
      .AddMerge<IGqlpInputParam>(m => new MergeInputParams(m))
      .AddMergeAll<IGqlpObject<IGqlpOutputField>, IGqlpType, AstObjectsMerger<IGqlpOutputField>>(
        m => new AstObjectsMerger<IGqlpOutputField>(m))
      .AddMerge<IGqlpOutputField>(m => new MergeOutputFields(m))
    ;
}
