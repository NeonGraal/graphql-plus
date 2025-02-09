namespace GqlPlus;

public class BuildDataGeneratorTests
{
  [Fact]
  public Task IncludesAttributeCorrrectly()
  {
    string source = @"
using GqlPlus;

public enum Colour
{
    Red = 0,
    Blue = 1,
}";

    // Pass the source code to our helper and snapshot test the output
    return TestGeneratorsHelper.Verify(source);
  }
}
