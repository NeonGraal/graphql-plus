namespace GqlPlus.Ast;

public class AstFields<TValue>
  : Dictionary<IGqlpFieldKey, TValue>
  , IEquatable<Dictionary<IGqlpFieldKey, TValue>>
  where TValue : IGqlpValue<TValue>
{
  public AstFields()
    : base() { }
  public AstFields(IDictionary<IGqlpFieldKey, TValue> dict)
    : base(dict) { }

  public virtual bool Equals(Dictionary<IGqlpFieldKey, TValue>? other)
    => other is not null
    && Keys.Order().SequenceEqual(other.Keys.Order())
    && Keys.All(k => this[k]?.Equals(other[k]) ?? false);

  public AstFields<TResult> Cast<TResult>()
    where TResult : IGqlpValue<TResult>, TValue
    => new(this.ToDictionary(kv => kv.Key, kv => (TResult)kv.Value));
}
