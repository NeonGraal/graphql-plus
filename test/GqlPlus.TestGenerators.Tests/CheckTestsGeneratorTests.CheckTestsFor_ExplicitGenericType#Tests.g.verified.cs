//HintName: Tests.g.cs
namespace GqlpPlusTests;
partial class Tests {
  [Theory, RepeatData]
  public void Check_Name(string name)
    => Checks.Check_Name(name);
}
