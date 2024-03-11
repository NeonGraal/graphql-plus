using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse;

internal class OneChecksParser<T>(Parser<T>.D parser)
{
  private readonly Parser<T>.L _parser = parser;
  private readonly string _type = typeof(T).ToString();

  internal void TrueExpected(string input, T expected, bool skipIf = false)
  {
    Skip.If(skipIf);

    var tokens = Tokens(input);
    var result = _parser.Parse(tokens, "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsOk().Should().BeTrue(_type + " -> " + input);
    scope.FormattingOptions.MaxDepth = 10;
    tokens.Errors.Should().BeEmpty();
    result.Required().Should().Be(expected);
  }

  internal void Ok(string input, T expected, bool skipIf = false)
  {
    Skip.If(skipIf);

    var tokens = Tokens(input);
    var result = _parser.Parse(tokens, "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsOk().Should().BeTrue(_type + " -> " + input);
    tokens.Errors.Should().BeEmpty();
    result.Required().Should().Be(expected);
  }

  internal void Empty(string input)
  {
    var tokens = Tokens(input);
    var result = _parser.Parse(tokens, "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsEmpty().Should().BeTrue(_type + " -> " + input);
    tokens.Errors.Should().BeEmpty();
  }

  internal void Partial(string input, string error, T expected, bool skipIf = false)
  {
    Skip.If(skipIf);

    var result = _parser.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error, StringComparison.InvariantCulture)).Should().BeTrue(_type + " -> " + input);
    result.Optional().Should().Be(expected);
  }

  internal void Error(string input, string error, bool skipIf = false)
  {
    Skip.If(skipIf);

    var result = _parser.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error, StringComparison.InvariantCulture)).Should().BeTrue(_type + " -> " + input);
  }

  internal void False(string input, Action<T?>? check = null, bool skipIf = false)
  {
    Skip.If(skipIf);

    var result = _parser.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    if (result.IsEmpty()) {
      return;
    }

    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type + " -> " + input);
    result.Optional(result => check?.Invoke(result));
  }
}

internal sealed class OneChecksParser<I, T>(Parser<I, T>.D parser)
  where I : Parser<T>.I
{
  private readonly Parser<I, T>.L _parser = parser;
  private readonly string _type = typeof(I).ToString();

  internal void TrueExpected(string input, T expected, bool skipIf = false)
  {
    Skip.If(skipIf);

    var tokens = Tokens(input);
    var result = _parser.I.Parse(tokens, "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsOk().Should().BeTrue(_type + " -> " + input);
    scope.FormattingOptions.MaxDepth = 10;
    tokens.Errors.Should().BeEmpty();
    result.Required().Should().Be(expected);
  }

  internal void Ok(string input, T expected, bool skipIf = false)
  {
    Skip.If(skipIf);

    var tokens = Tokens(input);
    var result = _parser.I.Parse(tokens, "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsOk().Should().BeTrue(_type + " -> " + input);
    tokens.Errors.Should().BeEmpty();
    result.Required().Should().Be(expected);
  }

  internal void Empty(string input)
  {
    var tokens = Tokens(input);
    var result = _parser.I.Parse(tokens, "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsEmpty().Should().BeTrue(_type + " -> " + input);
    tokens.Errors.Should().BeEmpty();
  }

  internal void Partial(string input, string error, T expected, bool skipIf = false)
  {
    Skip.If(skipIf);

    var result = _parser.I.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error, StringComparison.InvariantCulture)).Should().BeTrue(_type + " -> " + input);
    result.Optional().Should().Be(expected);
  }

  internal void Error(string input, string error, bool skipIf = false)
  {
    Skip.If(skipIf);

    var result = _parser.I.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error, StringComparison.InvariantCulture)).Should().BeTrue(_type + " -> " + input);
  }

  internal void False(string input, Action<T?>? check = null, bool skipIf = false)
  {
    Skip.If(skipIf);

    var result = _parser.I.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type + " -> " + input);
    result.Optional(result => check?.Invoke(result));
  }
}
