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
    : this(A.Of<ITokenizer>())
  { }

  protected ParserClassTestBase(ITokenizer tokenizer)
  {
    Tokenizer = tokenizer;
    Tokenizer.At.Returns(AstNulls.At);
    Tokenizer.Errors.Returns(_errors);
  }

  protected ITokenizer Tokenizer { get; }
  private readonly Messages _errors = [];

  protected void IdentifierReturns(Func<CallInfo, bool> first, params Func<CallInfo, bool>[] rest)
    => Tokenizer.Identifier(out Arg.Any<string?>()).Returns(first, [.. rest, OutFail]);

  protected void NumberReturns(Func<CallInfo, bool> first, params Func<CallInfo, bool>[] rest)
    => Tokenizer.Number(out Arg.Any<decimal>()).Returns(first, [.. rest, OutFail]);

  protected void PrefixReturns(char prefix, Func<CallInfo, bool> first, params Func<CallInfo, bool>[] rest)
    => Tokenizer
      .Prefix(prefix, out Arg.Any<string?>(), out Arg.Any<TokenAt>())
        .Returns(first, [.. rest, OutFailAt()]);

  protected void TakeAnyReturns(Func<CallInfo, bool> first, params Func<CallInfo, bool>[] rest)
    => Tokenizer
      .TakeAny(out char _)
        .ReturnsForAnyArgs(first, [.. rest, OutFail]);

  protected void TakeReturns(char take, bool first, params bool[] rest)
    => Tokenizer.Take(take).Returns(first, [.. rest, false]);

  protected void TakeReturns(string take, bool first, params bool[] rest)
    => Tokenizer.Take(take).Returns(first, [.. rest, false]);

  protected static IResultError<T> Error<T>(string message)
    => new ResultError<T>(new(AstNulls.At, message));

  protected static IResultArrayError<T> ErrorA<T>(string message)
    => new ResultArrayError<T>(new(AstNulls.At, message));

  protected void SetupError<T>()
  {
    TokenMessage errMsg = new(AstNulls.At, "error for " + typeof(T).ExpandTypeName());
    ResultError<T> error = new(errMsg);
    ResultArrayError<T> errorA = new(errMsg);
    _errors.Add(errMsg);

    Tokenizer.Error<T>(string.Empty, string.Empty).ReturnsForAnyArgs(error);
    Tokenizer.Error<T>(string.Empty, string.Empty, default).ReturnsForAnyArgs(error);
    Tokenizer.ErrorArray<T>(string.Empty, string.Empty).ReturnsForAnyArgs(errorA);
    Tokenizer.ErrorArray<T>(string.Empty, string.Empty, null).ReturnsForAnyArgs(errorA);
  }

  protected void SetupPartial<T>()
    where T : class, IGqlpError
    => SetupPartial(AtFor<T>());

  protected void SetupPartial<T>(T result)
  {
    TokenMessage errMsg = new(AstNulls.At, "partial error for " + typeof(T).ExpandTypeName());
    ResultPartial<T> Partial(CallInfo c) => new(c.Arg<Func<T>>().Invoke(), errMsg);
    ResultArrayPartial<T> PartialA(CallInfo c) => new(c.Arg<Func<IEnumerable<T>>>().Invoke(), errMsg);

    Tokenizer.Partial(string.Empty, string.Empty, () => result).ReturnsForAnyArgs(c => Partial(c));
    Tokenizer.PartialArray<T>(string.Empty, string.Empty, () => [result]).ReturnsForAnyArgs(c => PartialA(c));
  }

  protected void Parse<T>([NotNull] Parser<T>.I parser, IResult<T> first, params IResult<T>[] rest)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(first, rest);

  protected void ParseA<T>([NotNull] Parser<T>.IA parser, IResultArray<T> first, params IResultArray<T>[] rest)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(first, rest);

  protected T ParseOk<T>([NotNull] Parser<T>.I parser, int n = 1)
    where T : class, IGqlpError
  {
    ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);

    T result = AtFor<T>();
    IResult<T>[] more = new IResult<T>[n];
    Array.Fill(more, result.Ok());
    more[^1] = result.Empty();
    Parse(parser, result.Ok(), more);
    return result;
  }

  protected void ParseOk<T>([NotNull] Parser<T>.I parser, T result)
    => Parse(parser, result.Ok(), result.Empty());

  protected void ParseEmpty<T>([NotNull] Parser<T>.I parser)
    where T : class
    => Parse(parser, default(T).Empty());

  protected void ParseError<T>([NotNull] Parser<T>.I parser, string? message = null)
    => Parse(parser, Error<T>(message.IfWhiteSpace("error for " + typeof(T).ExpandTypeName())));

  protected T ParseOkError<T>([NotNull] Parser<T>.I parser, int n = 1, string? message = null)
    where T : class, IGqlpError
  {
    ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);

    T result = AtFor<T>();
    if (n == 1) {
      ParseOk(parser, result);
    }

    IResult<T>[] more = new IResult<T>[n];
    Array.Fill(more, result.Ok());
    more[^1] = Error<T>(message.IfWhiteSpace("error for " + typeof(T).ExpandTypeName()));
    Parse(parser, result.Ok(), more);
    return result;
  }

  protected T[] ParseOkA<T>([NotNull] Parser<T>.IA parser, int n = 1)
    where T : class, IGqlpError
  {
    ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);

    T[] result = [AtFor<T>()];
    IResultArray<T>[] more = new IResultArray<T>[n];
    Array.Fill(more, result.OkArray());
    more[^1] = result.EmptyArray();
    ParseA(parser, result.OkArray(), more);
    return result;
  }

  protected T[] ParseOkA<T>([NotNull] Parser<T>.IA parser, T item)
  {
    T[] result = [item];
    ParseOkA(parser, result);
    return result;
  }

  protected void ParseOkA<T>([NotNull] Parser<T>.IA parser, T[] result)
    => ParseA(parser, result.OkArray(), result.EmptyArray());

  protected void ParseEmptyA<T>([NotNull] Parser<T>.IA parser)
    => ParseA(parser, 0.EmptyArray<T>());

  protected void ParseErrorA<T>([NotNull] Parser<T>.IA parser, string? message = null)
    => ParseA(parser, ErrorA<T>(message.IfWhiteSpace("error for array of " + typeof(T).ExpandTypeName())));

  protected T[] ParseOkErrorA<T>([NotNull] Parser<T>.IA parser, int n = 1, string? message = null)
    where T : class, IGqlpError
  {
    ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);

    T[] result = [AtFor<T>()];
    IResultArray<T>[] more = new IResultArray<T>[n];
    Array.Fill(more, result.OkArray());
    more[^1] = ErrorA<T>(message.IfWhiteSpace("error for array of " + typeof(T).ExpandTypeName()));
    ParseA(parser, result.OkArray(), more);
    return result;
  }

  protected void ParseOkField<T>([NotNull] Parser<IGqlpFields<T>>.I parser, string fieldName)
    where T : class, IGqlpError
  {
    T value = AtFor<T>();
    IGqlpFields<T> objectResult = A.Fields(fieldName, value);
    ParseOk(parser, objectResult);
  }

  protected void ParseOkOption<T>([NotNull] IOptionParser<T> parser)
    where T : struct
  {
    T value = default;
    Parse(parser, value.Ok());
  }

  internal static T NameFor<T>(string name)
    where T : class, INameParser
  {
    T nameParser = A.Of<T>();
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
    T result = A.Error<T>();
    if (typeof(T).IsAssignableTo(typeof(IGqlpAbbreviated))) {
      ((IGqlpAbbreviated)result).At.Returns(AstNulls.At);
    }

    return result;
  }

  protected static Parser<T>.D ParserFor<T>(out Parser<T>.I parser)
  {
    parser = A.Of<Parser<T>.I>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());

    Parser<T>.D result = A.Of<Parser<T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<T>.DA ParserAFor<T>()
    => ParserAFor(out Parser<T>.IA _);

  protected static Parser<T>.DA ParserAFor<T>(out Parser<T>.IA parser)
  {
    parser = A.Of<Parser<T>.IA>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());

    Parser<T>.DA result = A.Of<Parser<T>.DA>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<TInterface, T>.D ParserFor<TInterface, T>(out TInterface parser)
    where TInterface : class, Parser<T>.I
  {
    parser = Substitute.For<TInterface, Parser<T>.I>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());

    Parser<TInterface, T>.D result = A.Of<Parser<TInterface, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static ParserArray<TInterface, T>.DA ParserAFor<TInterface, T>(out TInterface parser)
    where TInterface : class, Parser<T>.IA
  {
    parser = A.Of<TInterface>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());

    ParserArray<TInterface, T>.DA result = A.Of<ParserArray<TInterface, T>.DA>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<IOptionParser<T>, T>.D OptionParserFor<T>()
    where T : struct
    => OptionParserFor(out IOptionParser<T> _);

  protected static Parser<IOptionParser<T>, T>.D OptionParserFor<T>(out IOptionParser<T> parser)
    where T : struct
  {
    parser = A.Of<IOptionParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());

    Parser<IOptionParser<T>, T>.D result = A.Of<Parser<IOptionParser<T>, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static Parser<IEnumParser<T>, T>.D EnumParserFor<T>()
    where T : struct
    => EnumParserFor(out IEnumParser<T> _);

  protected static Parser<IEnumParser<T>, T>.D EnumParserFor<T>(out IEnumParser<T> parser)
    where T : struct
  {
    parser = A.Of<IEnumParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());

    Parser<IEnumParser<T>, T>.D result = A.Of<Parser<IEnumParser<T>, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static bool OutFail(CallInfo _)
    => false;

  protected static Func<CallInfo, bool> OutFailAt(int first = 1)
    => c => {
      c[first] = null;
      c[first + 1] = default;
      return false;
    };

  protected static bool OutPass(CallInfo _)
    => true;

  protected static Func<CallInfo, bool> OutChar(char? value, int first = 0)
    => OutValue(value, first);

  protected static Func<CallInfo, bool> OutNumber(decimal? value, int first = 0)
    => OutValue(value, first);

  protected static Func<CallInfo, bool> OutString(string? value)
    => OutValue(value);

  protected static Func<CallInfo, bool> OutStringAt(string? value, int first = 1)
    => c => {
      c[first] = value;
      c[first + 1] = AstNulls.At;
      return true;
    };
}
