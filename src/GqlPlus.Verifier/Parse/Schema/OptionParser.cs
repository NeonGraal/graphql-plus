namespace GqlPlus.Verifier.Parse.Schema;

internal class OptionParser<O> : Parser<O>.I
  where O : struct
{
  public IResult<O> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (tokens.Take('(')) {
      var enumValue = tokens.ParseEnumValue<O>(label);

      return enumValue.Map(result =>
        tokens.Take(')')
          ? enumValue
          : tokens.Partial(label, "')' after option", () => result));
    }

    return 0.Empty<O>();
  }
}
