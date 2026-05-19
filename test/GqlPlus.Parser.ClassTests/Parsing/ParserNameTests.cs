using GqlPlus.Parsing.Schema;

namespace GqlPlus.Parsing;

public class ParserNameTests
  : SubstituteBase
{
  [Theory, RepeatData]
  public void ParseName_WhenCalled_DelegatesToValue(string name)
  {
    INameParser inner = A.Of<INameParser>();
    ITokenizer tokens = A.Of<ITokenizer>();
    inner.ParseName(tokens, out string? dummyName, out TokenAt dummyAt).ReturnsForAnyArgs(x => {
      x[1] = name;
      x[2] = default(TokenAt);
      return true;
    });

    ParserName<INameParser> parser = new(() => inner);

    bool result = parser.ParseName(tokens, out string? parsedName, out TokenAt at);

    result.ShouldBeTrue();
    parsedName.ShouldBe(name);
  }

  [Theory, RepeatData]
  public void ImplicitConvert_FromDelegate_ReturnsParserName(string name)
  {
    INameParser inner = A.Of<INameParser>();
    ITokenizer tokens = A.Of<ITokenizer>();
    inner.ParseName(tokens, out string? dummyName, out TokenAt dummyAt).ReturnsForAnyArgs(x => {
      x[1] = name;
      x[2] = default(TokenAt);
      return true;
    });

    ParserName<INameParser>.D factory = () => inner;
    ParserName<INameParser> result = factory;

    bool parsed = result.ParseName(tokens, out string? parsedName, out TokenAt _);

    parsed.ShouldBeTrue();
    parsedName.ShouldBe(name);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    ParserName<INameParser>.D? factory = null;

    Action result = () => _ = (ParserName<INameParser>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
