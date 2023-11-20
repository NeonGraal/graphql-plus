using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier.Parse.Common;

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
    => services
      .AddSingleton<IParser<FieldKeyAst>, ParseFieldKey>()
      .AddSingleton<IParserArray<ModifierAst>, ParseModifiers>()
      .AddSingleton<ParseConstant>()
      .AddSingleton<IParser<ConstantAst>>(x => x.GetRequiredService<ParseConstant>())
      .AddSingleton<IParser<Field<ConstantAst>>>(x => x.GetRequiredService<ParseConstant>());
}
