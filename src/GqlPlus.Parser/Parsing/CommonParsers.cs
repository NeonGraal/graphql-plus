using GqlPlus.Ast;
using GqlPlus.Parsing.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

public static class CommonParsers
{
  public static IServiceCollection AddCommonParsers(this IServiceCollection services)
    => services
      .AddParser<IGqlpFieldKey, ParseFieldKey>()
      .AddParserArray<IGqlpModifier, ParseModifiers>()
      .AddParserArray<IParserCollections, IGqlpModifier, ParseCollections>()
      .AddParser<IParserDefault, ConstantAst, ParseDefault>()
      .AddValueParsers<ConstantAst, ParseConstant>();

  internal static IServiceCollection AddValueParsers<TValue, TParser>(this IServiceCollection services)
    where TValue : AstValue<TValue>
    where TParser : class, Parser<TValue>.I, IValueParser<TValue>
    => services
      .AddParser<IValueParser<TValue>, TValue, TParser>()
      .AddParser<KeyValue<TValue>, ValueKeyValueParser<TValue>>()
      .AddParserArray<TValue, ValueListParser<TValue>>()
      .AddParser<AstFields<TValue>, ValueObjectParser<TValue>>();

  internal static IServiceCollection AddParser<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.I
    => services
      .AddSingleton<TService>()
      .AddSingleton<Parser<TValue>.D>(x => () => x.GetRequiredService<TService>());

  internal static IServiceCollection AddParser<TInterface, TValue, TService>(this IServiceCollection services)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.I
    => services
      .AddSingleton<TService>()
      .AddSingleton<Parser<TValue>.D>(x => () => x.GetRequiredService<TService>())
      .AddSingleton<Parser<TInterface, TValue>.D>(x => () => x.GetRequiredService<TService>());

  internal static IServiceCollection AddParserArray<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.IA
    => services
      .AddSingleton<TService>()
      .AddSingleton<Parser<TValue>.DA>(x => () => x.GetRequiredService<TService>());

  internal static IServiceCollection AddArrayParser<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.I
    => services
      .AddParser<TValue, TService>()
      .AddParserArray<TValue, ArrayParser<TValue>>();

  internal static IServiceCollection AddParserArray<TInterface, TValue, TService>(this IServiceCollection services)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.IA
    => services
      .AddSingleton<TService>()
      .AddSingleton<ParserArray<TInterface, TValue>.DA>(x => () => x.GetRequiredService<TService>());
}
