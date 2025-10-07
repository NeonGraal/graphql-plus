using GqlPlus.Parsing.Schema;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

public static class CommonParsers
{
  public static IServiceCollection AddCommonParsers(this IServiceCollection services)
    => services
      .AddParser<IGqlpEnumValue, ParseEnumValue>()
      .AddParser<IGqlpFieldKey, ParseFieldKey>()
      .AddParserArray<IGqlpModifier, ParseModifiers>()
      .AddParserArray<IParserCollections, IGqlpModifier, ParseCollections>()
      .AddParser<IParserDefault, IGqlpConstant, ParseDefault>()
      .AddValueParsers<IGqlpConstant, ParseConstant>();

  internal static IServiceCollection AddValueParsers<TValue, TParser>(this IServiceCollection services)
    where TValue : IGqlpValue<TValue>
    where TParser : class, Parser<TValue>.I, IValueParser<TValue>
    => services
      .AddParser<IValueParser<TValue>, TValue, TParser>()
      .AddParser<KeyValue<TValue>, ValueKeyValueParser<TValue>>()
      .AddParserArray<TValue, ValueListParser<TValue>>()
      .AddParser<IGqlpFields<TValue>, ValueObjectParser<TValue>>();

  private static Parser<TValue>.D GetParser<TService, TValue>(IServiceProvider provider)
    where TService : class, Parser<TValue>.I
    => provider.GetRequiredService<TService>;

  internal static IServiceCollection AddParser<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.I
    => services
      .AddSingleton<TService>()
      .AddSingleton(GetParser<TService, TValue>);

  private static Parser<TInterface, TValue>.D GetInterfaceParser<TService, TInterface, TValue>(IServiceProvider provider)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.I
    => provider.GetRequiredService<TService>;

  internal static IServiceCollection AddParser<TInterface, TValue, TService>(this IServiceCollection services)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.I
    => services
      .AddSingleton<TService>()
      .AddSingleton(GetParser<TService, TValue>)
      .AddSingleton(GetInterfaceParser<TService, TInterface, TValue>);

  private static Parser<TValue>.DA GetParserArray<TService, TValue>(IServiceProvider provider)
    where TService : class, Parser<TValue>.IA
    => provider.GetRequiredService<TService>;

  internal static IServiceCollection AddParserArray<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.IA
    => services
      .AddSingleton<TService>()
      .AddSingleton(GetParserArray<TService, TValue>);

  internal static IServiceCollection AddArrayParser<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.I
    => services
      .AddParser<TValue, TService>()
      .AddParserArray<TValue, ArrayParser<TValue>>();

  private static ParserArray<TInterface, TValue>.DA GetInterfaceParserArray<TService, TInterface, TValue>(IServiceProvider provider)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.IA
    => provider.GetRequiredService<TService>;

  internal static IServiceCollection AddParserArray<TInterface, TValue, TService>(this IServiceCollection services)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.IA
    => services
      .AddSingleton<TService>()
      .AddSingleton(GetInterfaceParserArray<TService, TInterface, TValue>);
}
