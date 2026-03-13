using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Globals;
using GqlPlus.Merging.Objects;
using GqlPlus.Merging.Simple;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Merging;

public static class AllMergers
{
  public static IServiceCollection AddMergers(this IServiceCollection services, Action<IMergerRepositoryBuilder> config)
  {
    MergerRepositoryBuilder builder = new();
    config?.Invoke(builder);
    services.AddSingleton(builder.Build());
    services.TryAddSingleton<IMergerRepository, MergerRepository>();
    return services;
  }

  public static IMergerRepositoryBuilder AddSchemaMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge(_ => new MergeConstants())
      // Schema
      .AddMerge(m => new MergeSchemas(m))
      .AddMerge(m => new MergeCategories(m))
      .AddMerge(m => new MergeDirectives(m))
      .AddMerge(m => new MergeOperations(m))
      .AddMerge(m => new MergeOptions(m))
      .AddMerge(m => new MergeOptionSettings(m))
      // Types
      .AddMerge(m => new MergeAllTypes(m))
      // Simple
      .AddMergeAll<IGqlpDomain, IGqlpType, MergeAllDomains>(m => new MergeAllDomains(m))
      .AddMerge(m => new MergeDomainLabels(m))
      .AddMergeAll<IGqlpDomain<IGqlpDomainLabel>, IGqlpDomain, MergeDomains<DomainLabelAst, IGqlpDomainLabel>>(
        m => new MergeDomains<DomainLabelAst, IGqlpDomainLabel>(m))
      .AddMerge(m => new MergeDomainRanges(m))
      .AddMergeAll<IGqlpDomain<IGqlpDomainRange>, IGqlpDomain, MergeDomains<DomainRangeAst, IGqlpDomainRange>>(
        m => new MergeDomains<DomainRangeAst, IGqlpDomainRange>(m))
      .AddMerge(m => new MergeDomainRegexes(m))
      .AddMergeAll<IGqlpDomain<IGqlpDomainRegex>, IGqlpDomain, MergeDomains<DomainRegexAst, IGqlpDomainRegex>>(
        m => new MergeDomains<DomainRegexAst, IGqlpDomainRegex>(m))
      .AddMerge(m => new MergeDomainTrueFalse(m))
      .AddMergeAll<IGqlpDomain<IGqlpDomainTrueFalse>, IGqlpDomain, MergeDomains<DomainTrueFalseAst, IGqlpDomainTrueFalse>>(
        m => new MergeDomains<DomainTrueFalseAst, IGqlpDomainTrueFalse>(m))
      .AddMergeAll<IGqlpEnum, IGqlpType, MergeEnums>(m => new MergeEnums(m))
      .AddMerge(m => new MergeEnumLabels(m))
      .AddMergeAll<IGqlpUnion, IGqlpType, MergeUnions>(m => new MergeUnions(m))
      .AddMerge(_ => new MergeUnionMembers())
      // Object types
      .AddMerge(_ => new MergeTypeParams())
      .AddMerge(m => new MergeAlternates(m))
      .AddMergeAll<IGqlpObject<IGqlpDualField>, IGqlpType, AstObjectsMerger<IGqlpDualField>>(
        m => new AstObjectsMerger<IGqlpDualField>(m))
      .AddMerge(m => new MergeDualFields(m))
      .AddMergeAll<IGqlpObject<IGqlpInputField>, IGqlpType, AstObjectsMerger<IGqlpInputField>>(
        m => new AstObjectsMerger<IGqlpInputField>(m))
      .AddMerge(m => new MergeInputFields(m))
      .AddMerge(m => new MergeInputParams(m))
      .AddMergeAll<IGqlpObject<IGqlpOutputField>, IGqlpType, AstObjectsMerger<IGqlpOutputField>>(
        m => new AstObjectsMerger<IGqlpOutputField>(m))
      .AddMerge(m => new MergeOutputFields(m))
    ;
}
