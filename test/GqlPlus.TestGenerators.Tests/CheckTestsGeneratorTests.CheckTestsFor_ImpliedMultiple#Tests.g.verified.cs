//HintName: Tests.g.cs
namespace GqlpPlusTests;
partial class Tests {
  [Fact]
  public void Check_Test()
    => Checks.Check_Test();
  [Theory, RepeatData]
  public void Check_Name(string name)
    => Checks.Check_Name(name);
}
