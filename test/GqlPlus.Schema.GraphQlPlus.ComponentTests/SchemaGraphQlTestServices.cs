using DiffEngine;
using Microsoft.Extensions.DependencyInjection;
using GqlPlus.Encoding;
using GqlPlus.Schema.Modelling;

namespace GqlPlus;

public sealed class SchemaGraphQlTestServices : IConfiguresServices
{
  static SchemaGraphQlTestServices()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection Configure(IServiceCollection services)
    => services
    .AddModellerComponentTestBase()
    .AddSchModellers(b => b.AddSchSchemaModellers())
    .AddEncoders(b => b.AddSchEncoders())
    .AddTransient<ISchGraphQlPlusVerifyChecks, SchGraphQlPlusVerifyChecks>();
}
