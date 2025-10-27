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
  public static IServiceCollection AddMergers(this IServiceCollection services)
    => services
      .AddMerge<IGqlpConstant, MergeConstants>()
      // Schema
      .AddMerge<IGqlpSchema, MergeSchemas>()
      .AddMerge<IGqlpSchemaCategory, MergeCategories>()
      .AddMerge<IGqlpSchemaDirective, MergeDirectives>()
      .AddMerge<IGqlpSchemaOperation, MergeOperations>()
      .AddMerge<IGqlpSchemaOption, MergeOptions>()
      .AddMerge<IGqlpSchemaSetting, MergeOptionSettings>()
      // Types
      .AddMerge<IGqlpType, MergeAllTypes>()
      // Simple
      .AddMergeAll<IGqlpDomain, IGqlpType, MergeAllDomains>()
      .AddMerge<IGqlpDomainLabel, MergeDomainLabels>()
      .AddMergeDomain<DomainLabelAst, IGqlpDomainLabel>()
      .AddMerge<IGqlpDomainRange, MergeDomainRanges>()
      .AddMergeDomain<DomainRangeAst, IGqlpDomainRange>()
      .AddMerge<IGqlpDomainRegex, MergeDomainRegexes>()
      .AddMergeDomain<DomainRegexAst, IGqlpDomainRegex>()
      .AddMerge<IGqlpDomainTrueFalse, MergeDomainTrueFalse>()
      .AddMergeDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse>()
      .AddMergeAll<IGqlpEnum, IGqlpType, MergeEnums>()
      .AddMerge<IGqlpEnumLabel, MergeEnumLabels>()
      .AddMergeAll<IGqlpUnion, IGqlpType, MergeUnions>()
      .AddMerge<IGqlpUnionMember, MergeUnionMembers>()
      // Object types
      .AddMerge<IGqlpTypeParam, MergeTypeParams>()

      .AddMerge<IGqlpAlternate, MergeAlternates>()
      .AddMergeObject<IGqlpDualField, MergeDualFields>()
      .AddMergeObject<IGqlpInputField, MergeInputFields>()
      .AddMerge<IGqlpInputParam, MergeInputParams>()
      .AddMergeObject<IGqlpOutputField, MergeOutputFields>()
    ;

  private static IServiceCollection AddMerge<TValue, TService>(this IServiceCollection services)
    where TValue : IGqlpError
    where TService : class, IMerge<TValue>
    => services
      .RemoveAll<IMerge<TValue>>()
      .AddSingleton<IMerge<TValue>, TService>();

  private static IServiceCollection AddMergeAll<TAst, TType, TService>(this IServiceCollection services)
    where TAst : IGqlpType
    where TType : IGqlpType
    where TService : class, IMergeAll<TType>, IMerge<TAst>
    => services
      .RemoveAll<IMerge<TAst>>()
      .AddSingleton<TService>()
      .AddProvider<TService, IMerge<TAst>>()
      .AddProvider<TService, IMergeAll<TType>>();

  private static IServiceCollection AddMergeDomain<TItemAst, TItem>(this IServiceCollection services)
  where TItemAst : AstAbbreviated, TItem
  where TItem : class, IGqlpDomainItem
    => services
      .AddMergeAll<IGqlpDomain<TItem>, IGqlpDomain, MergeDomains<TItemAst, TItem>>();

  private static IServiceCollection AddMergeObject<TField, TService>(this IServiceCollection services)
  where TField : IGqlpObjField
  where TService : AstObjectFieldsMerger<TField>
    => services
      .AddMergeAll<IGqlpObject<TField>, IGqlpType, AstObjectsMerger<TField>>()
      .AddMerge<TField, TService>();
}
