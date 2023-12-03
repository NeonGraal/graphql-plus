using GqlPlus.Verifier.Ast;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse;

public static class CommonParsers
{
  public static IServiceCollection AddCommonParsers(this IServiceCollection services)
    => services
      .AddParser<FieldKeyAst, ParseFieldKey>()
      .AddParserArray<ModifierAst, ParseModifiers>()
      .AddSingleton<IParserDefault, ParseDefault>()
      .AddValueParser<ConstantAst, ParseConstant>()
      .AddValueParsers<ConstantAst, ParseConstant, ParseConstantKeyValue, ParseConstantObject>();

  public static IServiceCollection AddValueParser<T, P>(this IServiceCollection services)
    where P : class, IValueParser<T>
    where T : AstValue<T>
    => services
      .AddSingleton<P>()
      .AddSingleton<IParser<T>>(x => x.GetRequiredService<P>())
      .AddSingleton<IValueParser<T>>(x => x.GetRequiredService<P>())
      .AddSingleton<IParser<AstKeyValue<T>>>(x => x.GetRequiredService<P>().FieldIParser);

  public static IServiceCollection AddValueParsers<T, P, F, O>(this IServiceCollection services)
    where T : AstValue<T>
    where P : class, Parser<T>.I
    where F : class, Parser<AstKeyValue<T>>.I
    where O : class, Parser<AstObject<T>>.I
    => services
      .AddParser<T, P>()
      .AddParser<AstKeyValue<T>, F>()
      .AddParserArray<T, ValueListParser<T>>()
      .AddParser<AstObject<T>, O>();

  public static IServiceCollection AddFunc<T, I>(this IServiceCollection services)
    where T : class where I : class, T
    => services
      .AddSingleton<T, I>()
      .AddSingleton<Func<T>>(x => () => x.GetRequiredService<T>());

  public static IServiceCollection AddFunc<T>(this IServiceCollection services, Func<IServiceProvider, T> factory)
    where T : class
    => services
      .AddSingleton(factory)
      .AddSingleton<Func<T>>(x => () => x.GetRequiredService<T>());

  public static IServiceCollection AddParser<T, S>(this IServiceCollection services)
    where S : class, Parser<T>.I
    => services
      .AddSingleton<S>()
      .AddSingleton<Parser<T>.I>(x => x.GetRequiredService<S>())
      .AddSingleton<Parser<T>.D>(x => () => x.GetRequiredService<S>());

  public static IServiceCollection AddParserArray<T, S>(this IServiceCollection services)
    where S : class, Parser<T>.IA
    => services
      .AddSingleton<S>()
      .AddSingleton<Parser<T>.IA>(x => x.GetRequiredService<S>())
      .AddSingleton<Parser<T>.DA>(x => () => x.GetRequiredService<S>());
}
