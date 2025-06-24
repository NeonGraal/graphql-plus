namespace GqlPlus.Convert;

public abstract class ConverterClassTestBase
{
  [Fact]
  public void WithNull_ReturnsCorrect()
  {
    // Arrange
    Structured[] list = [];
    Structured model = new(list);

    // Act
    string result = Convert(model);

    // Assert
    WithNull_Check(result);
  }

  [Theory, RepeatData]
  public void WithIdentifier_ReturnsCorrect(string input)
  {
    // Arrange
    Structured model = new(input);

    // Act
    string result = Convert(model);

    // Assert
    WithIdentifier_Check(result, input);
  }

  [Theory, RepeatData]
  public void WithBoolean_ReturnsCorrect(bool input)
  {
    // Arrange
    Structured model = new(input);

    // Act
    string result = Convert(model);

    // Assert
    WithBoolean_Check(result, input);
  }

  [Theory, RepeatData]
  public void WithNumber_ReturnsCorrect(decimal input)
  {
    // Arrange
    Structured model = new(input);

    // Act
    string result = Convert(model);

    // Assert
    WithNumber_Check(result, input);
  }

  [Theory, RepeatData]
  public void WithText_ReturnsCorrect(string text)
  {
    // Arrange
    string input = text + " " + text;
    Structured model = new(StructureValue.Str(input));

    // Act
    string result = Convert(model);

    // Assert
    WithText_Check(result, input);
  }

  [Theory, RepeatData]
  public void WithList_ReturnsCorrect(string[] input)
  {
    // Arrange
    Structured model = input.Encode();

    // Act
    string result = Convert(model);

    // Assert
    WithList_Check(result, input);
  }

  [Theory, RepeatData]
  public void WithListFlow_ReturnsCorrect(string[] input)
  {
    // Arrange
    Structured model = input.Encode(flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithListFlow_Check(result, input);
  }

  [Theory, RepeatData]
  public void WithListMap_ReturnsCorrect(string[] input)
  {
    // Arrange
    Structured model = input.Encode(MakeMap);

    // Act
    string result = Convert(model);

    // Assert
    WithListMap_Check(result, input);
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
    WithMap_Check(result, key, value);
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
    WithMapFlow_Check(result, key, value);
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
    WithMapKeys_Check(result, keys);
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
    WithMapList_Check(result, key, value);
  }

  // Tagged tests
  [Theory, RepeatData]
  public void WithNullTag_ReturnsCorrect(string tag)
  {
    // Arrange
    Structured[] list = [];
    Structured model = new(list, tag);

    // Act
    string result = Convert(model);

    // Assert
    WithNullTag_Check(result, tag);
  }

  [Theory, RepeatData]
  public void WithIdentifierTag_ReturnsCorrect(string input, string tag)
  {
    // Arrange
    Structured model = new(input, tag);

    // Act
    string result = Convert(model);

    // Assert
    WithIdentifierTag_Check(result, input, tag);
  }

  [Theory, RepeatData]
  public void WithBooleanTag_ReturnsCorrect(bool input, string tag)
  {
    // Arrange
    Structured model = new(input, tag);

    // Act
    string result = Convert(model);

    // Assert
    WithBooleanTag_Check(result, input, tag);
  }

  [Theory, RepeatData]
  public void WithNumberTag_ReturnsCorrect(decimal input, string tag)
  {
    // Arrange
    Structured model = new(input, tag);

    // Act
    string result = Convert(model);

    // Assert
    WithNumberTag_Check(result, input, tag);
  }

  [Theory, RepeatData]
  public void WithTextTag_ReturnsCorrect(string text, string tag)
  {
    // Arrange
    string input = text + " " + text;
    Structured model = new(StructureValue.Str(input, tag));

    // Act
    string result = Convert(model);

    // Assert
    WithTextTag_Check(result, input, tag);
  }

  [Theory, RepeatData]
  public void WithListTag_ReturnsCorrect(string[] input, string tag)
  {
    // Arrange
    Structured model = input.Encode(tag);

    // Act
    string result = Convert(model);

    // Assert
    WithListTag_Check(result, input, tag);
  }

  [Theory, RepeatData]
  public void WithListTagFlow_ReturnsCorrect(string[] input, string tag)
  {
    // Arrange
    Structured model = input.Encode(tag, flow: true);

    // Act
    string result = Convert(model);

    // Assert
    WithListTagFlow_Check(result, input, tag);
  }

  [Theory, RepeatData]
  public void WithListTagMap_ReturnsCorrect(string[] input, string tag)
  {
    // Arrange
    Structured model = input.Encode(MakeMap, tag);

    // Act
    string result = Convert(model);

    // Assert
    WithListTagMap_Check(result, input, tag);
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
    WithMapTag_Check(result, key, value, tag);
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
    WithMapTagFlow_Check(result, key, value, tag);
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
    WithMapTagKeys_Check(result, keys, tag);
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
    WithMapTagList_Check(result, key, value, tag);
  }

  private static Structured MakeMap(string s)
    => new Map<Structured>() { ["value"] = new(s) }.Encode();

  protected abstract string Convert(Structured model);

  protected abstract void WithBoolean_Check(string result, bool input);
  protected abstract void WithIdentifier_Check(string result, string input);
  protected abstract void WithList_Check(string result, string[] input);
  protected abstract void WithListFlow_Check(string result, string[] input);
  protected abstract void WithListMap_Check(string result, string[] input);
  protected abstract void WithMap_Check(string result, string key, string value);
  protected abstract void WithMapFlow_Check(string result, string key, string value);
  protected abstract void WithMapKeys_Check(string result, string[] keys);
  protected abstract void WithMapList_Check(string result, string key, string[] value);
  protected abstract void WithNull_Check(string result);
  protected abstract void WithNumber_Check(string result, decimal input);
  protected abstract void WithText_Check(string result, string input);

  protected abstract void WithBooleanTag_Check(string result, bool input, string tag);
  protected abstract void WithIdentifierTag_Check(string result, string input, string tag);
  protected abstract void WithListTag_Check(string result, string[] input, string tag);
  protected abstract void WithListTagFlow_Check(string result, string[] input, string tag);
  protected abstract void WithListTagMap_Check(string result, string[] input, string tag);
  protected abstract void WithMapTag_Check(string result, string key, string value, string tag);
  protected abstract void WithMapTagFlow_Check(string result, string key, string value, string tag);
  protected abstract void WithMapTagKeys_Check(string result, string[] keys, string tag);
  protected abstract void WithMapTagList_Check(string result, string key, string[] value, string tag);
  protected abstract void WithNullTag_Check(string result, string tag);
  protected abstract void WithNumberTag_Check(string result, decimal input, string tag);
  protected abstract void WithTextTag_Check(string result, string input, string tag);
}
