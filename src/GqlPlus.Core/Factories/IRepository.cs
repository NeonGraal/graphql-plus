using Microsoft.Extensions.Logging;

namespace GqlPlus.Factories;

public interface IRepository
{
  ILoggerFactory LoggerFactory { get; }
}
