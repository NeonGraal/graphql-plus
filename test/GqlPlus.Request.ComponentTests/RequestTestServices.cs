using DiffEngine;
using GqlPlus.Decoding;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public sealed class RequestTestServices : IConfiguresServices
{
  static RequestTestServices()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static IServiceCollection Configure(IServiceCollection services)
    => services
      .AddComponentTest()
      .AddParsers(b => b.AddOperationParsers())
      .AddTransient<IRequestInputDecoder, RequestInputDecoder>();
}
