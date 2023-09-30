namespace GqlPlus.Verifier.Ast;

public static class AstExtensions
{
  public static IOrderedEnumerable<KeyValuePair<K, V>> Ordered<K, V>(this IDictionary<K, V> dictionary)
    => dictionary.OrderBy(p => p.Key);

  public static bool NullEqual<T>(this T? left, T? right)
    where T : IEquatable<T>
    => left is null && right is null
    || left is not null && left.Equals(right);
}
