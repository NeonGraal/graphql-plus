namespace GqlPlus.Structures;

public class GqlpValueHelperTests
{
  [Theory, RepeatData]
  public void Encode_NullableBoolean_ReturnsScalarOrNull(bool value)
  {
    IGqlpValue? encoded = ((bool?)value).Encode("Tag");

    GqlpScalar scalar = encoded.ShouldBeOfType<GqlpScalar>();
    scalar.Kind.ShouldBe(GqlpScalarKind.Boolean);
    scalar.Boolean.ShouldBe(value);
    scalar.Tag.ShouldBe("Tag");
    ((bool?)null).Encode().ShouldBeNull();
  }

  [Theory, RepeatData]
  public void Encode_NullableNumber_ReturnsScalarOrNull(decimal value)
  {
    IGqlpValue? encoded = ((decimal?)value).Encode("Tag");

    GqlpScalar scalar = encoded.ShouldBeOfType<GqlpScalar>();
    scalar.Kind.ShouldBe(GqlpScalarKind.Number);
    scalar.Number.ShouldBe(value);
    scalar.Tag.ShouldBe("Tag");
    ((decimal?)null).Encode().ShouldBeNull();
  }

  [Theory, RepeatData]
  public void Encode_NullableInteger_ReturnsScalarOrNull(int value)
  {
    IGqlpValue? encoded = ((int?)value).Encode("Tag");

    GqlpScalar scalar = encoded.ShouldBeOfType<GqlpScalar>();
    scalar.Kind.ShouldBe(GqlpScalarKind.Number);
    scalar.Number.ShouldBe(value);
    scalar.Tag.ShouldBe("Tag");
    ((int?)null).Encode().ShouldBeNull();
  }

  [Theory, RepeatData]
  public void Encode_String_ReturnsScalarWithIdentifierKind(string value)
  {
    IGqlpValue encoded = value.Encode("Tag");

    GqlpScalar scalar = encoded.ShouldBeOfType<GqlpScalar>();
    scalar.Kind.ShouldBe(value.IsIdentifier() ? GqlpScalarKind.Identifier : GqlpScalarKind.Text);
    scalar.Text.ShouldBe(value);
    scalar.Tag.ShouldBe("Tag");
  }

  [Theory, RepeatData]
  public void Encode_Boolean_ReturnsScalar(bool value)
  {
    IGqlpValue encoded = value.Encode("Tag");

    GqlpScalar scalar = encoded.ShouldBeOfType<GqlpScalar>();
    scalar.Kind.ShouldBe(GqlpScalarKind.Boolean);
    scalar.Boolean.ShouldBe(value);
    scalar.Tag.ShouldBe("Tag");
  }

  [Theory, RepeatData]
  public void Encode_Number_ReturnsScalar(decimal value)
  {
    IGqlpValue encoded = value.Encode("Tag");

    GqlpScalar scalar = encoded.ShouldBeOfType<GqlpScalar>();
    scalar.Kind.ShouldBe(GqlpScalarKind.Number);
    scalar.Number.ShouldBe(value);
    scalar.Tag.ShouldBe("Tag");
  }

  [Theory, RepeatData]
  public void Encode_Integer_ReturnsNumberScalar(int value)
  {
    IGqlpValue encoded = value.Encode("Tag");

    GqlpScalar scalar = encoded.ShouldBeOfType<GqlpScalar>();
    scalar.Kind.ShouldBe(GqlpScalarKind.Number);
    scalar.Number.ShouldBe(value);
    scalar.Tag.ShouldBe("Tag");
  }

  [Fact]
  public void Encode_SequenceWithMapper_ReturnsMappedList()
  {
    List<string> values = ["first", "second"];
    IGqlpValue encoded = values.Encode(value => value.Encode(), "Tag", flow: true);

    GqlpList list = encoded.ShouldBeOfType<GqlpList>();
    list.Tag.ShouldBe("Tag");
    list.Flow.ShouldBeTrue();
    list.Items.Select(item => item.ShouldBeOfType<GqlpScalar>().Text)
      .ShouldBe(["first", "second"]);
  }

