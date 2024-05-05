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
      .AddMerge<AstType, MergeAllTypes>()
      .AddMergeAll<EnumDeclAst, AstType, MergeEnums>()
      .AddMerge<EnumMemberAst, MergeEnumMembers>()
      .AddMergeAll<AstDomain, AstType, MergeAllDomains>()
      .AddMerge<UnionMemberAst, MergeUnionMembers>()
      .AddMergeAll<UnionDeclAst, AstType, MergeUnions>()
      .AddMergeDomain<DomainTrueFalseAst>()
      .AddMergeDomain<DomainMemberAst>()
      .AddMergeDomain<DomainRangeAst>()
      .AddMergeDomain<DomainRegexAst>()
      .AddMerge<DomainTrueFalseAst, MergeDomainTrueFalse>()
      .AddMerge<DomainMemberAst, MergeDomainMembers>()
      .AddMerge<DomainRangeAst, MergeDomainRanges>()
      .AddMerge<DomainRegexAst, MergeDomainRegexes>()
      // Object types
      .AddMerge<ParameterAst, MergeParameters>()
      .AddMerge<TypeParameterAst, MergeTypeParameters>()
      .AddMerge<AstAlternate<DualBaseAst>, AlternatesMerger<DualBaseAst>>()
      .AddMerge<DualFieldAst, MergeDualFields>()
      .AddMergeAll<DualDeclAst, AstType, MergeDualObjects>()
      .AddMerge<AstAlternate<InputBaseAst>, AlternatesMerger<InputBaseAst>>()
      .AddMerge<InputFieldAst, MergeInputFields>()
      .AddMergeAll<InputDeclAst, AstType, MergeInputObjects>()
      .AddMerge<AstAlternate<OutputBaseAst>, AlternatesMerger<OutputBaseAst>>()
      .AddMerge<OutputFieldAst, MergeOutputFields>()
      .AddMergeAll<OutputDeclAst, AstType, MergeOutputObjects>()
    ;

  public static IServiceCollection AddMerge<TValue, TService>(this IServiceCollection services)
    where TValue : IGqlpError
    where TService : class, IMerge<TValue>
    => services
      .RemoveAll<IMerge<TValue>>()
      .AddSingleton<IMerge<TValue>, TService>();

  public static IServiceCollection AddMergeAll<TAst, TType, TService>(this IServiceCollection services)
    where TAst : AstBase
    where TType : AstType
    where TService : class, IMergeAll<TType>, IMerge<TAst>
    => services
      .RemoveAll<IMerge<TAst>>()
      .AddSingleton<TService>()
      .AddSingleton<IMerge<TAst>>(x => x.GetRequiredService<TService>())
      .AddSingleton<IMergeAll<TType>>(x => x.GetRequiredService<TService>());

  public static IServiceCollection AddMergeDomain<TMember>(this IServiceCollection services)
    where TMember : AstAbbreviated, IGqlpDomainItem
    => services
      .AddMergeAll<AstDomain<TMember>, AstDomain, MergeDomains<TMember>>();
}
