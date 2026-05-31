using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Decoding;

public static class AllDecoders
{
  public static IServiceCollection AddDecoders(this IServiceCollection services, Action<IDecoderRepositoryBuilder> config)
    => services
      .AddSingleton(new DecoderRepositoryBuilder().FluentInterface(config))
      .AddSingleton<IDecoderRepository, DecoderRepository>();

  internal static IDecoderRepositoryBuilder AddSchemaDecoders(this IDecoderRepositoryBuilder builder)
    => builder.ThrowIfNull()
      .CommonDecoders()
      .SchemaDecoders();

  private static IDecoderRepositoryBuilder CommonDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder(BooleanDecoder.Factory)
      .AddDecoder(NumberDecoder.Factory)
      .AddDecoder(StringDecoder.Factory)
      .AddDecoder(ConstantDecoder.Factory)
      .AddDecoder(SimpleDecoder.Factory);

  private static IDecoderRepositoryBuilder SchemaDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder(EnumDecoder<CategoryOptionModel>.Factory)
      .AddDecoder(EnumDecoder<TypeKindModel>.Factory)
      .AddDecoder<INameFilterDecoder, string>(NameFilterModelDecoder.Factory)
      .AddDecoder(FilterModelDecoder.Factory)
      .AddDecoder(CategoryFilterModelDecoder.Factory)
      .AddDecoder(TypeFilterModelDecoder.Factory);
}
