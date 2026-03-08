using GqlPlus.Parsing.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

public static class OperationParsersSetup
{
  public static IServiceCollection AddOperationParsers(this IServiceCollection services)
    => services.AddParsers(b => b.AddOperationParsers());
}
