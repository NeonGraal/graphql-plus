using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

[TracePerTest]
public class ParserClassTestBase
  : SubstituteBase
{
  internal static T NameFor<T>(string name)
    where T : class, INameParser
  {
    T nameParser = For<T>();
    nameParser.ParseName(default!, out string? _, out TokenAt _)
      .ReturnsForAnyArgs(c => {
        c[1] = name;
        return true;
      });
    return nameParser;
  }

  protected static T AtFor<T>()
    where T : class, IGqlpAbbreviated
  {
    T result = EFor<T>();
    result.At.Returns(AstNulls.At);
    return result;
  }

  protected static Parser<T>.D ParserFor<T>()
    => ParserFor(out Parser<T>.I _);

  protected static Parser<T>.D ParserFor<T>(out Parser<T>.I parser)
  {
    parser = For<Parser<T>.I>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    Parser<T>.D result = For<Parser<T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<TInterface, T>.D ParserFor<TInterface, T>(out Parser<T>.I parser)
    where TInterface : class, Parser<T>.I
  {
    parser = Substitute.For<TInterface, Parser<T>.I>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    Parser<TInterface, T>.D result = For<Parser<TInterface, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<IOptionParser<T>, T>.D OptionParserFor<T>()
    where T : struct
    => OptionParserFor(out Parser<T>.I _);

  protected static Parser<IOptionParser<T>, T>.D OptionParserFor<T>(out Parser<T>.I parser)
    where T : struct
  {
    parser = For<IOptionParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    Parser<IOptionParser<T>, T>.D result = For<Parser<IOptionParser<T>, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<IEnumParser<T>, T>.D EnumParserFor<T>()
    where T : struct
    => EnumParserFor(out Parser<T>.I _);

  protected static Parser<IEnumParser<T>, T>.D EnumParserFor<T>(out Parser<T>.I parser)
    where T : struct
  {
    parser = For<IEnumParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    Parser<IEnumParser<T>, T>.D result = For<Parser<IEnumParser<T>, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<T>.DA ArrayParserFor<T>()
    => ArrayParserFor(out Parser<T>.IA _);

  protected static Parser<T>.DA ArrayParserFor<T>(out Parser<T>.IA parser)
  {
    parser = For<Parser<T>.IA>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());

    Parser<T>.DA result = For<Parser<T>.DA>();
    result().Returns(parser);

    return result;
  }
}
