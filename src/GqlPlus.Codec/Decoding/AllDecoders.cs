using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Decoding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Decoding;

public static class AllDecoders
{
  public static IServiceCollection AddDecoders(this IServiceCollection services)
  {
    DecoderRepositoryBuilder builder = new();
    builder.AddSchemaDecoders();
    services.AddSingleton(builder);
    services.TryAddSingleton<IDecoderRepository, DecoderRepository>();
    return services;
  }

  internal static IDecoderRepositoryBuilder AddSchemaDecoders(this IDecoderRepositoryBuilder builder)
    => builder.ThrowIfNull()
      // Common
      .AddDecoder(BooleanDecoder.Factory)
      .AddDecoder(NumberDecoder.Factory)
      .AddDecoder(StringDecoder.Factory)
      .AddDecoder(ConstantDecoder.Factory)
      .AddDecoder(SimpleDecoder.Factory)
      // Schema
      .AddDecoder(EnumDecoder<CategoryOption>.Factory)
      .AddDecoder(EnumDecoder<TypeKindModel>.Factory)
      .AddDecoder<INameFilterDecoder, string>(NameFilterModelDecoder.Factory)
      .AddDecoder(FilterModelDecoder.Factory)
      .AddDecoder(CategoryFilterModelDecoder.Factory)
      .AddDecoder(TypeFilterModelDecoder.Factory);
}
