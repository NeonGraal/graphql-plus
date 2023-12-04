using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Token;

public class Tokenizer
{
  internal const int ErrorContextLen = 10;
  internal const string TripleQuote = "\"\"\"";

  private readonly ReadOnlyMemory<char> _operation;
  private readonly int _len;
  private TokenKind _kind;
  private int _pos;
  private int _line;
  private int _lineStart;

#pragma warning disable IDE1006 // Naming Styles
  private static readonly TokenKind[] _kinds = new TokenKind[96];
  private static readonly bool[] _identifier = new bool[75];
#pragma warning restore IDE1006 // Naming Styles

  static Tokenizer()
  {
    for (var kind = 0; kind < 96; kind++) {
      _kinds[kind] = TokenKind.Punctuation;
    }

    for (var id = 0; id < 75; id++) {
      _identifier[id] = false;
    }

    for (var kind = 'A'; kind <= 'Z'; kind++) {
      _kinds[kind - ' '] = TokenKind.Identifer;
      _identifier[kind - '0'] = true;
    }

    for (var kind = 'a'; kind <= 'z'; kind++) {
      _kinds[kind - ' '] = TokenKind.Identifer;
      _identifier[kind - '0'] = true;
    }

    _kinds['_' - ' '] = TokenKind.Identifer;
    _identifier['_' - '0'] = true;

    for (var kind = '0'; kind <= '9'; kind++) {
      _kinds[kind - ' '] = TokenKind.Number;
      _identifier[kind - '0'] = true;
    }

    _kinds['-' - ' '] = TokenKind.Number;
    _kinds['+' - ' '] = TokenKind.Number;

    _kinds['"' - ' '] = TokenKind.String;
    _kinds['\'' - ' '] = TokenKind.String;

    _kinds['/' - ' '] = TokenKind.Regex;
  }

  internal bool IgnoreSeparators { get; set; }

  internal Tokenizer(string operation)
  {
    _operation = operation.AsMemory();
    _len = _operation.Length;

    _kind = TokenKind.Start;
    _pos = 0;
    IgnoreSeparators = true;
  }

  internal bool AtStart
    => _kind == TokenKind.Start;

  internal bool AtEnd
    => _kind == TokenKind.End;

  internal bool Read()
  {
    if (_kind == TokenKind.Start) {
      _line = 1;
      _lineStart = -1;
    }

    SkipWhitespace();

    if (_pos >= _len) {
      _kind = TokenKind.End;
      return false;
    }

    _kind = _kinds[_operation.Span[_pos] - ' '];

    return true;
  }

  private void SkipWhitespace()
  {
    var span = _operation.Span;
    while (_pos < _len) {
      var code = span[_pos];

      if (code <= ' ' || code > '~'
        || IgnoreSeparators && code == ','
      ) {
        if (code == '\n') {
          _lineStart = _pos;
          _line++;
        }

        ++_pos;
      } else {
        return;
      }
    }

    _kind = TokenKind.End;
  }

  internal bool Identifier(out string identifier)
  {
    identifier = "";
    if (_kind != TokenKind.Identifer) {
      return false;
    }

    var end = Letters(_pos);
    identifier = GetString(end); ;

    _pos = end;
    Read();

    return true;
  }

  private int Letters(int end)
  {
    var span = _operation.Span;
    int code;
    do {
      if (++end >= _len) {
        break;
      }

      code = span[end] - '0';
      if (code is < 0 or > 74) {
        break;
      }
    } while (_identifier[code]);

    return end;
  }

  private string GetString(int end)
  {
    var result = end < _len ? _operation[_pos..end] : _operation[_pos..];
    return result.ToString();
  }

  internal bool Number(out decimal number)
  {
    number = default;
    if (_kind != TokenKind.Number) {
      return false;
    }

    var end = Decimal(_pos);
    number = decimal.Parse(GetString(end).Replace("_", ""));

    _pos = end;
    Read();

    return true;
  }

  private int Digits(int end)
  {
    var span = _operation.Span;

    char code;
    do {
      if (++end >= _len) {
        break;
      }

      code = span[end];
    } while (code is '_' or >= '0' and <= '9');
    return end;
  }

  private int Decimal(int end)
  {
    end = Digits(end);

    if (end < _len && _operation.Span[end] == '.') {
      end = Digits(end);
    }

    return end;
  }

  internal bool String(out string contents)
  {
    contents = "";

    return _kind == TokenKind.String
      && (IsTripleQuote(_pos + 3)
        ? BlockString(out contents)
        : Delimited(_operation.Span[_pos], out contents));
  }

