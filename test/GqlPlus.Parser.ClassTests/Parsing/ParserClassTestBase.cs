using System.Diagnostics.CodeAnalysis;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Objects;
using GqlPlus.Parsing.Schema.Simple;
using NSubstitute.Core;

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

  protected void SetupPartial<T>(string message)
    where T : class, IGqlpAbbreviated
    => SetupPartial(message, AtFor<T>());

  protected void SetupPartial<T>(string message, T result)
    where T : class
  {
    TokenMessage errMsg = new(AstNulls.At, message);
    ResultPartial<T> partial = new(result, errMsg);
    ResultArrayPartial<T> partialA = new([], errMsg);

    Tokenizer.Partial<T>("", "", () => result).ReturnsForAnyArgs(partial);
    Tokenizer.PartialArray<T>("", "", () => [result]).ReturnsForAnyArgs(partialA);
  }

  protected void ParseOk<T>([NotNull] Parser<T>.I parser)
    where T : class, IGqlpAbbreviated
    => ParseOk<T>(parser, AtFor<T>());

  protected void ParseOk<T>([NotNull] Parser<T>.I parser, T result)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(result.Ok());

  protected void ParseEmpty<T>([NotNull] Parser<T>.I parser)
    where T : class
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(0.Empty<T>());

  protected void ParseOkA<T>([NotNull] Parser<T>.IA parser)
    where T : class, IGqlpAbbreviated
    => ParseOkA(parser, [AtFor<T>()]);

  protected void ParseOkA<T>([NotNull] Parser<T>.IA parser, T[] result)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(result.OkArray());

  protected void ParseEmptyA<T>([NotNull] Parser<T>.IA parser)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(0.EmptyArray<T>());

  protected void ParseError<T>([NotNull] Parser<T>.I parser, string message)
    where T : class
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(Error<T>(message));

  protected void ParseErrorA<T>([NotNull] Parser<T>.IA parser, string message)
    where T : class
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(ErrorA<T>(message));

  protected void ParseOkField<T>([NotNull] Parser<IGqlpFields<T>>.I parser, string fieldName)
    where T : class, IGqlpAbbreviated
  {
    IGqlpFields<T> objectResult = For<IGqlpFields<T>>();
    FieldKeyAst fieldKey = new(AstNulls.At, fieldName);
    T value = AtFor<T>();
    Dictionary<IGqlpFieldKey, T> dict = new() { [fieldKey] = value };
    objectResult.GetEnumerator().Returns(dict.GetEnumerator());
    ParseOk(parser, objectResult);
  }

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

  protected static Parser<T>.D ParserFor<T>(out Parser<T>.I parser)
  {
    parser = For<Parser<T>.I>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.Empty<T>());

    Parser<T>.D result = For<Parser<T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<T>.DA ParserAFor<T>()
    => ParserAFor(out Parser<T>.IA _);

  protected static Parser<T>.DA ParserAFor<T>(out Parser<T>.IA parser)
  {
    parser = For<Parser<T>.IA>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());

    Parser<T>.DA result = For<Parser<T>.DA>();
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

  protected static ParserArray<TInterface, T>.DA ParserAFor<TInterface, T>(out Parser<T>.IA parser)
    where TInterface : class, Parser<T>.IA
  {
    parser = For<TInterface>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());

    ParserArray<TInterface, T>.DA result = For<ParserArray<TInterface, T>.DA>();
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

  protected static bool OutFail(CallInfo _)
    => false;

  protected static Func<CallInfo, bool> OutNumber(decimal value)
    => c => {
      c[0] = value;
      return true;
    };

  protected static Func<CallInfo, bool> OutString(string value)
    => c => {
      c[0] = value;
      return true;
    };

  protected static Func<CallInfo, bool> OutStringAt(string value, int first = 1)
    => c => {
      c[first] = value;
      c[first + 1] = AstNulls.At;
      return true;
    };
}
