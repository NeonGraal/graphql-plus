using Microsoft.Extensions.Logging;

namespace GqlPlus;

internal static partial class TestSchemaLogging
{

  [LoggerMessage(LogLevel.Information, Message = "Parsing {Label} '{Input}'")]
  internal static partial void ParsingLabelledInput(this ILogger logger, string label, string input);
}
