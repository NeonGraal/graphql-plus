using GqlPlus.Verifier.Ast;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Common;

public static class CommonParsers
{
  public static IServiceCollection AddCommonParsers(this IServiceCollection services)
    => services
      .AddSingleton<IParser<FieldKeyAst>, ParseFieldKey>()
      .AddSingleton<IParserArray<ModifierAst>, ParseModifiers>()
      .AddSingleton<IParserDefault, ParseDefault>()
      .AddSingleton<ParseConstant>()
      .AddSingleton<IParser<ConstantAst>>(x => x.GetRequiredService<ParseConstant>())
      .AddSingleton<IParserValue<ConstantAst>>(x => x.GetRequiredService<ParseConstant>())
      .AddSingleton<IParser<Field<ConstantAst>>>(x => x.GetRequiredService<ParseConstant>());

}
