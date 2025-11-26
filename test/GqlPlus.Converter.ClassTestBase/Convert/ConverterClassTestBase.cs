namespace GqlPlus.Convert;

public abstract class ConverterClassTestBase
{
  [Theory, RepeatData]
  public void WithList_ReturnsCorrect(string[] input)
  {
    // Arrange
    Structured model = input.Encode();

    // Act
    string result = Convert(model);

    // Assert
    WithList_Check(result.ToLines(), input);
  }

  [Theory, RepeatData]
  public void WithListFlow_ReturnsCorrect(string[] input)
  {
    // Arrange
    Structured model = input.Encode(flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithListFlow_Check(result.ToLines(), input);
  }

  [Theory, RepeatData]
  public void WithListMap_ReturnsCorrect(string[] input)
  {
    // Arrange
    Structured model = input.Encode(MakeMap);

    // Act
    string result = Convert(model);

    // Assert
    WithListMap_Check(result.ToLines(), input);
  }

  [Theory, RepeatData]
  public void WithMap_ReturnsCorrect(string key, string value)
  {
    // Arrange
    Map<string> map = new() { [key] = value };
    Structured model = map.Encode(s => new(s));

    // Act
    string result = Convert(model);

    // Assert
    WithMap_Check(result.ToLines(), key, value);
  }

  [Theory, RepeatData]
  public void WithMapFlow_ReturnsCorrect(string key, string value)
  {
    // Arrange
    Map<string> map = new() { [key] = value };
    Structured model = map.Encode(s => new(s), flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithMapFlow_Check(result.ToLines(), key, value);
  }

  [Theory, RepeatData]
  public void WithMapKeys_ReturnsCorrect(string[] keys)
  {
    // Arrange
    Map<string> map = keys.ToMap(k => k);
    Structured model = map.Encode(s => new(s), flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithMapKeys_Check(result.ToLines(), [.. keys.Order(Comparer)]);
  }

  [Theory, RepeatData]
  public void WithMapList_ReturnsCorrect(string key, string[] value)
  {
    // Arrange
    Map<string[]> map = new() { [key] = value };
    Structured model = map.Encode(s => s.Encode(), flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithMapList_Check(result.ToLines(), key, value);
  }

  [Theory, RepeatData]
  public void WithListTag_ReturnsCorrect(string[] input, string tag)
  {
    // Arrange
    Structured model = input.Encode(tag);

    // Act
    string result = Convert(model);

    // Assert
    WithListTag_Check(result.ToLines(), input, tag);
  }

  [Theory, RepeatData]
  public void WithListTagFlow_ReturnsCorrect(string[] input, string tag)
  {
    // Arrange
    Structured model = input.Encode(tag, flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithListTagFlow_Check(result.ToLines(), input, tag);
  }

  [Theory, RepeatData]
  public void WithListTagMap_ReturnsCorrect(string[] input, string tag)
  {
    // Arrange
    Structured model = input.Encode(MakeMap, tag);

    // Act
    string result = Convert(model);

    // Assert
    WithListTagMap_Check(result.ToLines(), input, tag);
  }

  [Theory, RepeatData]
  public void WithMapTag_ReturnsCorrect(string key, string value, string tag)
  {
    // Arrange
    Map<string> map = new() { [key] = value };
    Structured model = map.Encode(s => new(s), tag);

    // Act
    string result = Convert(model);

    // Assert
    WithMapTag_Check(result.ToLines(), key, value, tag);
  }

  [Theory, RepeatData]
  public void WithMapTagFlow_ReturnsCorrect(string key, string value, string tag)
  {
    // Arrange
    Map<string> map = new() { [key] = value };
    Structured model = map.Encode(s => new(s), tag, flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithMapTagFlow_Check(result.ToLines(), key, value, tag);
  }

  [Theory, RepeatData]
  public void WithMapTagKeys_ReturnsCorrect(string[] keys, string tag)
  {
    // Arrange
    Map<string> map = keys.ToMap(k => k);
    Structured model = map.Encode(s => new(s), tag, flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithMapTagKeys_Check(result.ToLines(), [.. keys.Order(Comparer)], tag);
  }

  [Theory, RepeatData]
  public void WithMapTagList_ReturnsCorrect(string key, string[] value, string tag)
  {
    // Arrange
    Map<string[]> map = new() { [key] = value };
    Structured model = map.Encode(s => s.Encode(), tag, flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithMapTagList_Check(result.ToLines(), key, value, tag);
  }

  private static Structured MakeMap(string s)
    => new Map<Structured>() { ["value"] = new(s) }.Encode();

  protected abstract IComparer<string> Comparer { get; }

  protected abstract string Convert(Structured model);

  protected abstract void WithList_Check(string[] result, string[] input);
  protected abstract void WithListFlow_Check(string[] result, string[] input);
  protected abstract void WithListMap_Check(string[] result, string[] input);
  protected abstract void WithMap_Check(string[] result, string key, string value);
  protected abstract void WithMapFlow_Check(string[] result, string key, string value);
  protected abstract void WithMapKeys_Check(string[] result, string[] keys);
  protected abstract void WithMapList_Check(string[] result, string key, string[] value);

  protected abstract void WithListTag_Check(string[] result, string[] input, string tag);
  protected abstract void WithListTagFlow_Check(string[] result, string[] input, string tag);
  protected abstract void WithListTagMap_Check(string[] result, string[] input, string tag);
  protected abstract void WithMapTag_Check(string[] result, string key, string value, string tag);
  protected abstract void WithMapTagFlow_Check(string[] result, string key, string value, string tag);
  protected abstract void WithMapTagKeys_Check(string[] result, string[] keys, string tag);
  protected abstract void WithMapTagList_Check(string[] result, string key, string[] value, string tag);
}
