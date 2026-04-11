namespace GqlPlus.Ast;

internal abstract record class AstValue<TValue>(
  ITokenAt At
) : AstAbbreviated(At)
  , IAstValue<TValue>
  where TValue : IAstValue<TValue>
{
  public TValue[] Values { get; init; } = [];
  public IAstFields<TValue> Fields { get; init; } = new FieldsAst<TValue>();

  IEnumerable<TValue> IAstValue<TValue>.Values => Values;
  IAstFields<TValue> IAstValue<TValue>.Fields => Fields;

  internal AstValue(ITokenAt at, IEnumerable<TValue> values)
    : this(at)
    => Values = [.. values];
  internal AstValue(ITokenAt at, IAstFields<TValue> fields)
    : this(at)
    => Fields = fields;

  public bool Equals(IAstValue<TValue>? other)
    => other is not null
    && Values.SequenceEqual(other.Values)
    && Fields.Equals(other.Fields);
  public override int GetHashCode()
    => HashCode.Combine(Values.Length, Fields.Count);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Values.Bracket("[", "]"))
      .Concat(Fields.Bracket("{", "}", kv => $"{kv.Key}:{kv.Value}"));
}
