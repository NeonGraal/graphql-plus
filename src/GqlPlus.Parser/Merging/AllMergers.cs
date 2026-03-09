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
      .AddSingleton<IMerge<T>>(sp => sp.GetRequiredService<IMergerRepository>().MergerFor<T>());

  public static IMergeRepositoryBuilder AddSchemaMergers(this IMergeRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge<IGqlpConstant>(_ => new MergeConstants())
      // Schema
      .AddMerge<IGqlpSchema>(m => new MergeSchemas(
        m.MergerFor<IGqlpSchemaCategory>(),
        m.MergerFor<IGqlpSchemaDirective>(),
        m.MergerFor<IGqlpSchemaOption>(),
        m.MergerFor<IGqlpType>()))
      .AddMerge<IGqlpSchemaCategory>(m => new MergeCategories(m.LoggerFactory))
      .AddMerge<IGqlpSchemaDirective>(m => new MergeDirectives(m.LoggerFactory, m.MergerFor<IGqlpInputParam>()))
      .AddMerge<IGqlpSchemaOption>(m => new MergeOptions(m.LoggerFactory, m.MergerFor<IGqlpSchemaSetting>()))
      .AddMerge<IGqlpSchemaSetting>(m => new MergeOptionSettings(m.MergerFor<IGqlpConstant>()))
      // Types
      .AddMerge<IGqlpType>(m => new MergeAllTypes(m.LoggerFactory, m.AllMergersFor<IGqlpType>()))
      // Simple
      .AddMergeAll<IGqlpDomain, IGqlpType, MergeAllDomains>(m => new MergeAllDomains(m.LoggerFactory, m.AllMergersFor<IGqlpDomain>()))
      .AddMerge<IGqlpDomainLabel>(m => new MergeDomainLabels(m.LoggerFactory))
      .AddMergeAll<IGqlpDomain<IGqlpDomainLabel>, IGqlpDomain, MergeDomains<DomainLabelAst, IGqlpDomainLabel>>(
        m => new MergeDomains<DomainLabelAst, IGqlpDomainLabel>(m.LoggerFactory, m.MergerFor<IGqlpDomainLabel>()))
      .AddMerge<IGqlpDomainRange>(m => new MergeDomainRanges(m.LoggerFactory))
      .AddMergeAll<IGqlpDomain<IGqlpDomainRange>, IGqlpDomain, MergeDomains<DomainRangeAst, IGqlpDomainRange>>(
        m => new MergeDomains<DomainRangeAst, IGqlpDomainRange>(m.LoggerFactory, m.MergerFor<IGqlpDomainRange>()))
      .AddMerge<IGqlpDomainRegex>(m => new MergeDomainRegexes(m.LoggerFactory))
      .AddMergeAll<IGqlpDomain<IGqlpDomainRegex>, IGqlpDomain, MergeDomains<DomainRegexAst, IGqlpDomainRegex>>(
        m => new MergeDomains<DomainRegexAst, IGqlpDomainRegex>(m.LoggerFactory, m.MergerFor<IGqlpDomainRegex>()))
      .AddMerge<IGqlpDomainTrueFalse>(m => new MergeDomainTrueFalse(m.LoggerFactory))
      .AddMergeAll<IGqlpDomain<IGqlpDomainTrueFalse>, IGqlpDomain, MergeDomains<DomainTrueFalseAst, IGqlpDomainTrueFalse>>(
        m => new MergeDomains<DomainTrueFalseAst, IGqlpDomainTrueFalse>(m.LoggerFactory, m.MergerFor<IGqlpDomainTrueFalse>()))
      .AddMergeAll<IGqlpEnum, IGqlpType, MergeEnums>(m => new MergeEnums(m.LoggerFactory, m.MergerFor<IGqlpEnumLabel>()))
      .AddMerge<IGqlpEnumLabel>(m => new MergeEnumLabels(m.LoggerFactory))
      .AddMergeAll<IGqlpUnion, IGqlpType, MergeUnions>(m => new MergeUnions(m.LoggerFactory, m.MergerFor<IGqlpUnionMember>()))
      .AddMerge<IGqlpUnionMember>(_ => new MergeUnionMembers())
      // Object types
      .AddMerge<IGqlpTypeParam>(_ => new MergeTypeParams())
      .AddMerge<IGqlpAlternate>(m => new MergeAlternates(m.LoggerFactory))
      .AddMergeAll<IGqlpObject<IGqlpDualField>, IGqlpType, AstObjectsMerger<IGqlpDualField>>(
        m => new AstObjectsMerger<IGqlpDualField>(m.LoggerFactory, m.MergerFor<IGqlpDualField>(), m.MergerFor<IGqlpTypeParam>(), m.MergerFor<IGqlpAlternate>()))
      .AddMerge<IGqlpDualField>(m => new MergeDualFields(m.LoggerFactory))
      .AddMergeAll<IGqlpObject<IGqlpInputField>, IGqlpType, AstObjectsMerger<IGqlpInputField>>(
        m => new AstObjectsMerger<IGqlpInputField>(m.LoggerFactory, m.MergerFor<IGqlpInputField>(), m.MergerFor<IGqlpTypeParam>(), m.MergerFor<IGqlpAlternate>()))
      .AddMerge<IGqlpInputField>(m => new MergeInputFields(m.LoggerFactory, m.MergerFor<IGqlpConstant>()))
      .AddMerge<IGqlpInputParam>(m => new MergeInputParams(m.LoggerFactory, m.MergerFor<IGqlpConstant>()))
      .AddMergeAll<IGqlpObject<IGqlpOutputField>, IGqlpType, AstObjectsMerger<IGqlpOutputField>>(
        m => new AstObjectsMerger<IGqlpOutputField>(m.LoggerFactory, m.MergerFor<IGqlpOutputField>(), m.MergerFor<IGqlpTypeParam>(), m.MergerFor<IGqlpAlternate>()))
      .AddMerge<IGqlpOutputField>(m => new MergeOutputFields(m.LoggerFactory, m.MergerFor<IGqlpInputParam>()))
    ;
}
