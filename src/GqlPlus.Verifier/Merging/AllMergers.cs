using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Merging.Globals;
using GqlPlus.Verifier.Merging.Objects;
using GqlPlus.Verifier.Merging.Simple;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Verifier.Merging;

[ExcludeFromCodeCoverage]
public static class AllMergers
{
  public static IServiceCollection AddMergers(this IServiceCollection services)
    => services
      .AddMerge<SchemaAst, MergeSchemas>()
      .AddMerge<ConstantAst, MergeConstants>()
      .AddMerge<CategoryDeclAst, MergeCategories>()
      .AddMerge<DirectiveDeclAst, MergeDirectives>()
      .AddMerge<OptionDeclAst, MergeOptions>()
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
      .AddMerge<AstAlternate<DualReferenceAst>, AlternatesMerger<DualReferenceAst>>()
      .AddMerge<DualFieldAst, MergeDualFields>()
      .AddMergeAll<DualDeclAst, AstType, MergeDualObjects>()
      .AddMerge<AstAlternate<InputReferenceAst>, AlternatesMerger<InputReferenceAst>>()
      .AddMerge<InputFieldAst, MergeInputFields>()
      .AddMergeAll<InputDeclAst, AstType, MergeInputObjects>()
      .AddMerge<AstAlternate<OutputReferenceAst>, AlternatesMerger<OutputReferenceAst>>()
      .AddMerge<OutputFieldAst, MergeOutputFields>()
      .AddMergeAll<OutputDeclAst, AstType, MergeOutputObjects>()
    ;

  public static IServiceCollection AddMerge<TValue, TService>(this IServiceCollection services)
    where TValue : AstBase
    where TService : class, IMerge<TValue>
    => services
      .RemoveAll<IMerge<TValue>>()
      .AddSingleton<IMerge<TValue>, TService>();

  public static IServiceCollection AddMergeAll<TValue, TBase, TService>(this IServiceCollection services)
    where TValue : AstBase
    where TBase : AstType
    where TService : class, IMergeAll<TBase>, IMerge<TValue>
    => services
      .RemoveAll<IMerge<TValue>>()
      .AddSingleton<TService>()
      .AddSingleton<IMerge<TValue>>(x => x.GetRequiredService<TService>())
      .AddSingleton<IMergeAll<TBase>>(x => x.GetRequiredService<TService>());

  public static IServiceCollection AddMergeDomain<TMember>(this IServiceCollection services)
    where TMember : AstAbbreviated, IAstDomainItem
    => services
      .AddMergeAll<AstDomain<TMember>, AstDomain, MergeDomains<TMember>>();
}
