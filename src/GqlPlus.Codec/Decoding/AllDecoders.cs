using GqlPlus.Ast.Schema;
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
      .AddDecoder(_ => new BooleanDecoder())
      .AddDecoder(_ => new NumberDecoder())
      .AddDecoder(_ => new StringDecoder())
      .AddDecoder(_ => new ConstantDecoder())
      .AddDecoder(_ => new SimpleDecoder())
      // Schema
      .AddDecoder(_ => new EnumDecoder<CategoryOption>())
      .AddDecoder(_ => new EnumDecoder<TypeKindModel>())
      .AddNameFilter(_ => new NameFilterModelDecoder())
      .AddDecoder(r => new FilterModelDecoder(r))
      .AddDecoder(r => new CategoryFilterModelDecoder(r))
      .AddDecoder(r => new TypeFilterModelDecoder(r));
}
