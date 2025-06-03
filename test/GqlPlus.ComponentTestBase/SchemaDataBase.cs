using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus;

public class SchemaDataBase(
    Parser<IGqlpSchema>.D schemaParser
) : SchemaParseChecks(schemaParser)
{
  protected static IEnumerable<string> ReplaceKeys(IDictionary<string, string> inputs)
    => inputs
      .ThrowIfNull()
      .Keys
      .SelectMany(k => IsObjectInput(inputs[k])
        ? Replacements.Select(r => k + "+" + r)
        : [k])
      .Order();

  protected static IEnumerable<string> ReplaceValues(IDictionary<string, string> inputs)
    => inputs
      .ThrowIfNull()
      .SelectMany(kv => ReplaceValue(kv.Value, kv.Key));

  protected static void ReplaceAction(string input, string testName, Action<string, string> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (IsObjectInput(input)) {
      foreach (string label in Replacements) {
        action(ReplaceObject(input, testName, label), testName + "+" + label);
      }
    } else {
      action(ReplaceName(input, testName), testName);
    }
  }

  protected static async Task ReplaceActionAsync(string input, string testName, Func<string, string, Task> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (IsObjectInput(input)) {
      await WhenAll([.. Replacements.Select(r => action(ReplaceObject(input, testName, r), testName + "+" + r))]);
    } else {
      await action(ReplaceName(input, testName), testName);
    }
  }
}
