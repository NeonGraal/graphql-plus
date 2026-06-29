using GqlPlus.Decoding;
using GqlPlus.Parsing;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddComponentTest()
      .AddParsers(b => b.AddOperationParsers())
      .AddTransient<IRequestInputDecoder, RequestInputDecoder>();
}
