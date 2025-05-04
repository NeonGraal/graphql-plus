using System.Diagnostics.CodeAnalysis;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;
using NSubstitute.Core;

namespace GqlPlus.Parsing;

[TracePerTest]
public class ParserClassTestBase
  : SubstituteBase
{
  public ParserClassTestBase()
    : this(For<ITokenizer>())
  { }

  protected ParserClassTestBase(ITokenizer tokenizer)
  {
    Tokenizer = tokenizer;
    Tokenizer.At.Returns(AstNulls.At);
    Tokenizer.Errors.Returns([]);
  }

  protected ITokenizer Tokenizer { get; }

  protected void IdentifierReturns(Func<CallInfo, bool> first, params Func<CallInfo, bool>[] rest)
    => Tokenizer.Identifier(out Arg.Any<string?>()).Returns(first, rest);

  protected void PrefixReturns(char prefix, Func<CallInfo, bool> first, params Func<CallInfo, bool>[] rest)
    => Tokenizer
      .Prefix(prefix, out Arg.Any<string?>(), out Arg.Any<TokenAt>())
        .Returns(first, rest);

  protected void TakeReturns(char take, bool first, params bool[] rest)
    => Tokenizer.Take(take).Returns(first, rest);

  protected void TakeReturns(string take, bool first, params bool[] rest)
    => Tokenizer.Take(take).Returns(first, rest);

  protected static IResultError<T> Error<T>(string message)
    where T : class
    => new ResultError<T>(new(AstNulls.At, message));

  protected static IResultArrayError<T> ErrorA<T>(string message)
    where T : class
    => new ResultArrayError<T>(new(AstNulls.At, message));

  protected void SetupError<T>()
    where T : class
  {
    TokenMessage errMsg = new(AstNulls.At, "error for " + typeof(T).ExpandTypeName());
    ResultError<T> error = new(errMsg);
    ResultArrayError<T> errorA = new(errMsg);

    Tokenizer.Error<T>("", "").ReturnsForAnyArgs(error);
    Tokenizer.Error<T>("", "", null).ReturnsForAnyArgs(error);
    Tokenizer.ErrorArray<T>("", "").ReturnsForAnyArgs(errorA);
    Tokenizer.ErrorArray<T>("", "", null).ReturnsForAnyArgs(errorA);
  }

  protected void SetupPartial<T>()
    where T : class, IGqlpError
    => SetupPartial(AtFor<T>());

  protected void SetupPartial<T>(T result)
    where T : class
  {
    TokenMessage errMsg = new(AstNulls.At, "partial error for " + typeof(T).ExpandTypeName());
    ResultPartial<T> partial = new(result, errMsg);
    ResultArrayPartial<T> partialA = new([result], errMsg);

    Tokenizer.Partial("", "", () => result).ReturnsForAnyArgs(partial);
    Tokenizer.PartialArray<T>("", "", () => [result]).ReturnsForAnyArgs(partialA);
  }

  protected void Parse<T>([NotNull] Parser<T>.I parser, IResult<T> first, params IResult<T>[] rest)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(first, rest);

  protected T ParseOk<T>([NotNull] Parser<T>.I parser)
    where T : class, IGqlpError
  {
    T result = AtFor<T>();
    ParseOk(parser, result);
    return result;
  }

  protected void ParseOk<T>([NotNull] Parser<T>.I parser, T result)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(result.Ok());

  protected void ParseEmpty<T>([NotNull] Parser<T>.I parser)
    where T : class
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(0.Empty<T>());

  protected T[] ParseOkA<T>([NotNull] Parser<T>.IA parser)
    where T : class, IGqlpError
  {
    T[] result = [AtFor<T>()];
    ParseOkA(parser, result);
    return result;
  }

  protected T[] ParseOkA<T>([NotNull] Parser<T>.IA parser, T item)
  {
    T[] result = [item];
    ParseOkA(parser, result);
    return result;
  }

  protected void ParseOkA<T>([NotNull] Parser<T>.IA parser, T[] result)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(result.OkArray());

  protected void ParseEmptyA<T>([NotNull] Parser<T>.IA parser)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(0.EmptyArray<T>());

  protected void ParseError<T>([NotNull] Parser<T>.I parser, string? message = null)
    where T : class
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(Error<T>(message ?? "error for " + typeof(T).ExpandTypeName()));

  protected void ParseErrorA<T>([NotNull] Parser<T>.IA parser, string? message = null)
    where T : class
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(ErrorA<T>(message ?? "error for array of " + typeof(T).ExpandTypeName()));

  protected void ParseOkField<T>([NotNull] Parser<IGqlpFields<T>>.I parser, string fieldName)
    where T : class, IGqlpError
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
    where T : class, IGqlpError
  {
    T result = EFor<T>();
    if (typeof(T).IsAssignableTo(typeof(IGqlpAbbreviated))) {
      ((IGqlpAbbreviated)result).At.Returns(AstNulls.At);
    }

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

  protected static bool OutPass(CallInfo _)
    => true;

  protected static Func<CallInfo, bool> OutNumber(decimal? value)
    => c => {
      c[0] = value;
      return true;
    };

  protected static Func<CallInfo, bool> OutString(string? value)
    => c => {
      c[0] = value;
      return true;
    };

  protected static Func<CallInfo, bool> OutStringAt(string? value, int first = 1)
    => c => {
      c[first] = value;
      c[first + 1] = AstNulls.At;
      return true;
    };
}
