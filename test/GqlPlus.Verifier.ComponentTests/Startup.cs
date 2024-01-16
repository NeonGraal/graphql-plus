﻿using DiffEngine;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Modelling;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Parse.Operation;
using GqlPlus.Verifier.Parse.Schema;
using GqlPlus.Verifier.Verification;
using Microsoft.Extensions.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace GqlPlus.Verifier;

public class Startup
{
  static Startup()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddCommonParsers()
      .AddOperationParsers()
      .AddSchemaParsers()
      .AddVerifiers()
      .AddMergers()
      .AddModellers()
      .AddSingleton(_ => services)
      .AddLogging(lb =>
        lb.AddXunitOutput(options =>
          options.TimestampFormat = "HH:mm:ss.fff"));
}
