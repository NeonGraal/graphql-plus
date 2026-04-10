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
    services.AddSingleton(builder);
    services.TryAddSingleton<IMergerRepository, MergerRepository>();
    return services;
  }

  public static IMergerRepositoryBuilder AddSchemaMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge(_ => new MergeConstants())
      .AddMerge(m => new MergeSchemas(m))
      .AddSchemaGlobalMergers()
      .AddMerge(m => new MergeAllTypes(m))
      .AddSchemaSimpleMergers()
      .AddSchemaObjectMergers();

  public static IMergerRepositoryBuilder AddSchemaGlobalMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge(m => new MergeCategories(m))
      .AddMerge(m => new MergeDirectives(m))
      .AddMerge(m => new MergeOptions(m))
      .AddMerge(m => new MergeOptionSettings(m));

  public static IMergerRepositoryBuilder AddSchemaSimpleMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddSchemaDomainMergers()
      .AddSchemaDomainMergeAlls()
      .AddMerge(m => new MergeEnumLabels(m))
      .AddMergeAll<IAstEnum, IAstType, MergeEnums>(m => new MergeEnums(m))
      .AddMerge(_ => new MergeUnionMembers())
      .AddMergeAll<IAstUnion, IAstType, MergeUnions>(m => new MergeUnions(m));

  public static IMergerRepositoryBuilder AddSchemaDomainMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge(m => new MergeDomainLabels(m))
      .AddMerge(m => new MergeDomainRanges(m))
      .AddMerge(m => new MergeDomainRegexes(m))
      .AddMerge(m => new MergeDomainTrueFalse(m));

  public static IMergerRepositoryBuilder AddSchemaDomainMergeAlls(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMergeAll<IAstDomain, IAstType, MergeAllDomains>(m => new MergeAllDomains(m))
      .AddMergeAll<IAstDomain<IAstDomainLabel>, IAstDomain, MergeDomains<DomainLabelAst, IAstDomainLabel>>(
        m => new MergeDomains<DomainLabelAst, IAstDomainLabel>(m))
      .AddMergeAll<IAstDomain<IAstDomainRange>, IAstDomain, MergeDomains<DomainRangeAst, IAstDomainRange>>(
        m => new MergeDomains<DomainRangeAst, IAstDomainRange>(m))
      .AddMergeAll<IAstDomain<IAstDomainRegex>, IAstDomain, MergeDomains<DomainRegexAst, IAstDomainRegex>>(
        m => new MergeDomains<DomainRegexAst, IAstDomainRegex>(m))
      .AddMergeAll<IAstDomain<IAstDomainTrueFalse>, IAstDomain, MergeDomains<DomainTrueFalseAst, IAstDomainTrueFalse>>(
        m => new MergeDomains<DomainTrueFalseAst, IAstDomainTrueFalse>(m));

  public static IMergerRepositoryBuilder AddSchemaObjectMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge(_ => new MergeTypeParams())
      .AddMerge(m => new MergeAlternates(m))
      .AddMerge(m => new MergeDualFields(m))
      .AddMerge(m => new MergeInputFields(m))
      .AddMerge(m => new MergeInputParams(m))
      .AddMerge(m => new MergeOutputFields(m))
      .AddSchemaObjectMergeAlls();

  public static IMergerRepositoryBuilder AddSchemaObjectMergeAlls(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMergeAll<IGqlpObject<IGqlpDualField>, IAstType, AstObjectsMerger<IGqlpDualField>>(
        m => new AstObjectsMerger<IGqlpDualField>(m))
      .AddMergeAll<IGqlpObject<IGqlpInputField>, IAstType, AstObjectsMerger<IGqlpInputField>>(
        m => new AstObjectsMerger<IGqlpInputField>(m))
      .AddMergeAll<IGqlpObject<IGqlpOutputField>, IAstType, AstObjectsMerger<IGqlpOutputField>>(
        m => new AstObjectsMerger<IGqlpOutputField>(m));
}
