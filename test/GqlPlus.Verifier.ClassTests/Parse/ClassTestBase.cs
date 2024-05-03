using GqlPlus.Parse.Schema;
using GqlPlus.Parse.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;
using NSubstitute;

namespace GqlPlus.Parse;

[TracePerTest]
[SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable")]
public class ClassTestBase
{
  protected static Tokenizer Tokens(string input)
  {
    var tokens = new Tokenizer(input);
    tokens.Read();
    return tokens;
  }

  internal static T NameFor<T>(string name)
    where T : class, INameParser
  {
    var nameParser = Substitute.For<T>();
    nameParser.ParseName(default!, out var _, out var _)
      .ReturnsForAnyArgs(c => {
        c[1] = name;
        return true;
      });
    return nameParser;
  }

  protected static Parser<T>.D ParserFor<T>()
    => ParserFor<T>(out var _);

  protected static Parser<T>.D ParserFor<T>(out Parser<T>.I parser)
  {
    parser = Substitute.For<Parser<T>.I>();
    parser.Parse<Tokenizer>(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    var result = Substitute.For<Parser<T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<IOptionParser<T>, T>.D OptionParserFor<T>()
    where T : struct
    => OptionParserFor<T>(out var _);

  protected static Parser<IOptionParser<T>, T>.D OptionParserFor<T>(out Parser<T>.I parser)
    where T : struct
  {
    parser = Substitute.For<IOptionParser<T>>();
    parser.Parse<Tokenizer>(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    var result = Substitute.For<Parser<IOptionParser<T>, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<IEnumParser<T>, T>.D EnumParserFor<T>()
    where T : struct
    => EnumParserFor<T>(out var _);

  protected static Parser<IEnumParser<T>, T>.D EnumParserFor<T>(out Parser<T>.I parser)
    where T : struct
  {
    parser = Substitute.For<IEnumParser<T>>();
    parser.Parse<Tokenizer>(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    var result = Substitute.For<Parser<IEnumParser<T>, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<T>.DA ArrayParserFor<T>()
    => ArrayParserFor<T>(out var _);

  protected static Parser<T>.DA ArrayParserFor<T>(out Parser<T>.IA parser)
  {
    parser = Substitute.For<Parser<T>.IA>();
    parser.Parse<Tokenizer>(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());

    var result = Substitute.For<Parser<T>.DA>();
    result().Returns(parser);

    return result;
  }
}