  [Fact]
  public void Encode_EnumSequence_ReturnsTaggedList()
  {
    IGqlpValue encoded = new[] { TestKind.First, TestKind.Second }.Encode(flow: true);

    GqlpList list = encoded.ShouldBeOfType<GqlpList>();
    list.Tag.ShouldBeEmpty();
    list.Flow.ShouldBeTrue();
    list.Items.Select(item => item.ShouldBeOfType<GqlpScalar>().Tag)
      .ShouldBe(["_TestKind", "_TestKind"]);
    list.Items.Select(item => item.ToString())
      .ShouldBe(["First", "Second"]);
  }

  [Fact]
  public void Encode_StringSequence_ReturnsTaggedList()
  {
    List<string> values = ["first", "not an identifier"];
    IGqlpValue encoded = values.Encode("Strings", flow: true);

    GqlpList list = encoded.ShouldBeOfType<GqlpList>();
    list.Tag.ShouldBe("Strings");
    list.Flow.ShouldBeTrue();
    list.Items.Select(item => item.ShouldBeOfType<GqlpScalar>().Kind)
      .ShouldBe([GqlpScalarKind.Identifier, GqlpScalarKind.Text]);
  }

  [Fact]
  public void Encode_MapWithMapper_ReturnsSortedMappedMap()
  {
    Map<string> groups = new() {
      ["second"] = "2",
      ["first"] = "1",
    };

    IGqlpValue encoded = groups.Encode(value => value.Encode(), "Map", "Key", flow: true);

    GqlpMap map = encoded.ShouldBeOfType<GqlpMap>();
    map.Tag.ShouldBe("Map");
    map.Flow.ShouldBeTrue();
    map.Entries.Keys.Select(key => key.Text).ShouldBe(["first", "second"]);
    map.Entries[new GqlpScalar("first", "Key", isIdentifier: true)]
      .ShouldBeOfType<GqlpScalar>().Text.ShouldBe("1");
    map.Entries[new GqlpScalar("second", "Key", isIdentifier: true)]
      .ShouldBeOfType<GqlpScalar>().Text.ShouldBe("2");
  }

  [Fact]
  public void Encode_ValueMap_ReturnsMapWithSameValues()
  {
    Map<IGqlpValue> groups = new() {
      ["name"] = "value".Encode(),
    };

    IGqlpValue encoded = groups.Encode("Map", "Key");

    GqlpMap map = encoded.ShouldBeOfType<GqlpMap>();
    map.Tag.ShouldBe("Map");
    map.Entries[new GqlpScalar("name", "Key", isIdentifier: true)]
      .ShouldBeSameAs(groups["name"]);
  }

  [Fact]
  public void Encode_Messages_ReturnsTaggedListOfErrorMaps()
  {
    IMessages messages = new Messages("problem".Error());

    IGqlpValue encoded = messages.Encode();

    GqlpList errors = encoded.ShouldBeOfType<GqlpList>();
    errors.Tag.ShouldBe("_Errors");
    GqlpMap error = errors.Items.Single()
      .ShouldBeOfType<GqlpMap>();
    error.Entries[new GqlpScalar("_message", isIdentifier: true)]
      .ShouldBeOfType<GqlpScalar>().Text.ShouldBe("problem");
  }

  [Fact]
  public void EncodeEnum_DefaultTag_UsesEnumTypeTag()
  {
    IGqlpValue encoded = TestKind.First.EncodeEnum();

    encoded.ShouldBe(new GqlpScalar("First", "_TestKind", isIdentifier: true));
  }

  [Fact]
  public void EncodeEnum_ExplicitTag_UsesProvidedTag()
  {
    IGqlpValue encoded = TestKind.Second.EncodeEnum("Custom");

    encoded.ShouldBe(new GqlpScalar("Second", "Custom", isIdentifier: true));
  }

  private enum TestKind
  {
    First,
    Second,
  }
}
