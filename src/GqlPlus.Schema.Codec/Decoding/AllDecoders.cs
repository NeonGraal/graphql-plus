using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Decoding;

public static class AllDecoders
{
  public static IServiceCollection AddDecoders(this IServiceCollection services, Action<IDecoderRepositoryBuilder> config)
    => services
      .AddSingleton(new DecoderRepositoryBuilder().FluentAction(b => config(b)))
      .AddSingleton<IDecoderRepository, DecoderRepository>();

  [ExcludeFromCodeCoverage]
  internal static IDecoderRepositoryBuilder AddSchemaDecoders(this IDecoderRepositoryBuilder builder)
    => builder.ThrowIfNull()
      // Common
      .AddDecoder(BooleanDecoder.Factory)
      .AddDecoder(NumberDecoder.Factory)
      .AddDecoder(StringDecoder.Factory)
      .AddDecoder(ConstantDecoder.Factory)
      .AddDecoder(SimpleDecoder.Factory)
      // Schema
      .AddDecoder(EnumDecoder<CategoryOptionModel>.Factory)
      .AddDecoder(EnumDecoder<TypeKindModel>.Factory)
      .AddDecoder<INameFilterDecoder, string>(NameFilterModelDecoder.Factory)
      .AddDecoder(FilterModelDecoder.Factory)
      .AddDecoder(CategoryFilterModelDecoder.Factory)
      .AddDecoder(TypeFilterModelDecoder.Factory);
}
