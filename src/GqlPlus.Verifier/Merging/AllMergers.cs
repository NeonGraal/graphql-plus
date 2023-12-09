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
      .AddMerge<EnumDeclAst, MergeEnums>()
      .AddMerge<ParameterAst, MergeParameters>()
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
