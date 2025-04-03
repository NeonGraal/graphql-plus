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
    Structured result = new[] { value }.Render();

    result.IsEmpty.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void IsEmpty_Map_IsFalse(string key, string value)
  {
    Structured result = new Map<Structured>() {
      [key] = new(value),
    }.Render();

    result.IsEmpty.ShouldBeFalse();
  }

  [Fact]
  public void IsEmpty_New_IsTrue()
  {
    Structured result = new((bool?)null, "Test");

    result.IsEmpty.ShouldBeTrue();
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
    Structured result = new[] { value }.Render();

    result.GetHashCode().ShouldNotBe(0);
  }

  [Theory, RepeatData]
  public void GetHashCode_Map_IsCorrect(string key, string value)
  {
    Structured result = new Map<Structured>() {
      [key] = new(value),
    }.Render();

    result.GetHashCode().ShouldNotBe(0);
  }

  [Fact]
  public void GetHashCode_New_IsCorrect()
  {
    Structured result = new((bool?)null, "Test");

    result.GetHashCode().ShouldNotBe(0);
  }

  [Theory, RepeatData]
  public void Add_Null_IsCorrect(string key)
  {
    Structured value = new Map<Structured>().Render();

    value.Add(key, null);

    value.Map.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Add_StructureValue_IsCorrect(string key, string identifier)
  {
    Structured value = new Map<Structured>().Render();

    value.Add(key, new StructureValue(identifier));

    CheckMap(value, key, new(identifier));

  }

  [Theory, RepeatData]
  public void Add_Text_IsCorrect(string key, string text)
  {
    Structured value = new Map<Structured>().Render();

    value.Add(key, text);

    CheckMap(value, key, new(text));

  }

  [Theory, RepeatData]
  public void Add_Boolean_IsCorrect(string key, bool check)
  {
    Structured value = new Map<Structured>().Render();

    value.Add(key, check);

    CheckMap(value, key, new(check));
  }

  [Theory, RepeatData]
  public void Add_Number_IsCorrect(string key, decimal number)
  {
    Structured value = new Map<Structured>().Render();

    value.Add(key, number);

    CheckMap(value, key, new(number));
  }

  private static void CheckMap(Structured result, string key, Structured value)
  {
    result.Map.ShouldSatisfyAllConditions(
      m => m.Keys.ShouldBe([new StructureValue(key)]),
      m => m.Values.ShouldBe([value]));
  }

  [Theory, RepeatData]
  public void AddBool_IsCorrect(string key, bool check)
  {
    Structured value = new Map<Structured>().Render();

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
    Structured value = new Map<Structured>().Render();

    value.AddEnum(key, check);

    CheckMap(value, key, new(check.ToString(), "_EnumForTesting"));
  }

  [Theory, RepeatData]
  public void AddIfBoth_IsCorrect(string key, string value, bool check)
  {
    Structured result = new Map<Structured>().Render();

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
    Structured result = new Map<Structured>().Render();

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
    Structured result = new Map<Structured>().Render();

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
    Structured result = new Map<Structured>().Render();

    result.AddList(key, values, new RenderString());

    CheckMap(result, key, values.Render());
  }

  [Theory, RepeatData]
  public void AddMap_IsCorrect(string key, string[] values)
  {
    Structured result = new Map<Structured>().Render();

    result.AddMap(key, values.ToMap(k => k), new RenderString(), "", keyTag: "");

    CheckMap(result, key, values.ToMap(k => k, v => new Structured(v)).Render("_Map"));
  }

  [Theory, RepeatData]
  public void AddRendered_IsCorrect(string key, string value)
  {
    Structured result = new Map<Structured>().Render();

    result.AddRendered(key, value, new RenderString());

    CheckMap(result, key, new Structured(value));
  }
}

public enum EnumForTesting { Value1, Value2, Third, Fourth, Last }
