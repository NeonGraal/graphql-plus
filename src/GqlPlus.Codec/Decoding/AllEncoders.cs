using GqlPlus.Abstractions.Schema;
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
      .AddDecoder<bool?>(_ => new BooleanDecoder())
      .AddDecoder<decimal?>(_ => new NumberDecoder())
      .AddDecoder<string>(_ => new StringDecoder())
      .AddDecoder<ConstantModel>(_ => new ConstantDecoder())
      .AddDecoder<SimpleModel>(_ => new SimpleDecoder())
      // Schema
      .AddDecoder<CategoryOption?>(_ => new EnumDecoder<CategoryOption>())
      .AddDecoder<TypeKindModel?>(_ => new EnumDecoder<TypeKindModel>())
      .AddNameFilter(_ => new NameFilterModelDecoder())
      .AddDecoder<FilterModel>(r => new FilterModelDecoder(r.DecoderFor<bool?>(), r.NameFilterDecoder))
      .AddDecoder<CategoryFilterModel>(r => new CategoryFilterModelDecoder(r.DecoderFor<bool?>(), r.NameFilterDecoder, r.DecoderFor<CategoryOption?>()))
      .AddDecoder<TypeFilterModel>(r => new TypeFilterModelDecoder(r.DecoderFor<bool?>(), r.NameFilterDecoder, r.DecoderFor<TypeKindModel?>()));
}
