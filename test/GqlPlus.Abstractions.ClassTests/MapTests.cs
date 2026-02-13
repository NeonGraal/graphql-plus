namespace GqlPlus;

public class MapTests
{
  [Theory, RepeatData]
  public void GetValueOrDefault_ReturnsValue_WhenKeyExists(string key)
  {
    // Arrange
    Map<int> map = new() { { key, 1 } };

    // Act
    int result = map.GetValueOrDefault(key, 0);

    // Assert
    result.ShouldBe(1);
  }

  [Theory, RepeatData]
  public void GetValueOrDefault_ReturnsDefaultValue_WhenKeyDoesNotExist(string key)
  {
    // Arrange
    Map<int> map = [];

    // Act
    int result = map.GetValueOrDefault(key, 0);

    // Assert
    result.ShouldBe(0);
  }

  [Theory, RepeatData]
  public void TryAdd_AddsValue_WhenKeyDoesNotExist(string key)
  {
    // Arrange
    Map<int> map = [];

    // Act
    bool result = map.TryAdd(key, 1);

    // Assert
    result.ShouldBeTrue();
    map[key].ShouldBe(1);
  }

  [Theory, RepeatData]
  public void TryAdd_DoesNotAddValue_WhenKeyExists(string key)
  {
    // Arrange
    Map<int> map = new() { { key, 1 } };

    // Act
    bool result = map.TryAdd(key, 2);

    // Assert
    result.ShouldBeFalse();
    map[key].ShouldBe(1);
  }

  [Theory, RepeatData]
  public void Add_AddsMapPair(string key)
  {
    // Arrange
    Map<int> map = [];
    MapPair<int> pair = 1.ToPair(key);

    // Act
    map.Add(pair);

    // Assert
    map[key].ShouldBe(1);
  }

  [Theory, RepeatData]
  public void AddRange_AddsMapPairs(string[] keys)
  {
    // Arrange
    Map<int> map = [];

    // Act
    map.AddRange(keys.Select(k => 1.ToPair(k)));

    // Assert
    map.Keys.Order().ShouldBe(keys.Distinct().Order());
  }

  [Theory, RepeatData]
  public void MapPair_AsKeyValuePair(string key, string value)
  {
    // Arrange
    KeyValuePair<string, string> expected = new(key, value);

    // Act
    MapPair<string> actual = new(key, value);

    // Assert
    actual.ShouldBe<MapPair<string>>(expected);
  }

  [Theory, RepeatData]
  public void KeyValuePair_AsMapPair(string key, string value)
  {
    // Arrange
    MapPair<string> expected = new(key, value);

    // Act
    KeyValuePair<string, string> actual = new(key, value);

    // Assert
    actual.ShouldBe<KeyValuePair<string, string>>(expected);
  }
}
