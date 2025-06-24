namespace GqlPlus.Structures;

public class StructuredTests
{
  [Theory, RepeatData]
  public void IsEmpty_Value_IsFalse(string value)
  {
    Structured result = value;

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
    Map<Structured> map = new() { [key] = new(value), };

    Structured result = map.Encode();

    result.IsEmpty.ShouldBeFalse();
  }
  [Fact]
  public void IsEmpty_New_IsTrue()
  {
    Structured result = new((bool?)null);

    result.IsEmpty.ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void IsEmpty_Tagged_IsTrue(string tag)
  {
    Structured result = new((bool?)null, tag);

    result.IsEmpty.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Equals_SameTagValue_IsTrue(string value, string tag)
  {
    Structured result = new(value, tag);

    result.Equals(new(value, tag)).ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void Equals_SameValue_IsTrue(string value)
  {
    Structured result = value;

    result.Equals(new(value)).ShouldBeTrue();
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
    Map<Structured> map = new() { [key] = new(value), };

    Structured result = map.Encode();

    result.Equals(map.Encode()).ShouldBeTrue();
  }
  [Theory, RepeatData]
  public void Equals_ValueAndNull_IsFalse(string value)
  {
    Structured result = value;

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
    Map<Structured> map = new() { [key] = new(value), };

    Structured result = map.Encode();

    result.Equals(null).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_TagDiff_IsFalse(string value, string tag1, string tag2)
  {
    this.SkipIf(tag1 == tag2);

    Structured result1 = new(value, tag1);
    Structured result2 = new(value, tag2);

    result1.Equals(result2).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_ValueDiff_IsFalse(string value1, string value2)
  {
    this.SkipIf(value1 == value2);

    Structured result1 = value1;
    Structured result2 = value2;

    result1.Equals(result2).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_ListDiff_IsFalse(string value1, string value2)
  {
    this.SkipIf(value1 == value2);

    string[] list1 = [value1];
    string[] list2 = [value2];

    Structured result = list1.Encode();

    result.Equals(list2.Encode()).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_MapDiffKey_IsFalse(string key1, string value1, string key2)
  {
    this.SkipIf(key1 == key2);

    Map<Structured> map1 = new() { [key1] = new(value1), };
    Map<Structured> map2 = new() { [key2] = new(value1), };

    Structured result = map1.Encode();

    result.Equals(map2.Encode()).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_MapDiffValue_IsFalse(string key1, string value1, string value2)
  {
    this.SkipIf(value1 == value2);

    Map<Structured> map1 = new() { [key1] = new(value1), };
    Map<Structured> map2 = new() { [key1] = new(value2), };

    Structured result = map1.Encode();

    result.Equals(map2.Encode()).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_MapDiffBoth_IsFalse(string key1, string value1, string key2, string value2)
  {
    this.SkipIf(value1 == value2);

    Map<Structured> map1 = new() { [key1] = new(value1), };
    Map<Structured> map2 = new() { [key2] = new(value2), };

    Structured result = map1.Encode();

    result.Equals(map2.Encode()).ShouldBeFalse();
  }
  [Fact]
  public void Equals_New_IsFalse()
  {
    Structured result = new((bool?)null);

    result.Equals(new((bool?)null)).ShouldBeFalse();
  }
  [Theory, RepeatData]
  public void Equals_Tagged_IsFalse(string tag)
  {
    Structured result = new((bool?)null, tag);

    result.Equals(new((bool?)null)).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void GetHashCode_Value_IsCorrect(string value)
  {
    Structured result = value;

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
    Structured result = new Map<Structured>() {
      [key] = new(value),
    }.Encode();

    result.GetHashCode().ShouldNotBe(0);
  }
  [Fact]
  public void GetHashCode_New_IsCorrect()
  {
    Structured result = new((bool?)null);

    result.GetHashCode().ShouldNotBe(0);
  }
  [Theory, RepeatData]
  public void GetHashCode_Tagged_IsCorrect(string tag)
  {
    Structured result = new((bool?)null, tag);

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

    value.Add(key, new StructureValue(identifier));

    CheckMap(value, key, new(identifier));

  }

  [Theory, RepeatData]
  public void Add_Text_IsCorrect(string key, string text)
  {
    Structured value = new Map<Structured>().Encode();

    value.Add(key, text);

    CheckMap(value, key, new(text));

  }

  [Theory, RepeatData]
  public void Add_Boolean_IsCorrect(string key, bool check)
  {
    Structured value = new Map<Structured>().Encode();

    value.Add(key, check);

    CheckMap(value, key, new(check));
  }

  [Theory, RepeatData]
  public void Add_Number_IsCorrect(string key, decimal number)
  {
    Structured value = new Map<Structured>().Encode();

    value.Add(key, number);

    CheckMap(value, key, new(number));
  }

  [Theory, RepeatData]
  public void AddBool_IsCorrect(string key, bool check)
  {
    Structured value = new Map<Structured>().Encode();

    value.AddBool(key, check);

    if (check) {
      value.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(key)]),
        m => m.Values.ShouldBe([new(check)]));
    } else {
      value.IsEmpty.ShouldBeTrue();
    }
  }

  [Theory, RepeatData]
  public void AddEnum_IsCorrect(string key, EnumForTesting check)
  {
    Structured value = new Map<Structured>().Encode();

    value.AddEnum(key, check);

    CheckMap(value, key, new(check.ToString(), "_EnumForTesting"));
  }

  [Theory, RepeatData]
  public void AddIfBoth_IsCorrect(string key, string value, bool check)
  {
    Structured result = new Map<Structured>().Encode();

    result.AddIf(check, r => r.Add(key, value), r => r.Add(value, key));

    if (check) {
      result.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(key)]),
        m => m.Values.ShouldBe([new(value)]));
    } else {
      result.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(value)]),
        m => m.Values.ShouldBe([new(key)]));
    }
  }

  [Theory, RepeatData]
  public void AddIfFalse_IsCorrect(string key, string value, bool check)
  {
    Structured result = new Map<Structured>().Encode();

    result.AddIf(check, onFalse: r => r.Add(value, key));

    if (check) {
      result.Map.ShouldBeEmpty();
    } else {
      result.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(value)]),
        m => m.Values.ShouldBe([new(key)]));
    }
  }

  [Theory, RepeatData]
  public void AddIfTrue_IsCorrect(string key, string value, bool check)
  {
    Structured result = new Map<Structured>().Encode();

    result.AddIf(check, r => r.Add(key, value));

    if (check) {
      result.Map.ShouldSatisfyAllConditions(
        m => m.Keys.ShouldBe([new StructureValue(key)]),
        m => m.Values.ShouldBe([new(value)]));
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

    CheckMap(result, key, values.ToMap(k => k, v => new Structured(v)).Encode("_Map"));
  }

  [Theory, RepeatData]
  public void AddEncoded_IsCorrect(string key, string value)
  {
    Structured result = new Map<Structured>().Encode();
    Map<string> map = new() { [key] = value };

    result.AddEncoded(key, map, new EncodeMap());

    CheckMap(result, key, map.Encode(s => new(s)));
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
    Map<string> flags = check.FlagNames().ToMap(k => k, v => "_");

    value.AddSet(key, check);

    CheckMap(value, key, flags.Encode(f => new(f), "_Set(_FlagsForTesting)"));
  }

  [Theory, RepeatData]
  public void AddSet_WithTagFlags_IsCorrect(string key, FlagsForTesting check, string tag)
  {
    Structured value = new Map<Structured>().Encode();
    Map<string> flags = check.FlagNames().ToMap(k => k, v => "_");

    value.AddSet(key, check, tag);

    CheckMap(value, key, flags.Encode(f => new(f), $"_Set({tag})"));
  }

  [Theory, RepeatData]
  public void IncludeEncoded_IsCorrect(string key, string value)
  {
    Structured result = new Map<Structured>().Encode();
    Map<string> map = new() { [key] = value };

    result.IncludeEncoded(map, new EncodeMap());

    CheckMap(result, key, new Structured(value));
  }

  [Fact]
  public void IncludeEncodedNull_IsCorrect()
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
