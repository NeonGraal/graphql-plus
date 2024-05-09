using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
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
      .AddMerge<IGqlpSchema, MergeSchemas>()
      .AddMerge<ConstantAst, MergeConstants>()
      .AddMerge<IGqlpSchemaCategory, MergeCategories>()
      .AddMerge<IGqlpSchemaDirective, MergeDirectives>()
      .AddMerge<IGqlpSchemaOption, MergeOptions>()
      .AddMerge<OptionSettingAst, MergeOptionSettings>()
      // Types
      .AddMerge<IGqlpType, MergeAllTypes>()
      .AddMergeAll<IGqlpEnum, IGqlpType, MergeEnums>()
      .AddMerge<IGqlpEnumItem, MergeEnumMembers>()
      .AddMergeAll<IGqlpDomain, IGqlpType, MergeAllDomains>()
      .AddMerge<IGqlpUnionItem, MergeUnionMembers>()
      .AddMergeAll<IGqlpUnion, IGqlpType, MergeUnions>()
      .AddMergeDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse>()
      .AddMergeDomain<DomainMemberAst, IGqlpDomainMember>()
      .AddMergeDomain<DomainRangeAst, IGqlpDomainRange>()
      .AddMergeDomain<DomainRegexAst, IGqlpDomainRegex>()
      .AddMerge<IGqlpDomainTrueFalse, MergeDomainTrueFalse>()
      .AddMerge<IGqlpDomainMember, MergeDomainMembers>()
      .AddMerge<IGqlpDomainRange, MergeDomainRanges>()
      .AddMerge<IGqlpDomainRegex, MergeDomainRegexes>()
      // Object types
      .AddMerge<InputParameterAst, MergeParameters>()
      .AddMerge<IGqlpTypeParameter, MergeTypeParameters>()
      .AddMerge<AstAlternate<DualBaseAst>, AlternatesMerger<DualBaseAst>>()
      .AddMerge<DualFieldAst, MergeDualFields>()
      .AddMergeAll<DualDeclAst, IGqlpType, MergeDualObjects>()
      .AddMerge<AstAlternate<InputBaseAst>, AlternatesMerger<InputBaseAst>>()
      .AddMerge<InputFieldAst, MergeInputFields>()
      .AddMergeAll<InputDeclAst, IGqlpType, MergeInputObjects>()
      .AddMerge<AstAlternate<OutputBaseAst>, AlternatesMerger<OutputBaseAst>>()
      .AddMerge<OutputFieldAst, MergeOutputFields>()
      .AddMergeAll<OutputDeclAst, IGqlpType, MergeOutputObjects>()
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
      .AddSingleton<IMerge<TAst>>(x => x.GetRequiredService<TService>())
      .AddSingleton<IMergeAll<TType>>(x => x.GetRequiredService<TService>());

  private static IServiceCollection AddMergeDomain<TMember, TItem>(this IServiceCollection services)
  where TMember : AstAbbreviated, TItem
  where TItem : IGqlpDomainItem
    => services
      .AddMergeAll<IGqlpDomain<TItem>, IGqlpDomain, MergeDomains<TMember, TItem>>();
}
