using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

public static class SchemaExtensions
{
  public static IResult<E> ParseEnumValue<E>(this Tokenizer tokens, string label)
      where E : struct
      => tokens.Identifier(out var option)
        ? Enum.TryParse<E>(option, true, out var result)
          ? result.Ok()
          : tokens.Error(label, "valid enum value", result)
        : 0.Empty<E>();

  public static IResult<T> End<T>(this Tokenizer tokens, string label, Func<T> result)
    => tokens.Take('}')
      ? result().Ok()
      : tokens.Partial(label, "'}' at end of definition", result);
}
