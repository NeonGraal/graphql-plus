using GqlPlus.Ast.Schema;
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
      .AddMerge(MergeConstants.Factory)
      .AddMerge(MergeSchemas.Factory)
      .AddSchemaGlobalMergers()
      .AddMerge(MergeAllTypes.Factory)
      .AddSchemaSimpleMergers()
      .AddSchemaObjectMergers();

  public static IMergerRepositoryBuilder AddSchemaGlobalMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge(MergeCategories.Factory)
      .AddMerge(MergeDirectives.Factory)
      .AddMerge(MergeOperations.Factory)
      .AddMerge(MergeOptions.Factory)
      .AddMerge(MergeOptionSettings.Factory);

  public static IMergerRepositoryBuilder AddSchemaSimpleMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddSchemaDomainMergers()
      .AddSchemaDomainMergeAlls()
      .AddMerge(MergeEnumLabels.Factory)
      .AddMergeAll<IAstEnum, IAstType, MergeEnums>(MergeEnums.Factory)
      .AddMerge(MergeUnionMembers.Factory)
      .AddMergeAll<IAstUnion, IAstType, MergeUnions>(MergeUnions.Factory);

  public static IMergerRepositoryBuilder AddSchemaDomainMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge(MergeDomainLabels.Factory)
      .AddMerge(MergeDomainRanges.Factory)
      .AddMerge(MergeDomainRegexes.Factory)
      .AddMerge(MergeDomainTrueFalse.Factory);

  public static IMergerRepositoryBuilder AddSchemaDomainMergeAlls(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMergeAll<IAstDomain, IAstType, MergeAllDomains>(MergeAllDomains.Factory)
      .AddMergeAll<IAstDomain<IAstDomainLabel>, IAstDomain, MergeDomains<DomainLabelAst, IAstDomainLabel>>(
        MergeDomains<DomainLabelAst, IAstDomainLabel>.Factory)
      .AddMergeAll<IAstDomain<IAstDomainRange>, IAstDomain, MergeDomains<DomainRangeAst, IAstDomainRange>>(
        MergeDomains<DomainRangeAst, IAstDomainRange>.Factory)
      .AddMergeAll<IAstDomain<IAstDomainRegex>, IAstDomain, MergeDomains<DomainRegexAst, IAstDomainRegex>>(
        MergeDomains<DomainRegexAst, IAstDomainRegex>.Factory)
      .AddMergeAll<IAstDomain<IAstDomainTrueFalse>, IAstDomain, MergeDomains<DomainTrueFalseAst, IAstDomainTrueFalse>>(
        MergeDomains<DomainTrueFalseAst, IAstDomainTrueFalse>.Factory);

  public static IMergerRepositoryBuilder AddSchemaObjectMergers(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMerge(MergeTypeParams.Factory)
      .AddMerge(MergeAlternates.Factory)
      .AddMerge(MergeDualFields.Factory)
      .AddMerge(MergeInputFields.Factory)
      .AddMerge(MergeInputParams.Factory)
      .AddMerge(MergeOutputFields.Factory)
      .AddSchemaObjectMergeAlls();

  public static IMergerRepositoryBuilder AddSchemaObjectMergeAlls(this IMergerRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .AddMergeAll<IAstObject<IAstDualField>, IAstType, AstObjectsMerger<IAstDualField>>(
        AstObjectsMerger<IAstDualField>.Factory)
      .AddMergeAll<IAstObject<IAstInputField>, IAstType, AstObjectsMerger<IAstInputField>>(
        AstObjectsMerger<IAstInputField>.Factory)
      .AddMergeAll<IAstObject<IAstOutputField>, IAstType, AstObjectsMerger<IAstOutputField>>(
        AstObjectsMerger<IAstOutputField>.Factory);
}
