using System.Collections.Immutable;
using System.Globalization;

namespace GqlPlus.Ast;

public static class AstExtensions
{
  public static IGqlpFields<TValue> ToObject<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, IGqlpFieldKey> key, Func<TItem, TValue> value)
    where TValue : IGqlpValue<TValue>
    => new AstFields<TValue>(items.Distinct().ToImmutableDictionary(key, value));
}
