using System.Collections.Immutable;

namespace GqlPlus.Ast;

internal static class AstExtensions
{
  public static IAstFields<TValue> ToObject<TItem, TValue>(
    this IEnumerable<TItem> items,
    Func<TItem, IAstFieldKey> key,
    Func<TItem, TValue> value
  )
    where TValue : IAstValue<TValue>
    => new FieldsAst<TValue>(items.Distinct().ToImmutableDictionary(key, value));
}
