using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Verifier.Merging;

public static class AllMergers
{
  public static IServiceCollection AddMergers(this IServiceCollection services)
    => services
      .AddMerge<AstType, MergeAllTypes>()
      .AddMerge<CategoryDeclAst, MergeCategories>()
      .AddMerge<ConstantAst, MergeConstants>()
      .AddMerge<DirectiveDeclAst, MergeDirectives>()
      .AddMerge<ParameterAst, MergeParameters>()
      .AddMerge<EnumDeclAst, MergeEnums>()
      .AddMerge<EnumValueAst, MergeEnumValues>()
      .AddMerge<TypeParameterAst, MergeTypeParameters>()
      .AddMerge<AlternateAst<InputReferenceAst>, AlternatesMerger<InputReferenceAst>>()
      .AddMerge<InputFieldAst, MergeInputFields>()
      .AddMerge<InputDeclAst, MergeInputObjects>()
      .AddMerge<AlternateAst<OutputReferenceAst>, AlternatesMerger<OutputReferenceAst>>()
      .AddMerge<OutputFieldAst, MergeOutputFields>()
      .AddMerge<OutputDeclAst, MergeOutputObjects>()
      .AddMerge<ScalarDeclAst, MergeScalars>()
      .AddMerge<ScalarRangeAst, MergeScalarRanges>()
      .AddMerge<ScalarRegexAst, MergeScalarRegexes>()
      .AddMerge<SchemaAst, MergeSchemas>()
    ;

  public static IServiceCollection AddMerge<T, S>(this IServiceCollection services)
    where S : class, IMerge<T>
    => services
      .RemoveAll<IMerge<T>>()
      .AddSingleton<IMerge<T>, S>();
}
