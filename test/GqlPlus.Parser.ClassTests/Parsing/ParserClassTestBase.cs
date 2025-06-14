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
  private readonly TokenMessages _errors = [];

  protected void IdentifierReturns(Func<CallInfo, bool> first, params Func<CallInfo, bool>[] rest)
    => Tokenizer.Identifier(out Arg.Any<string?>()).Returns(first, [.. rest, OutFail]);

  protected void NumberReturns(Func<CallInfo, bool> first, params Func<CallInfo, bool>[] rest)
    => Tokenizer.Number(out Arg.Any<decimal>()).Returns(first, [.. rest, OutFail]);

  protected void PrefixReturns(char prefix, Func<CallInfo, bool> first, params Func<CallInfo, bool>[] rest)
    => Tokenizer
      .Prefix(prefix, out Arg.Any<string?>(), out Arg.Any<TokenAt>())
        .Returns(first, [.. rest, OutFailAt()]);

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

    Tokenizer.Error<T>("", "").ReturnsForAnyArgs(error);
    Tokenizer.Error<T>("", "", default).ReturnsForAnyArgs(error);
    Tokenizer.ErrorArray<T>("", "").ReturnsForAnyArgs(errorA);
    Tokenizer.ErrorArray<T>("", "", null).ReturnsForAnyArgs(errorA);
  }

  protected void SetupPartial<T>()
    where T : class, IGqlpError
    => SetupPartial(AtFor<T>());

  protected void SetupPartial<T>(T result)
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
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(result.Ok(), result.Empty());

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
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(Error<T>(message ?? "error for " + typeof(T).ExpandTypeName()));

  protected void ParseErrorA<T>([NotNull] Parser<T>.IA parser, string? message = null)
    => parser.Parse(Tokenizer, default!).ReturnsForAnyArgs(ErrorA<T>(message ?? "error for array of " + typeof(T).ExpandTypeName()));

  protected void ParseOkField<T>([NotNull] Parser<IGqlpFields<T>>.I parser, string fieldName)
    where T : class, IGqlpError
  {
    T value = AtFor<T>();
    IGqlpFields<T> objectResult = A.Fields(fieldName, value);
    ParseOk(parser, objectResult);
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
      .ReturnsForAnyArgs(0.Empty<T>());

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
      .ReturnsForAnyArgs(0.Empty<T>());

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
      .ReturnsForAnyArgs(0.Empty<T>());

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
      .ReturnsForAnyArgs(0.Empty<T>());

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
