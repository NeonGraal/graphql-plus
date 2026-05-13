using NSubstitute;

namespace GqlPlus;

public class AstHelpersTests
{
  [Fact]
  public void Show_Null_ReturnsCorrect()
  {
    IAstAbbreviated? input = null;

    string result = input.Show();

    result.ShouldBe(string.Empty);
  }

  [Theory, RepeatData]
  public void Show_Various_ReturnsCorrect(string field1, string field2, string field3)
  {
    IAstAbbreviated input = Substitute.For<IAstAbbreviated>();
    input.GetFields().Returns([field1, "(", field2, ")", string.Empty, field3]);

    string result = input.Show();

    result.ToLines().ShouldBe([field1, "(", "  " + field2, ")", field3]);
  }
}
