//HintName: Tests.g.cs
namespace GqlpPlusTests;
partial class Tests {
#line 4 "{testString}"
  [Fact]
  public void Check_Test()
    => Checks1.Check_Test();
#line 4 "{testString}"
  [Theory, RepeatData]
  public void Checks1_Check_Name(string name)
    => Checks1.Check_Name(name);
#line 7 "{testString}"
  [Theory, RepeatData]
  public void Checks2_Check_Name(string name)
    => Checks2.Check_Name(name);
#line 4 "{testString}"
  [Theory, RepeatData]
  public void Checks1_Check_Basic(string name)
    => Checks1.Check_Basic(name);
#line 7 "{testString}"
  [Theory, RepeatData]
  public void Checks2_Check_Basic(string name)
    => Checks2.Check_Basic(name);
}
