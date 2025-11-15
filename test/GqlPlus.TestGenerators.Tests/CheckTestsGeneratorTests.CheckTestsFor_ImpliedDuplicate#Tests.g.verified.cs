//HintName: Tests.g.cs
namespace GqlpPlusTests;
partial class Tests {
  [Fact]
  public void Check_Test()
    => Checks1.Check_Test();
  [Theory, RepeatData]
  public void Checks1_Check_Name(string name)
    => Checks1.Check_Name(name);
  [Theory, RepeatData]
  public void Checks2_Check_Name(string name)
    => Checks2.Check_Name(name);
  [Theory, RepeatData]
  public void Checks1_Check_Basic(string name)
    => Checks1.Check_Basic(name);
  [Theory, RepeatData]
  public void Checks2_Check_Basic(string name)
    => Checks2.Check_Basic(name);
}
