using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class ParseDomainItem<TItem>(
    Parser<TItem>.DA items
) : Parser<TItem>.I, IParseDomain
{
  private readonly Parser<TItem>.LA _items = items;

  public abstract DomainDomain Kind { get; }
  public ParseItems Parser => ParseMembers;

  protected IResult<DomainDefinition> ParseMembers(Tokenizer tokens, string label, DomainDefinition result)
  {
    var items = _items.Parse(tokens, label);
    return items.Required(values => ApplyItems(result, values))
      ? tokens.End(label, () => result)
      : items.AsResult(result);
  }

  protected abstract void ApplyItems(DomainDefinition result, TItem[] items);

  public abstract IResult<TItem> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;
}
