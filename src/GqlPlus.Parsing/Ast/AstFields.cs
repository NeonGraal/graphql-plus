namespace GqlPlus.Ast;

public class AstFields<T>
  : Dictionary<FieldKeyAst, T>
  , IEquatable<Dictionary<FieldKeyAst, T>>
  where T : AstValue<T>
{
  public AstFields()
    : base() { }
  public AstFields(IDictionary<FieldKeyAst, T> dict)
    : base(dict) { }

  public virtual bool Equals(Dictionary<FieldKeyAst, T>? other)
    => other is not null
    && Keys.Order().SequenceEqual(other.Keys.Order())
    && Keys.All(k => this[k]?.Equals(other[k]) ?? false);
}
