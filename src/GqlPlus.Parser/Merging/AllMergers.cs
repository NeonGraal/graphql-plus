using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
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
      .AddMerge<IGqlpSchemaOption, MergeOptions>()
      .AddMerge<IGqlpSchemaSetting, MergeOptionSettings>()
      // Types
      .AddMerge<IGqlpType, MergeAllTypes>()
      // Simple
      .AddMergeAll<IGqlpDomain, IGqlpType, MergeAllDomains>()
      .AddMerge<IGqlpDomainMember, MergeDomainMembers>()
      .AddMergeDomain<DomainMemberAst, IGqlpDomainMember>()
      .AddMerge<IGqlpDomainRange, MergeDomainRanges>()
      .AddMergeDomain<DomainRangeAst, IGqlpDomainRange>()
      .AddMerge<IGqlpDomainRegex, MergeDomainRegexes>()
      .AddMergeDomain<DomainRegexAst, IGqlpDomainRegex>()
      .AddMerge<IGqlpDomainTrueFalse, MergeDomainTrueFalse>()
      .AddMergeDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse>()
      .AddMergeAll<IGqlpEnum, IGqlpType, MergeEnums>()
      .AddMerge<IGqlpEnumItem, MergeEnumMembers>()
      .AddMergeAll<IGqlpUnion, IGqlpType, MergeUnions>()
      .AddMerge<IGqlpUnionItem, MergeUnionMembers>()
      // Object types
      .AddMerge<IGqlpTypeParameter, MergeTypeParameters>()
      .AddMergeAll<IGqlpDualObject, IGqlpType, MergeDualObjects>()
      .AddMerge<IGqlpAlternate<IGqlpDualBase>, AlternatesMerger<IGqlpDualBase>>()
      .AddMerge<IGqlpDualField, MergeDualFields>()
      .AddMergeAll<IGqlpInputObject, IGqlpType, MergeInputObjects>()
      .AddMerge<IGqlpAlternate<IGqlpInputBase>, AlternatesMerger<IGqlpInputBase>>()
      .AddMerge<IGqlpInputField, MergeInputFields>()
      .AddMerge<IGqlpInputParameter, MergeInputParameters>()
      .AddMergeAll<IGqlpOutputObject, IGqlpType, MergeOutputObjects>()
      .AddMerge<IGqlpAlternate<IGqlpOutputBase>, AlternatesMerger<IGqlpOutputBase>>()
      .AddMerge<IGqlpOutputField, MergeOutputFields>()
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

  private static IServiceCollection AddMergeDomain<TMember, TItem>(this IServiceCollection services)
  where TMember : AstAbbreviated, TItem
  where TItem : IGqlpDomainItem
    => services
      .AddMergeAll<IGqlpDomain<TItem>, IGqlpDomain, MergeDomains<TMember, TItem>>();
}
