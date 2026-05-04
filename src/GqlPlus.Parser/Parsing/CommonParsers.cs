using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Parsing;

public static class CommonParsers
{
  public static IParserRepositoryBuilder AddCommonParsers(this IParserRepositoryBuilder builder)
    => builder.ThrowIfNull()
        .AddSingle(ParseEnumValue.Factory)
        .AddSingle(ParseFieldKey.Factory)
        .AddArray(ParseModifiers.Factory)
        .AddInterfaceArray<IParserCollections>(ParseCollections.Factory)
        .AddInterfaceSingle<IParserDefault>(ParseDefault.Factory)
        .AddValueParsers(ParseConstant.Factory);

  public static IServiceCollection AddParsers(this IServiceCollection services, Action<IParserRepositoryBuilder> config)
  {
    services.TryAddSingleton<IParserRepository, ParserRepository>();
    ServiceDescriptor? descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(ParserRepositoryBuilder));
    if (descriptor?.ImplementationInstance is not ParserRepositoryBuilder builder) {
      builder = new();
      services.AddSingleton(builder);
    }

    config?.Invoke(builder);
    return services;
  }

  internal static IParserRepositoryBuilder AddValueParsers<TValue>(this IParserRepositoryBuilder builder, Factory<ValueParser<TValue>, IParserRepository> factory)
    where TValue : IAstValue<TValue>
    => builder
      .AddSingle(factory)
      .AddInterfaceSingle<IValueParser<TValue>>(factory)
      .AddSingle(ValueKeyValueParser<TValue>.Factory)
      .AddArray(ValueListParser<TValue>.Factory)
      .AddSingle(ValueObjectParser<TValue>.Factory);
}
