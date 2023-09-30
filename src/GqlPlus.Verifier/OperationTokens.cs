namespace GqlPlus.Verifier;

internal ref struct OperationTokens
{
  private readonly ReadOnlySpan<char> _operation;
  private TokenKind _kind;
  private int _pos;
  private readonly bool _ignoreSeparators;

  internal OperationTokens(string operation)
  {
    _operation = operation.AsSpan();

    _kind = TokenKind.Start;
    _pos = 0;
    _ignoreSeparators = true;
  }

  internal bool AtStart => _kind == TokenKind.Start;
  internal bool AtIdentifier => _kind == TokenKind.Identifer;
  internal bool AtNumber => _kind == TokenKind.Number;
  public bool AtString => _kind == TokenKind.String;
  public bool AtRegex => _kind == TokenKind.Regex;
  internal bool At(params char[] anyOf) => _kind == TokenKind.Punctuation && anyOf.Contains(_operation[_pos]);
  internal bool At(string text) =>
    _pos + text.Length <= _operation.Length &&
    _operation.Slice(_pos, text.Length).Equals(text, StringComparison.InvariantCulture);
  internal bool AtEnd => _kind == TokenKind.End;


  internal bool Read()
  {
    SkipWhitespace();

    if (_pos >= _operation.Length) {
      _kind = TokenKind.End;
      return false;
    }

    _kind = _operation[_pos] switch {
      >= 'A' and <= 'Z' or >= 'a' and <= 'z' or '_' => TokenKind.Identifer,
      >= '0' and <= '9' or '-' => TokenKind.Number,
      '"' or '\'' => TokenKind.String,
      '/' => TokenKind.Regex,
      _ => TokenKind.Punctuation,
    };

    return true;
  }

  private void SkipWhitespace()
  {
    while (_pos < _operation.Length) {
      var code = _operation[_pos];

      switch (code) {
        case '\r':
          if (++_pos < _operation.Length && _operation[_pos] == '\n') {
            ++_pos;
          }

          break;
        case ' ':
        case '\t':
          ++_pos;
          break;
        case ',':
        case ';':
          if (!_ignoreSeparators) {
            return;
          }

          ++_pos;
          break;
        default:
          return;
      }
    }
  }

  internal bool Identifier(out string identifier)
  {
    identifier = "";
    if (_kind != TokenKind.Identifer) {
      return false;
    }

    var end = _pos;
    do {
      ++end;
    } while (end < _operation.Length && _operation[end] is >= 'A' and <= 'Z' or >= 'a' and <= 'z' or >= '0' and <= '9' or '_');

    ReadOnlySpan<char> result = end < _operation.Length ? _operation[_pos..end] : _operation[_pos..];
    identifier = result.ToString();

    _pos = end;
    Read();

    return true;
  }

  internal bool Number(out int number)
  {
    var end = _pos;
    do {
      ++end;
    } while (end < _operation.Length && _operation[end] is >= '0' and <= '9');

    ReadOnlySpan<char> result = end < _operation.Length ? _operation[_pos..end] : _operation[_pos..];
    number = int.Parse(result);

    _pos = end;
    Read();

    return true;
  }

  internal bool String(out string contents)
  {
    contents = "";
    if (_kind != TokenKind.String) {
      return false;
    }

    return Delimited(_operation[_pos], out contents);
  }

  internal bool Regex(out string regex)
  {
    regex = "";
    if (_kind != TokenKind.Regex) {
      return false;
    }

    return Delimited('/', out regex);
  }

  private bool Delimited(char delimiter, out string contents)
  {
    var end = _pos;
    do {
      if (_operation[end] == '\\') {
        ++end;
      }
      ++end;
    } while (end < _operation.Length && _operation[end] != delimiter);

    var start = _pos + 1;
    ReadOnlySpan<char> result = end < _operation.Length ? _operation[start..end] : _operation[start..];
    contents = result.ToString();

    _pos = end + 1;
    Read();

    return end < _operation.Length;
  }

  internal bool Take(char one)
  {
    if (_kind != TokenKind.Punctuation || _operation[_pos] != one) {
      return false;
    }

    _pos++;
    Read();

    return true;
  }

  internal bool TakeAny(out char result, params char[] anyOf)
  {
    if (_kind != TokenKind.Punctuation || !anyOf.Contains(_operation[_pos])) {
      result = '\0';
      return false;
    }

    result = _operation[_pos++];
    Read();

    return true;
  }

  internal bool Take(string text)
  {
    if (!At(text)) {
      return false;
    }

    _pos += text.Length;
    Read();

    return true;
  }

  internal bool Prefix(char one, out string identifier)
  {
    if (_kind == TokenKind.Punctuation && _operation[_pos] == one) {
      var next = _pos + 1;

      if (next < _operation.Length &&
        _operation[next] is >= 'A' and <= 'Z' or >= 'a' and <= 'z' or '_'
      ) {
        _pos += 1;
        _kind = TokenKind.Identifer;
        return Identifier(out identifier);
      }
    }

    identifier = "";
    return false;
  }
}
