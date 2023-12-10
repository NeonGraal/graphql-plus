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
      .AddMerge<DirectiveDeclAst, MergeDirectives>()
      .AddMerge<ParameterAst, MergeParameters>()
      .AddMerge<EnumDeclAst, MergeEnums>()
      .AddMerge<EnumValueAst, MergeEnumValues>()
      .AddMerge<AlternateAst<InputReferenceAst>, AlternatesMerger<InputReferenceAst>>()
      .AddMerge<AlternateAst<OutputReferenceAst>, AlternatesMerger<OutputReferenceAst>>()
      .AddMerge<ScalarDeclAst, MergeScalars>()
      .AddMerge<ScalarRangeAst, MergeScalarRanges>()
      .AddMerge<ScalarRegexAst, MergeScalarRegexes>()
    ;

  public static IServiceCollection AddMerge<T, S>(this IServiceCollection services)
    where S : class, IMerge<T>
    => services.AddSingleton<IMerge<T>, S>();

  public static IServiceCollection TryAddMerge<T, S>(this IServiceCollection services)
    where S : class, IMerge<T>
  {
    services.TryAddSingleton<IMerge<T>, S>();
    return services;
  }
}
