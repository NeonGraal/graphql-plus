using System.Diagnostics.CodeAnalysis;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

[TracePerTest]
public class ParserClassTestBase
  : SubstituteBase
{
  protected ITokenizer Tokenizer { get; } = For<ITokenizer>();

  protected static IResultError<T> Error<T>(string message)
    where T : class
    => new ResultError<T>(new(AstNulls.At, message));

  protected static IResultArrayError<T> ErrorA<T>(string message)
    where T : class
    => new ResultArrayError<T>(new(AstNulls.At, message));

  protected void SetupError<T>(string message)
    where T : class
  {
    TokenMessage errMsg = new(AstNulls.At, message);
    ResultError<T> error = new(errMsg);
    ResultArrayError<T> errorA = new(errMsg);

    Tokenizer.Error<T>("", "").ReturnsForAnyArgs(error);
    Tokenizer.Error<T>("", "", null).ReturnsForAnyArgs(error);
    Tokenizer.ErrorArray<T>("", "").ReturnsForAnyArgs(errorA);
    Tokenizer.ErrorArray<T>("", "", null).ReturnsForAnyArgs(errorA);
  }

  protected void ParseOk<T>([NotNull] Parser<T>.I parser, T? result = null)
    where T : class, IGqlpAbbreviated
  {
    IResult<T> okResult = (result ?? AtFor<T>()).Ok();
    parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(okResult);
  }

  protected void ParseOkArray<T>([NotNull] Parser<T>.IA parser, T[]? result = null)
    where T : class, IGqlpAbbreviated
  {
    IResultArray<T> okResult;
    if (result is null) {
      okResult = new T[] { AtFor<T>() }.OkArray();
    } else {
      okResult = result.OkArray();
    }

    parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(okResult);
  }

  protected void ParseEmptyArray<T>([NotNull] Parser<T>.IA parser)
    where T : class, IGqlpAbbreviated
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(0.EmptyArray<T>());

  protected void ParseError<T>([NotNull] Parser<T>.I parser, string message)
    where T : class, IGqlpAbbreviated
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(Error<T>(message));

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
