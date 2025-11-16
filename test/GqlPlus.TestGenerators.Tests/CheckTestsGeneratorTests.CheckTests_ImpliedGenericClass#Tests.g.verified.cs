//HintName: Tests.g.cs
namespace GqlpPlusTests;
partial class Tests<TInput> {
  [Theory, RepeatData]
  public void Check_Name(TInput name)
    => Checks.Check_Name(name);
}
