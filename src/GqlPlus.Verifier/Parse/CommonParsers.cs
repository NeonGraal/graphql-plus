using GqlPlus.Verifier.Ast;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse;

public static class CommonParsers
{
  public static IServiceCollection AddCommonParsers(this IServiceCollection services)
    => services
      .AddParser<FieldKeyAst, ParseFieldKey>()
      .AddParserArray<ModifierAst, ParseModifiers>()
      .AddParser<IParserDefault, ConstantAst, ParseDefault>()
      .AddValueParsers<ConstantAst, ParseConstant>();

  public static IServiceCollection AddValueParsers<T, P>(this IServiceCollection services)
    where T : AstValue<T>
    where P : class, Parser<T>.I, IValueParser<T>
    => services
      .AddParser<T, P>()
      .AddSingleton<IValueParser<T>>(x => x.GetRequiredService<P>())
      .AddParser<AstKeyValue<T>, ValueKeyValueParser<T>>()
      .AddParserArray<T, ValueListParser<T>>()
      .AddParser<AstObject<T>, ValueObjectParser<T>>();

  public static IServiceCollection AddFunc<T>(this IServiceCollection services, Func<IServiceProvider, T> factory)
    where T : class
    => services
      .AddSingleton(factory)
      .AddSingleton<Func<T>>(x => () => x.GetRequiredService<T>());

  public static IServiceCollection AddParser<T, S>(this IServiceCollection services)
    where S : class, Parser<T>.I
    => services
      .AddSingleton<S>()
      .AddSingleton<Parser<T>.D>(x => () => x.GetRequiredService<S>());

  public static IServiceCollection AddParser<I, T, S>(this IServiceCollection services)
    where S : class, I
    where I : class, Parser<T>.I
    => services
      .AddSingleton<S>()
      .AddSingleton<Parser<I, T>.D>(x => () => x.GetRequiredService<S>());

  public static IServiceCollection AddParserArray<T, S>(this IServiceCollection services)
    where S : class, Parser<T>.IA
    => services
      .AddSingleton<S>()
      .AddSingleton<Parser<T>.DA>(x => () => x.GetRequiredService<S>());

  public static IServiceCollection AddParserArray<I, T, S>(this IServiceCollection services)
    where S : class, I
    where I : class, Parser<T>.IA
    => services
      .AddSingleton<S>()
      .AddSingleton<ParserArray<I, T>.DA>(x => () => x.GetRequiredService<S>());
}
