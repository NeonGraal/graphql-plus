using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

public static class SchemaExtensions
{
  public static IResult<T> End<T>(this ITokenizer tokens, string label, Func<T> result)
  {
    tokens.ThrowIfNull();
    result.ThrowIfNull();

#pragma warning disable CA1062 // Validate arguments of public methods
    return tokens.Take('}')
        ? result().Ok()
        : tokens.Partial(label, "'}' at end of definition", result);
#pragma warning restore CA1062 // Validate arguments of public methods
  }
}
