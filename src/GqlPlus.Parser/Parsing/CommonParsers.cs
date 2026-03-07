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
  {
    services.AddSingleton<TService>();
    services.GetOrAddParserRepositoryBuilder().AddSingle(typeof(TValue), typeof(TService));
    return services;
  }

  internal static IServiceCollection AddParser<TInterface, TValue, TService>(this IServiceCollection services)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.I
  {
    services.AddSingleton<TService>();
    var builder = services.GetOrAddParserRepositoryBuilder();
    builder.AddSingle(typeof(TValue), typeof(TService));
    builder.AddInterfaceSingle(typeof(TInterface), typeof(TService));
    return services;
  }

  internal static IServiceCollection AddParserArray<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.IA
  {
    services.AddSingleton<TService>();
    services.GetOrAddParserRepositoryBuilder().AddArray(typeof(TValue), typeof(TService));
    return services;
  }

  internal static IServiceCollection AddArrayParser<TValue, TService>(this IServiceCollection services)
    where TService : class, Parser<TValue>.I
    => services
      .AddParser<TValue, TService>()
      .AddParserArray<TValue, ArrayParser<TValue>>();

  internal static IServiceCollection AddParserArray<TInterface, TValue, TService>(this IServiceCollection services)
    where TService : class, TInterface
    where TInterface : class, Parser<TValue>.IA
  {
    services.AddSingleton<TService>();
    services.GetOrAddParserRepositoryBuilder().AddInterfaceArray(typeof(TInterface), typeof(TService));
    return services;
  }

  private static ParserRepositoryBuilder GetOrAddParserRepositoryBuilder(this IServiceCollection services)
  {
    ServiceDescriptor? descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(ParserRepositoryBuilder));
    if (descriptor?.ImplementationInstance is ParserRepositoryBuilder existing) {
      return existing;
    }
    ParserRepositoryBuilder newBuilder = new();
    services.AddSingleton(newBuilder);
    return newBuilder;
  }
}
