﻿using GqlPlus.Abstractions.Operation;
using GqlPlus.Parsing.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Operation;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddOneChecks<IParserArg, IGqlpArg>()
      .AddOneChecks<IGqlpArg>()
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
