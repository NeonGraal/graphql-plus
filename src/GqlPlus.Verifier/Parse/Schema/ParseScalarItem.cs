using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class ParseScalarItem<TItem>(
    Parser<TItem>.DA items
) : Parser<TItem>.I, IParseScalar
{
  private readonly Parser<TItem>.LA _items = items;

  public abstract ScalarDomain Kind { get; }
  public ParseItems Parser => ParseMembers;

  protected IResult<ScalarDefinition> ParseMembers(Tokenizer tokens, string label, ScalarDefinition result)
  {
    var items = _items.Parse(tokens, label);
    return items.Required(values => ApplyItems(result, values))
      ? tokens.End(label, () => result)
      : items.AsResult(result);
  }

  protected abstract void ApplyItems(ScalarDefinition result, TItem[] items);

  public abstract IResult<TItem> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;
}
