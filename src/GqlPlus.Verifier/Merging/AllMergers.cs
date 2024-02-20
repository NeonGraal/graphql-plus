﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
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
      .AddMergeAll<AstType, EnumDeclAst, MergeEnums>()
      .AddMerge<EnumMemberAst, MergeEnumMembers>()
      .AddMergeAll<AstType, AstScalar, MergeAllScalars>()
      .AddMergeScalar<ScalarTrueFalseAst>()
      .AddMergeScalar<ScalarMemberAst>()
      .AddMergeScalar<ScalarRangeAst>()
      .AddMergeScalar<ScalarRegexAst>()
      .AddMergeScalar<ScalarReferenceAst>()
      .AddMerge<ScalarTrueFalseAst, MergeScalarTrueFalse>()
      .AddMerge<ScalarMemberAst, MergeScalarMembers>()
      .AddMerge<ScalarRangeAst, MergeScalarRanges>()
      .AddMerge<ScalarRegexAst, MergeScalarRegexes>()
      .AddMerge<ScalarReferenceAst, MergeScalarReferences>()
      // Object types
      .AddMerge<ParameterAst, MergeParameters>()
      .AddMerge<TypeParameterAst, MergeTypeParameters>()
      .AddMerge<AstAlternate<InputReferenceAst>, AlternatesMerger<InputReferenceAst>>()
      .AddMerge<InputFieldAst, MergeInputFields>()
      .AddMergeAll<AstType, InputDeclAst, MergeInputObjects>()
      .AddMerge<AstAlternate<OutputReferenceAst>, AlternatesMerger<OutputReferenceAst>>()
      .AddMerge<OutputFieldAst, MergeOutputFields>()
      .AddMergeAll<AstType, OutputDeclAst, MergeOutputObjects>()
    ;

  public static IServiceCollection AddMerge<T, S>(this IServiceCollection services)
    where S : class, IMerge<T>
    => services
      .RemoveAll<IMerge<T>>()
      .AddSingleton<IMerge<T>, S>();

  public static IServiceCollection AddMergeAll<B, T, S>(this IServiceCollection services)
    where S : class, IMergeAll<B>, IMerge<T>
    => services
      .RemoveAll<IMerge<T>>()
      .AddSingleton<S>()
      .AddSingleton<IMerge<T>>(x => x.GetRequiredService<S>())
      .AddSingleton<IMergeAll<B>>(x => x.GetRequiredService<S>());

  public static IServiceCollection AddMergeScalar<TMember>(this IServiceCollection services)
    where TMember : IAstScalarItem
    => services
      .AddMergeAll<AstScalar, AstScalar<TMember>, MergeScalars<TMember>>();
}
