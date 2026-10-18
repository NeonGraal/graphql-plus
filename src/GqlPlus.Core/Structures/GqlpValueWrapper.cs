namespace GqlPlus.Structures;

public static class GqlpValueWrapper
{
  public static IGqlpValue ToGqlpValue(this Structured structured)
  {
    structured.ThrowIfNull();

    string tag = structured.Tag;
    if (structured.List.Count > 0) {
      return new GqlpList(structured.List.Select(ToGqlpValue), tag, structured.Flow);
    }

    if (structured.Map.Count > 0) {
      return new GqlpMap(
        structured.Map.Select(p => new KeyValuePair<string, IGqlpValue>(p.Key.AsString, p.Value.ToGqlpValue())),
        tag,
        structured.Flow);
    }

    StructureValue? value = structured.Value;
    return value switch {
      { Boolean: not null } => new GqlpScalar(value.Boolean.Value, tag),
      { Number: not null } => new GqlpScalar(value.Number.Value, tag),
      { Identifier: not null } => new GqlpScalar(value.Identifier, tag, isIdentifier: true),
      { Text: not null } when !string.IsNullOrEmpty(value.Text) => new GqlpScalar(value.Text, tag),
      _ => EmptyValue(tag),
    };
  }

  public static Structured ToStructured(this IGqlpValue value)
    => value.ThrowIfNull() switch {
      GqlpScalar { Kind: GqlpScalarKind.Boolean } s => new(new StructureValue(s.Boolean, s.Tag)),
      GqlpScalar { Kind: GqlpScalarKind.Number } s => new(new StructureValue(s.Number, s.Tag)),
      GqlpScalar s => new(new StructureValue(s.Text, s.Tag)),
      GqlpList l => new(l.Items.Select(ToStructured), l.Tag, l.Flow),
      GqlpMap m => new(
        m.Entries.ToDictionary(e => new StructureValue(e.Key), e => e.Value.ToStructured()),
        m.Tag,
        m.Flow),
      _ => Structured.Empty(value.Tag),
    };

  private static IGqlpValue EmptyValue(string tag)
    => tag switch {
      "Null" => new GqlpNull(),
      "Void" => new GqlpVoid(),
      _ => new GqlpUnit(tag),
    };
}
