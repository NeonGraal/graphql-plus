namespace GqlPlus.Structures;

public class StructuredTests
{
  [Theory, RepeatData]
  public void IsEmpty_Value_IsFalse(string value)
  {
    Structured result = value.Encode();

    result.IsEmpty.ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void IsEmpty_List_IsFalse(string value)
  {
    string[] list = [value];

    Structured result = list.Encode();

    result.IsEmpty.ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void IsEmpty_Map_IsFalse(string key, string value)
  {
    Map<Structured> map = new() { [key] = value.Encode(), };

    Structured result = map.Encode();

    result.IsEmpty.ShouldBeFalse();
  }
  [Fact]
  public void IsEmpty_New_IsTrue()
  {
    Structured result = Structured.Empty();

    result.IsEmpty.ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void IsEmpty_Tagged_IsTrue(string tag)
  {
    Structured result = Structured.Empty(tag);

    result.IsEmpty.ShouldBeTrue();
  }

  [Fact]
  public void Equals_Empty_IsTrue()
  {
    Structured result = Structured.Empty();

    result.Equals(Structured.Empty()).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_SameTagEmpty_IsTrue(string tag)
  {
    Structured result = Structured.Empty(tag);

    result.Equals(Structured.Empty(tag)).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_SameTagEmptyValue_IsTrue(string tag)
  {
    Structured result = Structured.Empty(tag);

    result.Equals(Structured.Empty(tag)).ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_SameTagValue_IsTrue(string value, string tag)
  {
    Structured result = value.Encode(tag);

    result.Equals(value.Encode(tag)).ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void Equals_SameValue_IsTrue(string value)
  {
    Structured result = value.Encode();

    result.Equals(value.Encode()).ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void Equals_SameList_IsTrue(string value)
  {
    string[] list = [value];

    Structured result = list.Encode();

    result.Equals(list.Encode()).ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void Equals_SameMap_IsTrue(string key, string value)
  {
    Map<Structured> map = new() { [key] = value.Encode(), };

    Structured result = map.Encode();

    result.Equals(map.Encode()).ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void Equals_ValueAndNull_IsFalse(string value)
  {
    Structured result = value.Encode();

    result.Equals(null).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_ListAndNull_IsFalse(string value)
  {
    string[] list = [value];

    Structured result = list.Encode();

    result.Equals(null).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_MapAndNull_IsFalse(string key, string value)
  {
    Map<Structured> map = new() { [key] = value.Encode(), };

    Structured result = map.Encode();

    result.Equals(null).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_TagDiff_IsFalse(string value, string tag1, string tag2)
  {
    this.SkipEqual(tag1, tag2);

    Structured result1 = value.Encode(tag1);
    Structured result2 = value.Encode(tag2);

    result1.Equals(result2).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_ValueDiff_IsFalse(string value1, string value2)
  {
    this.SkipEqual(value1, value2);

    Structured result1 = value1.Encode();
    Structured result2 = value2.Encode();

    result1.Equals(result2).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_ListDiff_IsFalse(string value1, string value2)
  {
    this.SkipEqual(value1, value2);

    string[] list1 = [value1];
    string[] list2 = [value2];

    Structured result = list1.Encode();

    result.Equals(list2.Encode()).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_ListDiffOrder_IsFalse(string value1, string value2)
  {
    this.SkipEqual(value1, value2);

    string[] list1 = [value1, value2];
    string[] list2 = [value2, value1];

    Structured result = list1.Encode();

    result.Equals(list2.Encode()).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_MapDiffKey_IsFalse(string key1, string value1, string key2)
  {
    this.SkipEqual(key1, key2);

    Map<Structured> map1 = new() { [key1] = value1.Encode(), };
    Map<Structured> map2 = new() { [key2] = value1.Encode(), };

    Structured result = map1.Encode();

    result.Equals(map2.Encode()).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_MapDiffValue_IsFalse(string key1, string value1, string value2)
  {
    this.SkipEqual(value1, value2);

    Map<Structured> map1 = new() { [key1] = value1.Encode(), };
    Map<Structured> map2 = new() { [key1] = value2.Encode(), };

    Structured result = map1.Encode();

    result.Equals(map2.Encode()).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_MapDiffBoth_IsFalse(string key1, string value1, string key2, string value2)
  {
    this.SkipEqual(value1, value2);

    Map<Structured> map1 = new() { [key1] = value1.Encode(), };
    Map<Structured> map2 = new() { [key2] = value2.Encode(), };

    Structured result = map1.Encode();

    result.Equals(map2.Encode()).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_MapSameValue_IsTrue(string key1, string value1, string key2)
  {
    this.SkipEqual(key1, key2);

    Map<Structured> map1 = new() { [key1] = value1.Encode(), [key2] = value1.Encode(), };
    Map<Structured> map2 = new() { [key2] = value1.Encode(), [key1] = value1.Encode(), };

    Structured result = map1.Encode();

    result.Equals(map2.Encode()).ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void Equals_MapSameBoth_IsTrue(string key1, string value1, string key2, string value2)
  {
    this.SkipEqual(key1, key2);

    Map<Structured> map1 = new() { [key1] = value1.Encode(), [key2] = value2.Encode(), };
    Map<Structured> map2 = new() { [key2] = value2.Encode(), [key1] = value1.Encode(), };

    Structured result = map1.Encode();

    result.Equals(map2.Encode()).ShouldBeTrue();
  }
  [Fact]
  public void Equals_New_IsTrue()
  {
    Structured result = Structured.Empty();

    result.Equals(Structured.Empty()).ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void Equals_Tagged_IsFalse(string tag)
  {
    Structured result = Structured.Empty(tag);

    result.Equals(Structured.Empty()).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void GetHashCode_Value_IsCorrect(string value)
  {
    Structured result = value.Encode();

    result.GetHashCode().ShouldNotBe(0);
  }
  [Theory, RepeatData]
  public void GetHashCode_List_IsCorrect(string value)
  {
    Structured result = new[] { value }.Encode();

    result.GetHashCode().ShouldNotBe(0);
  }
  [Theory, RepeatData]
  public void GetHashCode_Map_IsCorrect(string key, string value)
  {
    Structured result = key.MapWith(value.Encode()).Encode();

    result.GetHashCode().ShouldNotBe(0);
  }
  [Fact]
  public void GetHashCode_New_IsCorrect()
  {
    Structured result = Structured.Empty();

    result.GetHashCode().ShouldNotBe(0);
  }
  [Theory, RepeatData]
  public void GetHashCode_Tagged_IsCorrect(string tag)
  {
    Structured result = Structured.Empty(tag);

    result.GetHashCode().ShouldNotBe(0);
  }

  [Theory, RepeatData]
  public void Add_Null_IsCorrect(string key)
  {
    Structured value = new Map<Structured>().Encode();

    value.Add(key, null);

    value.Map.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Add_StructureValue_IsCorrect(string key, string identifier)
  {
    Structured value = new Map<Structured>().Encode();

    value.Add(key, new(new StructureValue(identifier)));

    CheckMap(value, key, identifier.Encode());

  }

  [Theory, RepeatData]
  public void Add_Text_IsCorrect(string key, string text)
  {
    Structured value = new Map<Structured>().Encode();

    value.Add(key, text.Encode());

    CheckMap(value, key, text.Encode());

  }

  [Theory, RepeatData]
  public void Add_Boolean_IsCorrect(string key, bool check)
  {
    Structured value = new Map<Structured>().Encode();

    value.Add(key, check.Encode());

    CheckMap(value, key, check.Encode());
  }

  [Theory, RepeatData]
  public void Add_Number_IsCorrect(string key, decimal number)
  {
    Structured value = new Map<Structured>().Encode();

    value.Add(key, number.Encode());

    CheckMap(value, key, number.Encode());
  }

  [Theory, RepeatData]
  public void AddBool_IsCorrect(string key, bool check)
  {
    Structured value = new Map<Structured>().Encode();

    value.AddBool(key, check);

    if (check) {
      value.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(key)]),
        m => m.Values.ShouldBe([check.Encode()]));
    } else {
      value.IsEmpty.ShouldBeTrue();
    }
  }

  [Theory, RepeatData]
  public void AddEnum_IsCorrect(string key, EnumForTesting check)
  {
    Structured value = new Map<Structured>().Encode();

    value.AddEnum(key, check);

    CheckMap(value, key, check.ToString().Encode("_EnumForTesting"));
  }

  [Theory, RepeatData]
  public void AddIfBoth_IsCorrect(string key, string value, bool check)
  {
    Structured result = new Map<Structured>().Encode();

    result.AddIf(check, r => r.Add(key, value.Encode()), r => r.Add(value, key.Encode()));

    if (check) {
      result.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(key)]),
        m => m.Values.ShouldBe([value.Encode()]));
    } else {
      result.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(value)]),
        m => m.Values.ShouldBe([key.Encode()]));
    }
  }

  [Theory, RepeatData]
  public void AddIfFalse_IsCorrect(string key, string value, bool check)
  {
    Structured result = new Map<Structured>().Encode();

    result.AddIf(check, onFalse: r => r.Add(value, key.Encode()));

    if (check) {
      result.Map.ShouldBeEmpty();
    } else {
      result.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(value)]),
        m => m.Values.ShouldBe([key.Encode()]));
    }
  }

  [Theory, RepeatData]
  public void AddIfTrue_IsCorrect(string key, string value, bool check)
  {
    Structured result = new Map<Structured>().Encode();

    result.AddIf(check, r => r.Add(key, value.Encode()));

    if (check) {
      result.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(key)]),
        m => m.Values.ShouldBe([value.Encode()]));
    } else {
      result.Map.ShouldBeEmpty();
    }
  }

  [Theory, RepeatData]
  public void AddList_IsCorrect(string key, string[] values)
  {
    Structured result = new Map<Structured>().Encode();

    result.AddList(key, values, new EncodeString());

    CheckMap(result, key, values.Encode());
  }

  [Theory, RepeatData]
  public void AddMap_IsCorrect(string key, string[] values)
  {
    Structured result = new Map<Structured>().Encode();

    result.AddMap(key, values.ToMap(k => k), new EncodeString(), "", keyTag: "");

    CheckMap(result, key, values.ToMap(k => k, v => v.Encode()).Encode());
  }

  [Theory, RepeatData]
  public void AddEncoded_IsCorrect(string key, string value)
  {
    Structured result = new Map<Structured>().Encode();
    Map<string> map = key.MapWith(value);

    result.AddEncoded(key, map, new EncodeMap());

    CheckMap(result, key, map.Encode(s => s.Encode()));
  }

  [Theory, RepeatData]
  public void AddEncodedNull_IsCorrect(string key)
  {
    Structured result = new Map<Structured>().Encode();

    result.AddEncoded(key, null, new EncodeMap());

    result.Map.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void AddSet_WithEnum_IsEmpty(string key, EnumForTesting check)
  {
    Structured value = new Map<Structured>().Encode();

    value.AddSet(key, check);

    value.IsEmpty.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void AddSet_WithFlags_IsCorrect(string key, FlagsForTesting check)
  {
    Structured value = new Map<Structured>().Encode();
    Map<string> flags = check.FlagNames().ToMap(k => k, v => BuiltIn.UnitValue);

    value.AddSet(key, check);

    CheckMap(value, key, flags.Encode(f => f.Encode(), "_Set(_FlagsForTesting)"));
  }

  [Theory, RepeatData]
  public void AddSet_WithTagFlags_IsCorrect(string key, FlagsForTesting check, string tag)
  {
    Structured value = new Map<Structured>().Encode();
    Map<string> flags = check.FlagNames().ToMap(k => k, v => BuiltIn.UnitValue);

    value.AddSet(key, check, tag);

    CheckMap(value, key, flags.Encode(f => f.Encode(), $"_Set({tag})"));
  }

  [Theory, RepeatData]
  public void IncludeEncoded_IsCorrect(string key, string value)
  {
    Structured result = new Map<Structured>().Encode();
    Map<string> map = key.MapWith(value);

    result.IncludeEncoded(map, new EncodeMap());

    CheckMap(result, key, value.Encode());
  }

  [Fact]
  public void IncludeEncoded_WithNullMap_ResultRemainsEmpty()
  {
    Structured result = new Map<Structured>().Encode();
    Map<string>? map = null;

    result.IncludeEncoded(map, new EncodeMap());

    result.IsEmpty.ShouldBeTrue();
  }

  private static void CheckMap(Structured result, string key, Structured value)
  {
    result.Map.ShouldSatisfyAllConditions(
      m => m.Keys.ShouldBe([new StructureValue(key)]),
      m => m.Values.ShouldBe([value]));
  }
}

public enum EnumForTesting { Value1, Value2, Third, Fourth, Last }

[Flags]
public enum FlagsForTesting { None, Flag1, Flag2, Third, Fourth, Some, More, Most, Last, All = 15 }
