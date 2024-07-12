using GqlPlus.Abstractions.Operation;

using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing.Operation;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddOneChecks<IParserArgument, IGqlpArgument>()
      .AddOneChecks<IGqlpArgument>()
      .AddManyChecks<IGqlpDirective>()
      .AddOneChecks<IGqlpField>()
      .AddManyChecks<IParserStartFragments, IGqlpFragment>()
      .AddManyChecks<IParserEndFragments, IGqlpFragment>()
      .AddManyChecks<IGqlpSelection>()
      .AddOneChecks<IGqlpSelection>()
      .AddManyChecks<IGqlpVariable>()
      .AddOneChecks<IGqlpVariable>()
      .AddOneChecks<IParserVarType, string>()

      .AddComponentTest();
}
