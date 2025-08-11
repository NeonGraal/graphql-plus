using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Decoding;

public static class AllDecoders
{
  public static IServiceCollection AddDecoders(this IServiceCollection services)
  => services
      // Common
      .AddDecoder<bool?, BooleanDecoder>()
      .AddDecoder<decimal?, NumberDecoder>()
      .AddDecoder<string, StringDecoder>()
      .AddDecoder<ConstantModel, ConstantDecoder>()
      .AddDecoder<SimpleModel, SimpleDecoder>()
      // Schema
      .AddDecoder<CategoryOption?, EnumDecoder<CategoryOption>>()
      .AddDecoder<TypeKindModel?, EnumDecoder<TypeKindModel>>()
      .AddSingleton<INameFilterDecoder, NameFilterModelDecoder>()
      .AddDecoder<FilterModel, FilterModelDecoder>()
      .AddDecoder<CategoryFilterModel, CategoryFilterModelDecoder>()
      .AddDecoder<TypeFilterModel, TypeFilterModelDecoder>()
    ;

  private static IServiceCollection AddDecoder<TOutput, TDecoder>(this IServiceCollection services)
    where TDecoder : class, IDecoder<TOutput>
    => services.AddSingleton<IDecoder<TOutput>, TDecoder>();
}
