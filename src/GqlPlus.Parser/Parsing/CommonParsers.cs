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
      .AddValueParsers<IGqlpConstant, ParseConstant>()
      .AddSingleton<IParserRepository, ParserRepository>();

  internal static IServiceCollection AddValueParsers<TValue, TParser>(this IServiceCollection services)
    where TValue : IGqlpValue<TValue>
    where TParser : class, Parser<TValue>.I, IValueParser<TValue>
    => services
      .AddParser<IValueParser<TValue>, TValue, TParser>()
      .AddParser<KeyValue<TValue>, ValueKeyValueParser<TValue>>()
      .AddParserArray<TValue, ValueListParser<TValue>>()
      .AddParser<IGqlpFields<TValue>, ValueObjectParser<TValue>>();

  internal static IServiceCollection AddParser<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.I
    => services
      .AddSingleton<TService>()
      .AddSingleton(new ParserRegistration(typeof(TValue), typeof(TService), ParserRegistrationKind.Single));

  internal static IServiceCollection AddParser<TInterface, TValue, TService>(this IServiceCollection services)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.I
    => services
      .AddSingleton<TService>()
      .AddSingleton(new ParserRegistration(typeof(TValue), typeof(TService), ParserRegistrationKind.Single))
      .AddSingleton(new ParserRegistration(typeof(TInterface), typeof(TService), ParserRegistrationKind.SingleInterface));

  internal static IServiceCollection AddParserArray<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.IA
    => services
      .AddSingleton<TService>()
      .AddSingleton(new ParserRegistration(typeof(TValue), typeof(TService), ParserRegistrationKind.Array));

  internal static IServiceCollection AddArrayParser<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.I
    => services
      .AddParser<TValue, TService>()
      .AddSingleton<ArrayParser<TValue>>()
      .AddSingleton(new ParserRegistration(typeof(TValue), typeof(ArrayParser<TValue>), ParserRegistrationKind.Array));

  internal static IServiceCollection AddParserArray<TInterface, TValue, TService>(this IServiceCollection services)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.IA
    => services
      .AddSingleton<TService>()
      .AddSingleton(new ParserRegistration(typeof(TInterface), typeof(TService), ParserRegistrationKind.ArrayInterface));
}
