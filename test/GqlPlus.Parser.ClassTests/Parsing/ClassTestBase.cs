using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;
using NSubstitute;

namespace GqlPlus.Parsing;

[TracePerTest]
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
public class ClassTestBase
{
  internal static T NameFor<T>(string name)
    where T : class, INameParser
  {
    T nameParser = Substitute.For<T>();
    nameParser.ParseName(default!, out string? _, out TokenAt _)
      .ReturnsForAnyArgs(c => {
        c[1] = name;
        return true;
      });
    return nameParser;
  }

  protected static Parser<T>.D ParserFor<T>()
    => ParserFor(out Parser<T>.I _);

  protected static Parser<T>.D ParserFor<T>(out Parser<T>.I parser)
  {
    parser = Substitute.For<Parser<T>.I>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    Parser<T>.D result = Substitute.For<Parser<T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<IOptionParser<T>, T>.D OptionParserFor<T>()
    where T : struct
    => OptionParserFor(out Parser<T>.I _);

  protected static Parser<IOptionParser<T>, T>.D OptionParserFor<T>(out Parser<T>.I parser)
    where T : struct
  {
    parser = Substitute.For<IOptionParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    Parser<IOptionParser<T>, T>.D result = Substitute.For<Parser<IOptionParser<T>, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<IEnumParser<T>, T>.D EnumParserFor<T>()
    where T : struct
    => EnumParserFor(out Parser<T>.I _);

  protected static Parser<IEnumParser<T>, T>.D EnumParserFor<T>(out Parser<T>.I parser)
    where T : struct
  {
    parser = Substitute.For<IEnumParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    Parser<IEnumParser<T>, T>.D result = Substitute.For<Parser<IEnumParser<T>, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<T>.DA ArrayParserFor<T>()
    => ArrayParserFor(out Parser<T>.IA _);

  protected static Parser<T>.DA ArrayParserFor<T>(out Parser<T>.IA parser)
  {
    parser = Substitute.For<Parser<T>.IA>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());

    Parser<T>.DA result = Substitute.For<Parser<T>.DA>();
    result().Returns(parser);

    return result;
  }
}
