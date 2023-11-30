using GqlPlus.Verifier.Ast;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse;

public static class CommonParsers
{
  public static IServiceCollection AddCommonParsers(this IServiceCollection services)
    => services
      .AddSingleton<IParser<FieldKeyAst>, ParseFieldKey>()
      .AddFunc<IParserArray<ModifierAst>, ParseModifiers>()
      .AddSingleton<IParserDefault, ParseDefault>()
      .AddValueParser<ConstantAst, ParseConstant>();

  public static IServiceCollection AddValueParser<T, P>(this IServiceCollection services)
    where P : class, IValueParser<T>
    where T : AstValue<T>
    => services
      .AddSingleton<P>()
      .AddSingleton<IParser<T>>(x => x.GetRequiredService<P>())
      .AddSingleton<IValueParser<T>>(x => x.GetRequiredService<P>())
      .AddSingleton<IParser<Field<T>>>(x => x.GetRequiredService<P>().FieldIParser);

  public static IServiceCollection AddFunc<T, I>(this IServiceCollection services)
    where T : class where I : class, T
    => services
      .AddSingleton<T, I>()
      .AddSingleton<Func<T>>(x => () => x.GetRequiredService<T>());

  public static IServiceCollection AddFunc<T>(this IServiceCollection services, Func<IServiceProvider, T> factory)
    where T : class
    => services
      .AddSingleton<T>(factory)
      .AddSingleton<Func<T>>(x => () => x.GetRequiredService<T>());
}
