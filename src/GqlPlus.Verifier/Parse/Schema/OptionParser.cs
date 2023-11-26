namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class OptionParser<O> : IParser<O>
  where O : struct
{
  protected abstract string Label { get; }

  public IResult<O> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    if (tokens.Take('(')) {
      var enumValue = tokens.ParseEnumValue<O>(Label);

      return enumValue.Map(result =>
        tokens.Take(')')
          ? enumValue
          : tokens.Partial(Label, "')' after option", () => result));
    }

    return 0.Empty<O>();
  }
}
