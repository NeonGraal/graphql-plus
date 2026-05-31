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
  private readonly IMessages _errors = Messages.New;

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
    where T : class, IAstError
    => SetupPartial(AtFor<T>());

  protected void SetupPartial<T>(T result)
  {
    TokenMessage errMsg = new(AstNulls.At, "partial error for " + typeof(T).ExpandTypeName());
    ResultPartial<T> Partial(CallInfo c) => new(c.Arg<Func<T>>().Invoke(), errMsg);
    ResultArrayPartial<T> PartialA(CallInfo c) => new(c.Arg<Func<IEnumerable<T>>>().Invoke(), errMsg);

    Tokenizer.Partial(string.Empty, string.Empty, () => result).ReturnsForAnyArgs(c => Partial(c));
    Tokenizer.PartialArray<T>(string.Empty, string.Empty, () => [result]).ReturnsForAnyArgs(c => PartialA(c));
  }

  protected void Parse<T>([NotNull] IParser<T> parser, IResult<T> first, params IResult<T>[] rest)
    => parser.ThrowIfNull().Parse(Tokenizer, default!).ReturnsForAnyArgs(first, rest);

  protected void ParseA<T>([NotNull] IParserArray<T> parser, IResultArray<T> first, params IResultArray<T>[] rest)
    => parser.ThrowIfNull().Parse(Tokenizer, default!).ReturnsForAnyArgs(first, rest);

  protected T ParseOk<T>([NotNull] IParser<T> parser, int n = 1)
    where T : class, IAstError
  {
    ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);

    T result = AtFor<T>();
    IResult<T>[] more = new IResult<T>[n];
    Array.Fill(more, result.Ok());
    more[^1] = result.Empty();
    Parse(parser, result.Ok(), more);
    return result;
  }

  protected void ParseOk<T>([NotNull] IParser<T> parser, T result)
    => Parse(parser, result.Ok(), result.Empty());

  protected void ParseEmpty<T>([NotNull] IParser<T> parser)
    where T : class
    => Parse(parser, default(T).Empty());

  protected void ParseError<T>([NotNull] IParser<T> parser, string? message = null)
    => Parse(parser, Error<T>(message.IfWhiteSpace("error for " + typeof(T).ExpandTypeName())));

  protected T ParseOkError<T>([NotNull] IParser<T> parser, int n = 1, string? message = null)
    where T : class, IAstError
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

  protected T[] ParseOkA<T>([NotNull] IParserArray<T> parser, int n = 1)
    where T : class, IAstError
  {
    ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);

    T[] result = [AtFor<T>()];
    IResultArray<T>[] more = new IResultArray<T>[n];
    Array.Fill(more, result.OkArray());
    more[^1] = result.EmptyArray();
    ParseA(parser, result.OkArray(), more);
    return result;
  }

  protected T[] ParseOkA<T>([NotNull] IParserArray<T> parser, T item)
  {
    T[] result = [item];
    ParseOkA(parser, result);
    return result;
  }

  protected void ParseOkA<T>([NotNull] IParserArray<T> parser, T[] result)
    => ParseA(parser, result.OkArray(), result.EmptyArray());

  protected void ParseEmptyA<T>([NotNull] IParserArray<T> parser)
    => ParseA(parser, 0.EmptyArray<T>());

  protected void ParseErrorA<T>([NotNull] IParserArray<T> parser, string? message = null)
    => ParseA(parser, ErrorA<T>(message.IfWhiteSpace("error for array of " + typeof(T).ExpandTypeName())));

  protected T[] ParseOkErrorA<T>([NotNull] IParserArray<T> parser, int n = 1, string? message = null)
    where T : class, IAstError
  {
    ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);

    T[] result = [AtFor<T>()];
    IResultArray<T>[] more = new IResultArray<T>[n];
    Array.Fill(more, result.OkArray());
    more[^1] = ErrorA<T>(message.IfWhiteSpace("error for array of " + typeof(T).ExpandTypeName()));
    ParseA(parser, result.OkArray(), more);
    return result;
  }

  protected void ParseOkField<T>([NotNull] IParser<IAstFields<T>> parser, string fieldName)
    where T : class, IAstError
  {
    T value = AtFor<T>();
    IAstFields<T> objectResult = A.Fields(fieldName, value);
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
    where T : class, IAstError
  {
    T result = A.Error<T>();
    if (typeof(T).IsAssignableTo(typeof(IAstAbbreviated))) {
      ((IAstAbbreviated)result).At.Returns(AstNulls.At);
    }

    return result;
  }

  protected static ParserOne<T> LazyFor<T>(out IParser<T> parser)
  {
    IParser<T> p = A.Of<IParser<T>>();
    p.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());
    parser = p;
    return new ParserOne<T>(() => p);
  }

  protected static ParserArray<T> LazyAFor<T>(out IParserArray<T> parser)
  {
    IParserArray<T> p = A.Of<IParserArray<T>>();
    p.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());
    parser = p;
    return new ParserArray<T>(() => p);
  }

  protected static ParserOne<TInterface, T> LazyFor<TInterface, T>(out TInterface parser)
    where TInterface : class, IParser<T>
  {
    TInterface p = Substitute.For<TInterface, IParser<T>>();
    p.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());
    parser = p;
    return new ParserOne<TInterface, T>(() => p);
  }

  protected static ParserArray<TInterface, T> LazyAFor<TInterface, T>(out TInterface parser)
    where TInterface : class, IParserArray<T>
  {
    TInterface p = A.Of<TInterface>();
    p.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());
    parser = p;
    return new ParserArray<TInterface, T>(() => p);
  }

  protected static void ConfigureRepo<T>([NotNull] IParserRepository repo, out IParser<T> parser)
  {
    IParser<T> p = A.Of<IParser<T>>();
    p.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());
    parser = p;
    repo.ThrowIfNull().ParserFor<T>().ReturnsForAnyArgs(() => p);
  }

  protected static void ConfigureRepoArray<T>([NotNull] IParserRepository repo, out IParserArray<T> parser)
  {
    IParserArray<T> p = A.Of<IParserArray<T>>();
    p.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());
    parser = p;
    repo.ThrowIfNull().ArrayFor<T>().ReturnsForAnyArgs(() => p);
  }

  protected static void ConfigureRepoInterface<TInterface, T>([NotNull] IParserRepository repo, out TInterface parser)
    where TInterface : class, IParser<T>
  {
    TInterface p = Substitute.For<TInterface, IParser<T>>();
    p.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());
    parser = p;
    repo.ThrowIfNull().ParserFor<TInterface, T>().ReturnsForAnyArgs(() => p);
  }

  protected static void ConfigureRepoArrayInterface<TInterface, T>([NotNull] IParserRepository repo, out TInterface parser)
    where TInterface : class, IParserArray<T>
  {
    TInterface p = A.Of<TInterface>();
    p.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());
    parser = p;
    repo.ThrowIfNull().ArrayFor<TInterface, T>().ReturnsForAnyArgs(() => p);
  }

  protected static ParserOne<T>.D ParserFor<T>(out IParser<T> parser)
  {
    parser = A.Of<IParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());

    ParserOne<T>.D result = A.Of<ParserOne<T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static ParserArray<T>.D ParserAFor<T>(out IParserArray<T> parser)
  {
    parser = A.Of<IParserArray<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());

    ParserArray<T>.D result = A.Of<ParserArray<T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static ParserOne<TInterface, T>.D ParserFor<TInterface, T>(out TInterface parser)
    where TInterface : class, IParser<T>
  {
    parser = Substitute.For<TInterface, IParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());

    ParserOne<TInterface, T>.D result = A.Of<ParserOne<TInterface, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static ParserArray<TInterface, T>.D ParserAFor<TInterface, T>(out TInterface parser)
    where TInterface : class, IParserArray<T>
  {
    parser = A.Of<TInterface>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<T>());

    ParserArray<TInterface, T>.D result = A.Of<ParserArray<TInterface, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static ParserOne<IOptionParser<T>, T>.D OptionParserFor<T>()
    where T : struct
    => OptionParserFor(out IOptionParser<T> _);

  protected static ParserOne<IOptionParser<T>, T>.D OptionParserFor<T>(out IOptionParser<T> parser)
    where T : struct
  {
    parser = A.Of<IOptionParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());

    ParserOne<IOptionParser<T>, T>.D result = A.Of<ParserOne<IOptionParser<T>, T>.D>();
    result().Returns(parser);

    return result;
  }

  protected static ParserOne<IEnumParser<T>, T>.D EnumParserFor<T>()
    where T : struct
    => EnumParserFor(out IEnumParser<T> _);

  protected static ParserOne<IEnumParser<T>, T>.D EnumParserFor<T>(out IEnumParser<T> parser)
    where T : struct
  {
    parser = A.Of<IEnumParser<T>>();
    parser.Parse(default!, default!)
      .ReturnsForAnyArgs(default(T).Empty());

    ParserOne<IEnumParser<T>, T>.D result = A.Of<ParserOne<IEnumParser<T>, T>.D>();
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
