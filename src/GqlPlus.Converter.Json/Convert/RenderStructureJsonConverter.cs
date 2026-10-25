namespace GqlPlus.Convert;

internal sealed class RenderStructureJsonConverter
  : RenderJsonConverter<IGqlpValue>
{
  public override IGqlpValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    => new ReadJson().ReadStructured(ref reader).Result;
  public override void Write(Utf8JsonWriter writer, IGqlpValue value, JsonSerializerOptions options)
    => WriteValueNode(writer, value, "");

  private void WriteValueNode(Utf8JsonWriter writer, IGqlpValue value, string keyTag)
  {
    switch (value) {
      case IGqlpScalar scalar:
        base.WriteValueTagged(writer, scalar, keyTag);
        break;
      case GqlpList list:
        WriteList(writer, list, keyTag);
        break;
      case GqlpMap map:
        WriteMap(writer, map, keyTag);
        break;
      case GqlpNull:
      case GqlpVoid:
        writer.WriteNullValue();
        break;
      case GqlpUnit unit:
        base.WriteValueTagged(writer, new GqlpScalar("", unit.Tag), keyTag);
        break;
    }
  }

  private void WriteMap(Utf8JsonWriter writer, GqlpMap map, string keyTag)
  {
    KeyValuePair<IGqlpScalar, IGqlpValue> first = map.Entries.FirstOrDefault();
    if (map.Entries.Count == 1 && !string.IsNullOrWhiteSpace(map.Tag)
        && string.IsNullOrWhiteSpace(first.Value.Tag) && first.Value is IGqlpScalar) {
      writer.WriteStartObject();
      WriteTag(writer, keyTag, "keyTag");
      WriteTag(writer, map.Tag, "mapTag");
      writer.WritePropertyName(ScalarText(first.Key));
      WriteValueNode(writer, first.Value, first.Key.Tag);
      writer.WriteEndObject();
      return;
    }

    writer.WriteStartObject();
    WriteTag(writer, keyTag, "keyTag");
    WriteTag(writer, map.Tag, "mapTag");
    foreach (KeyValuePair<IGqlpScalar, IGqlpValue> entry in map.Entries.OrderBy(kv => ScalarText(kv.Key), StringComparer.Ordinal)) {
      writer.WritePropertyName(ScalarText(entry.Key));
      WriteValueNode(writer, entry.Value, entry.Key.Tag);
    }

    writer.WriteEndObject();
  }

  private void WriteList(Utf8JsonWriter writer, GqlpList list, string keyTag)
  {
    if (string.IsNullOrWhiteSpace(list.Tag) && string.IsNullOrWhiteSpace(keyTag)) {
      WriteItems();
      return;
    }

    writer.WriteStartObject();
    WriteTag(writer, keyTag, "keyTag");
    writer.WritePropertyName("$list");
    WriteItems();
    WriteTag(writer, list.Tag, "listTag");
    writer.WriteEndObject();

    void WriteItems()
    {
      if (list.Items.All(item => item is IGqlpScalar)) {
        string json = JsonSerializer.Serialize(list.Items, RenderJson.Unindented);
        writer.WriteRawValue(json.Replace(",", ", "));
        return;
      }

      writer.WriteStartArray();
      foreach (IGqlpValue item in list.Items) {
        WriteValueNode(writer, item, "");
      }

      writer.WriteEndArray();
    }
  }

  private static string ScalarText(IGqlpScalar scalar)
    => scalar.Kind switch {
      GqlpScalarKind.Boolean => scalar.BooleanValue!.Value.TrueFalse(),
      GqlpScalarKind.Number => $"{scalar.Number:0.#####}",
      _ => scalar.Text ?? "",
    };
}
