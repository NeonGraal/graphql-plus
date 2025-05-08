﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal abstract class ParseDomainItem<TItem>(
    Parser<TItem>.DA items
) : Parser<TItem>.I, IParseDomain
{
  private readonly Parser<TItem>.LA _items = items;

  public abstract DomainKind Kind { get; }
  public ParseItems Parser => ParseItems;

  protected IResult<DomainDefinition> ParseItems(ITokenizer tokens, string label, DomainDefinition result)
  {
    IResultArray<TItem> items = _items.Parse(tokens, label);
    return items.Required(values => ApplyItems(tokens, label, result, [.. values]))
      ? tokens.End(label, () => result)
      : items.AsResult(result);
  }

  protected abstract void ApplyItems(ITokenizer tokens, string label, DomainDefinition result, TItem[] items);

  public abstract IResult<TItem> Parse(ITokenizer tokens, string label)
    ;
}