  private bool IsTripleQuote(int end)
    => end < _len
      && _operation[_pos..end].ToString().Equals(TripleQuote, StringComparison.InvariantCulture);

  private bool BlockString(out string contents)
  {
    var span = _operation.Span;
    var next = _pos + 3;
    var end = next;
    do {
      if (span[end] == '\\') {
        ++next;
        end = next;
      } else if (span[next] != '"' || span[end] != '"') {
        end = next;
      }

      next++;
    } while (IsNotTripleQuote(end, next));

    _pos += 3;
    contents = GetString(end)
      .Replace("\\\"", "\"")
      .Replace(@"\\", @"\");

    _pos = next;
    Read();

    return next - end == 3;
  }

  private bool IsNotTripleQuote(int start, int end)
    => end < _len
      && !_operation[start..end].ToString().Equals(TripleQuote, StringComparison.InvariantCulture);

  internal bool Regex(out string regex)
  {
    regex = "";
    return _kind == TokenKind.Regex
      && Delimited('/', out regex);
  }

  private bool Delimited(char delimiter, out string contents)
  {
    var span = _operation.Span;
    var end = _pos;
    do {
      if (span[end] == '\\') {
        ++end;
      }

      ++end;
    } while (end < _len && span[end] != delimiter);

    _pos++;
    contents = GetString(end).Replace(@"\" + delimiter, delimiter.ToString()).Replace(@"\\", @"\");

    _pos = end + 1;
    Read();

    return end < _len;
  }

  internal bool Take(char one)
  {
    if (_kind != TokenKind.Punctuation || _operation.Span[_pos] != one) {
      return false;
    }

    _pos++;
    Read();

    return true;
  }

  internal bool TakeAny(out char result, params char[] anyOf)
  {
    if (_kind != TokenKind.Punctuation || !anyOf.Contains(_operation.Span[_pos])) {
      result = '\0';
      return false;
    }

    result = _operation.Span[_pos++];
    Read();

    return true;
  }

  internal bool Take(string text)
  {
    if (_pos + text.Length > _len
      || !_operation.Slice(_pos, text.Length).ToString().Equals(text, StringComparison.InvariantCulture)
    ) {
      return false;
    }

    _pos += text.Length;
    Read();

    return true;
  }

  internal bool Prefix(char one, out string? identifier, out TokenAt at)
  {
    identifier = null;
    if (_kind == TokenKind.Punctuation
      && _operation.Span[_pos] == one
    ) {
      var next = _pos + 1;

      at = At;
      if (next < _len) {
        var code = _operation.Span[next] - ' ';
        if (code > 0
          && code < 95
          && _kinds[code] == TokenKind.Identifer
        ) {
          _pos += 1;
          _kind = TokenKind.Identifer;
          at = At;
          Identifier(out identifier);
          return true;
        }
      }

      return false;
    }

    at = At;
    return true;
  }

  internal TokenAt At
  => _kind switch {
    TokenKind.End => new(_kind, _pos - _lineStart, _line, "<END>"),
    TokenKind.Number => new(_kind, _pos - _lineStart, _line, GetString(Decimal(_pos))),
    TokenKind.Identifer => new(_kind, _pos - _lineStart, _line, GetString(Letters(_pos))),
    _ => new(_kind, _pos - _lineStart, _line, ErrorContext(_operation[_pos..].ToString().Replace("\r", ""))),
  };

  public static string ErrorContext(string context)
    => context.Length < ErrorContextLen ? context + "<END>" : context[..ErrorContextLen];

  internal readonly List<TokenMessage> Errors = [];

  internal TokenMessage Error(string text)
  {
    TokenMessage parseMessage = new(At, text);
    Errors.Add(parseMessage);
    return parseMessage;
  }

  internal TokenMessage Error(string label, string expected)
    => Error($"Invalid {label}. Expected {expected}.");

  internal IResult<T> Error<T>(string label, string expected)
    => 0.Error<T>(Error(label, expected));

  internal IResult<T> Error<T>(string label, string expected, T? result = default)
    => result.Error(Error(label, expected));

  internal IResultArray<T> ErrorArray<T>(string label, string expected, IEnumerable<T>? result = default)
    => result.ErrorArray(Error(label, expected));

  internal IResult<T> Partial<T>(string label, string expected, Func<T> result)
  {
    var error = Error(label, expected);
    return result().Partial(error);
  }

  internal IResultArray<T> PartialArray<T>(string label, string expected, Func<IEnumerable<T>> result)
  {
    var error = Error(label, expected);
    return result().PartialArray(error);
  }
}
