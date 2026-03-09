using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Parsing;

public static class CommonParsers
{
  public static IParserRepositoryBuilder AddCommonParsers(this IParserRepositoryBuilder builder)
    => builder.ThrowIfNull()
        .AddSingle(_ => new ParseEnumValue())
        .AddSingle(p => new ParseFieldKey(p))
        .AddArray(p => new ParseModifiers(p))
        .AddInterfaceArray<IParserCollections>(_ => new ParseCollections())
        .AddInterfaceSingle<IParserDefault>(p => new ParseDefault(p))
        .AddValueParsers(p => new ParseConstant(p));

  public static IServiceCollection AddParsers(this IServiceCollection services, Action<IParserRepositoryBuilder> config)
  {
    services.TryAddSingleton<IParserRepository, ParserRepository>();
    ServiceDescriptor? descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(ParserRepositoryBuilder));
    if (descriptor?.ImplementationInstance is not ParserRepositoryBuilder builder) {
      builder = new();
      services.AddSingleton(builder);
      services.AddProvider<ParserRepositoryBuilder, IParserRepositoryBuilder>();
    }

    config?.Invoke(builder);
    return services;
  }

  internal static IParserRepositoryBuilder AddValueParsers<TValue>(this IParserRepositoryBuilder builder, ParserFactory<ValueParser<TValue>> factory)
    where TValue : IGqlpValue<TValue>
    => builder
      .AddSingle(factory)
      .AddInterfaceSingle<IValueParser<TValue>>(factory)
      .AddSingle(p => new ValueKeyValueParser<TValue>(p))
      .AddArray(p => new ValueListParser<TValue>(p))
      .AddSingle(p => new ValueObjectParser<TValue>(p));
}
