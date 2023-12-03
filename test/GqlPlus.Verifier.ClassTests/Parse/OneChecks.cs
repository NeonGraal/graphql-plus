namespace GqlPlus.Verifier.Parse;

internal class OneChecks<T>
{
  private readonly IParser<T> _parser;
  private readonly string _type = typeof(T).ToString();

  public OneChecks(IParser<T> parser)
    => _parser = parser;

  internal void TrueExpected(string input, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var tokens = Tokens(input);
    var result = _parser.Parse(tokens);

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsOk().Should().BeTrue(_type + " -> " + input);
    scope.FormattingOptions.MaxDepth = 10;
    tokens.Errors.Should().BeEmpty();
    result.Required().Should().Be(expected);
  }

  internal void Ok(string input, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var tokens = Tokens(input);
    var result = _parser.Parse(tokens);

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsOk().Should().BeTrue(_type + " -> " + input);
    tokens.Errors.Should().BeEmpty();
    result.Required().Should().Be(expected);
  }

  internal void Empty(string input)
  {
    var tokens = Tokens(input);
    var result = _parser.Parse(tokens);

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsEmpty().Should().BeTrue(_type + " -> " + input);
    tokens.Errors.Should().BeEmpty();
  }

  internal void Partial(string input, string error, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = _parser.Parse(Tokens(input));

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error)).Should().BeTrue(_type + " -> " + input);
    result.Optional().Should().Be(expected);
  }

  internal void Error(string input, string error, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = _parser.Parse(Tokens(input));

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error)).Should().BeTrue(_type + " -> " + input);
  }

  internal void False(string input, Action<T?>? check = null, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = _parser.Parse(Tokens(input));

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains("Expected")).Should().BeTrue(_type + " -> " + input);
    result.Optional(result => check?.Invoke(result));
  }
}

internal class OneChecksParser<T>
{
  private readonly Parser<T>.L _parser;
  private readonly string _type = typeof(T).ToString();

  public OneChecksParser(Parser<T>.D parser)
    => _parser = parser;

  internal void TrueExpected(string input, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

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
    if (skipIf) {
      return;
    }

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
    if (skipIf) {
      return;
    }

    var result = _parser.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error)).Should().BeTrue(_type + " -> " + input);
    result.Optional().Should().Be(expected);
  }

  internal void Error(string input, string error, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = _parser.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error)).Should().BeTrue(_type + " -> " + input);
  }

  internal void False(string input, Action<T?>? check = null, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = _parser.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains("Expected")).Should().BeTrue(_type + " -> " + input);
    result.Optional(result => check?.Invoke(result));
  }
}

internal class OneChecksParser<I, T>
  where I : Parser<T>.I
{
  private readonly Parser<I, T>.L _parser;
  private readonly string _type = typeof(I).ToString();

  public OneChecksParser(Parser<I, T>.D parser)
    => _parser = parser;

  internal void TrueExpected(string input, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

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
    if (skipIf) {
      return;
    }

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
    if (skipIf) {
      return;
    }

    var result = _parser.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error)).Should().BeTrue(_type + " -> " + input);
    result.Optional().Should().Be(expected);
  }

  internal void Error(string input, string error, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = _parser.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(error)).Should().BeTrue(_type + " -> " + input);
  }

  internal void False(string input, Action<T?>? check = null, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = _parser.Parse(Tokens(input), "Test");

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains("Expected")).Should().BeTrue(_type + " -> " + input);
    result.Optional(result => check?.Invoke(result));
  }
}
