//HintName: Tests.g.cs
namespace GqlpPlusTests;
partial class Tests {
  [Theory, RepeatData]
  public void Check_Basic(string name)
    => Checks.Check_Basic(name);
}
