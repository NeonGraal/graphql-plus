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
        input.Map.Select(p => new KeyValuePair<IGqlpScalar, IGqlpValue>(ToGqlpScalar(p.Key), p.Value.ToGqlpValue())),
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
        m.Entries.ToDictionary(e => ToStructureValue(e.Key), e => e.Value.ToStructured()),
        m.Tag,
        m.Flow),
      _ => Structured.Empty(input.Tag),
    };
  }

  private static GqlpScalar ToGqlpScalar(StructureValue value)
    => value switch {
      { Boolean: not null } => new GqlpScalar(value.Boolean.Value, value.Tag),
      { Number: not null } => new GqlpScalar(value.Number.Value, value.Tag),
      { Identifier: not null } => new GqlpScalar(value.Identifier, value.Tag, isIdentifier: true),
      { Text: not null } => new GqlpScalar(value.Text, value.Tag),
      _ => new GqlpScalar("", value.Tag),
    };

  private static StructureValue ToStructureValue(IGqlpScalar value)
    => value.Kind switch {
      GqlpScalarKind.Boolean => new(value.BooleanValue, value.Tag),
      GqlpScalarKind.Number => new(value.Number, value.Tag),
      GqlpScalarKind.Identifier or GqlpScalarKind.Text => new(value.Text, value.Tag),
      _ => StructureValue.Empty(value.Tag),
    };

  private static IGqlpValue EmptyValue(string tag)
    => tag switch {
      "Null" => new GqlpNull(),
      "Void" => new GqlpVoid(),
      _ => new GqlpUnit(tag),
    };
}
