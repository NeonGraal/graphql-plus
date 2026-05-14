namespace GqlPlus;

public class DeferMapTests
{
  [Theory, RepeatData]
  public void Keys_WhenAccessed_ReturnsFactoryKeys(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> map = distinct.ToMap(v => v);
    DeferMap<string> defer = new(() => map);

    IEnumerable<string> result = defer.Keys;

    result.ShouldBe(distinct.Order(), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void Values_WhenAccessed_ReturnsFactoryValues(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> map = distinct.ToMap(v => v);
    DeferMap<string> defer = new(() => map);

    IEnumerable<string> result = defer.Values;

    result.ShouldBe(distinct, ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void Count_WhenAccessed_ReturnsFactoryCount(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> map = distinct.ToMap(v => v);
    DeferMap<string> defer = new(() => map);

    int result = defer.Count;

    result.ShouldBe(distinct.Length);
  }

  [Theory, RepeatData]
  public void Indexer_GivenExistingKey_ReturnsCorrectValue(string key)
  {
    Map<string> map = new() { { key, key } };
    DeferMap<string> defer = new(() => map);

    string result = defer[key];

    result.ShouldBe(key);
  }

  [Theory, RepeatData]
  public void GetValueOr_WhenKeyExists_ReturnsValue(string key)
  {
    Map<string> map = new() { { key, key } };
    DeferMap<string> defer = new(() => map);

    string? result = defer.GetValueOr(key);

    result.ShouldBe(key);
  }

  [Theory, RepeatData]
  public void GetValueOr_WhenKeyMissing_ReturnsNull(string key)
  {
    Map<string> map = [];
    DeferMap<string> defer = new(() => map);

    string? result = defer.GetValueOr(key);

    result.ShouldBeNull();
  }

  [Theory, RepeatData]
  public void ContainsKey_WhenKeyExists_ReturnsTrue(string key)
  {
    Map<string> map = new() { { key, key } };
    DeferMap<string> defer = new(() => map);

    bool result = defer.ContainsKey(key);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void ContainsKey_WhenKeyMissing_ReturnsFalse(string key)
  {
    Map<string> map = [];
    DeferMap<string> defer = new(() => map);

    bool result = defer.ContainsKey(key);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void TryGetValue_WhenKeyExists_ReturnsTrueAndValue(string key)
  {
    Map<string> map = new() { { key, key } };
    DeferMap<string> defer = new(() => map);

    bool result = defer.TryGetValue(key, out string value);

    result.ShouldBeTrue();
    value.ShouldBe(key);
  }

  [Theory, RepeatData]
  public void TryGetValue_WhenKeyMissing_ReturnsFalse(string key)
  {
    Map<string> map = [];
    DeferMap<string> defer = new(() => map);

    bool result = defer.TryGetValue(key, out string _);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void GetEnumerator_WhenIterated_ReturnsKeyValuePairs(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> map = distinct.ToMap(v => v);
    DeferMap<string> defer = new(() => map);

    IEnumerable<KeyValuePair<string, string>> result = defer;

    result.Select(kv => kv.Key).ShouldBe(distinct.Order(), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void GetEnumerator_NonGeneric_WhenIterated_ReturnsKeyValuePairs(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> map = distinct.ToMap(v => v);
    DeferMap<string> defer = new(() => map);

    System.Collections.IEnumerable enumerable = defer;

    foreach (object item in enumerable) {
      item.ShouldBeOfType<KeyValuePair<string, string>>()
        .Key.ShouldBeOneOf(distinct);
    }
  }
}
