using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

public static class ParsingChecks
{
  public static IServiceCollection AddOneChecks<TResult>(this IServiceCollection services)
    => services
      .AddSingleton<IOneChecksParser<TResult>, OneChecksParser<TResult>>();

  public static IServiceCollection AddOneChecks<TInterface, TResult>(this IServiceCollection services)
    where TInterface : Parser<TResult>.I
    => services
      .AddSingleton<IOneChecksParser<TInterface, TResult>, OneChecksParser<TInterface, TResult>>();

  public static IServiceCollection AddManyChecks<TResult>(this IServiceCollection services)
    => services
      .AddSingleton<IManyChecksParser<TResult>, ManyChecksParser<TResult>>();

  public static IServiceCollection AddManyChecks<TInterface, TResult>(this IServiceCollection services)
    where TInterface : Parser<TResult>.IA
    => services
      .AddSingleton<IManyChecksParser<TInterface, TResult>, ManyChecksParser<TInterface, TResult>>();
}
