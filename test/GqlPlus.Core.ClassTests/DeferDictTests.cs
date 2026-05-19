namespace GqlPlus;

public class DeferDictTests
{
  [Theory, RepeatData]
  public void Keys_WhenAccessed_ReturnsFactoryKeys(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> dict = distinct.ToMap(v => v);
    DeferDict<string, string> defer = new(() => dict);

    IEnumerable<string> result = defer.Keys;

    result.ShouldBe(distinct.Order(), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void Values_WhenAccessed_ReturnsFactoryValues(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> dict = distinct.ToMap(v => v);
    DeferDict<string, string> defer = new(() => dict);

    IEnumerable<string> result = defer.Values;

    result.ShouldBe(distinct, ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void Count_WhenAccessed_ReturnsFactoryCount(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> dict = distinct.ToMap(v => v);
    DeferDict<string, string> defer = new(() => dict);

    int result = defer.Count;

    result.ShouldBe(distinct.Length);
  }

  [Theory, RepeatData]
  public void Indexer_GivenExistingKey_ReturnsCorrectValue(string key)
  {
    Map<string> dict = new() { { key, key } };
    DeferDict<string, string> defer = new(() => dict);

    string result = defer[key];

    result.ShouldBe(key);
  }

  [Theory, RepeatData]
  public void ContainsKey_WhenKeyExists_ReturnsTrue(string key)
  {
    Map<string> dict = new() { { key, key } };
    DeferDict<string, string> defer = new(() => dict);

    bool result = defer.ContainsKey(key);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void ContainsKey_WhenKeyMissing_ReturnsFalse(string key)
  {
    Map<string> dict = [];
    DeferDict<string, string> defer = new(() => dict);

    bool result = defer.ContainsKey(key);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void TryGetValue_WhenKeyExists_ReturnsTrueAndValue(string key)
  {
    Map<string> dict = new() { { key, key } };
    DeferDict<string, string> defer = new(() => dict);

    bool result = defer.TryGetValue(key, out string value);

    result.ShouldBeTrue();
    value.ShouldBe(key);
  }

  [Theory, RepeatData]
  public void TryGetValue_WhenKeyMissing_ReturnsFalse(string key)
  {
    Map<string> dict = [];
    DeferDict<string, string> defer = new(() => dict);

    bool result = defer.TryGetValue(key, out string _);

    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void GetEnumerator_WhenIterated_ReturnsKeyValuePairs(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> dict = distinct.ToMap(v => v);
    DeferDict<string, string> defer = new(() => dict);

    IEnumerable<KeyValuePair<string, string>> result = defer;

    result.Select(kv => kv.Key).ShouldBe(distinct.Order(), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void GetEnumerator_NonGeneric_WhenIterated_ReturnsKeyValuePairs(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    Map<string> dict = distinct.ToMap(v => v);
    DeferDict<string, string> defer = new(() => dict);

    System.Collections.IEnumerable enumerable = defer;

    foreach (object item in enumerable) {
      item.ShouldBeOfType<KeyValuePair<string, string>>()
        .Key.ShouldBeOneOf(distinct);
    }
  }
}
