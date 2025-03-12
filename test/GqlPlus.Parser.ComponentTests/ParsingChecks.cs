using GqlPlus.Parsing;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class ParsingChecks
{
  public static IServiceCollection AddOneChecks<TResult>(this IServiceCollection services)
    => services
      .AddTransient<IOneChecksParser<TResult>, OneChecksParser<TResult>>();

  public static IServiceCollection AddOneChecks<TInterface, TResult>(this IServiceCollection services)
    where TInterface : Parser<TResult>.I
    => services
      .AddTransient<IOneChecksParser<TInterface, TResult>, OneChecksParser<TInterface, TResult>>();

  public static IServiceCollection AddManyChecks<TResult>(this IServiceCollection services)
    => services
      .AddTransient<IManyChecksParser<TResult>, ManyChecksParser<TResult>>();

  public static IServiceCollection AddManyChecks<TInterface, TResult>(this IServiceCollection services)
    where TInterface : Parser<TResult>.IA
    => services
      .AddTransient<IManyChecksParser<TInterface, TResult>, ManyChecksParser<TInterface, TResult>>();
}
