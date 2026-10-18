namespace GqlPlus.Structures;

public static class GqlpValueWrapper
{
  public static IGqlpValue ToGqlpValue(this Structured structured)
  {
    Structured input = structured.ThrowIfNull();

    string tag = input.Tag;
    if (input.List.Count > 0) {
      return new GqlpList(input.List.Select(ToGqlpValue), tag, input.Flow);
    }

    if (input.Map.Count > 0) {
      return new GqlpMap(
        input.Map.Select(p => new KeyValuePair<string, IGqlpValue>(p.Key.AsString, p.Value.ToGqlpValue())),
        tag,
        input.Flow);
    }

    StructureValue? value = input.Value;
    return value switch {
      { Boolean: not null } => new GqlpScalar(value.Boolean.Value, tag),
      { Number: not null } => new GqlpScalar(value.Number.Value, tag),
      { Identifier: not null } => new GqlpScalar(value.Identifier, tag, isIdentifier: true),
      { Text: not null } when !string.IsNullOrEmpty(value.Text) => new GqlpScalar(value.Text, tag),
      _ => EmptyValue(tag),
    };
  }

  public static Structured ToStructured(this IGqlpValue value)
  {
    IGqlpValue input = value.ThrowIfNull();
    return input switch {
      GqlpScalar { Kind: GqlpScalarKind.Boolean } s => new(new StructureValue(s.Boolean, s.Tag)),
      GqlpScalar { Kind: GqlpScalarKind.Number } s => new(new StructureValue(s.Number, s.Tag)),
      GqlpScalar s => new(new StructureValue(s.Text, s.Tag)),
      GqlpList l => new(l.Items.Select(ToStructured), l.Tag, l.Flow),
      GqlpMap m => new(
        m.Entries.ToDictionary(e => new StructureValue(e.Key), e => e.Value.ToStructured()),
        m.Tag,
        m.Flow),
      _ => Structured.Empty(input.Tag),
    };
  }

  private static IGqlpValue EmptyValue(string tag)
    => tag switch {
      "Null" => new GqlpNull(),
      "Void" => new GqlpVoid(),
      _ => new GqlpUnit(tag),
    };
}
