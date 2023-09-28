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
  internal bool At(params char[] anyOf) => _kind == TokenKind.Punctuation && anyOf.Contains(_operation[_pos]);
  internal bool At(string text) => _pos + text.Length <= _operation.Length && _operation.Slice(_pos, text.Length) == text;
  internal bool AtEnd => _kind == TokenKind.End;

  internal bool Read()
  {
    if (_pos >= _operation.Length) {
      _kind = TokenKind.End;
      return false;
    }

    SkipWhitespace();

    _kind = _operation[_pos] switch {
      >= 'A' and <= 'Z' or >= 'a' and <= 'z' or '_' => TokenKind.Identifer,
      >= '0' and <= '9' or '-' => TokenKind.Number,
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

  internal string? TakeIdentifier()
  {
    if (_kind != TokenKind.Identifer) {
      return null;
    }

    var end = _pos;
    do {
      ++end;
    } while (end < _operation.Length && _operation[end] is >= 'A' and <= 'Z' or >= 'a' and <= 'z' or >= '0' and <= '9' or '_');

    ReadOnlySpan<char> result = end < _operation.Length ? _operation[_pos..end] : _operation[_pos..];

    _pos = end;

    Read();

    return result.ToString();
  }

  internal int TakeNumber()
  {
    var end = _pos;
    do {
      ++end;
    } while (end < _operation.Length && _operation[end] is >= '0' and <= '9');

    ReadOnlySpan<char> result = end < _operation.Length ? _operation[_pos..end] : _operation[_pos..];

    _pos = end;

    Read();

    return int.Parse(result);
  }

  internal char? Take(params char[] c)
  {
    if (_kind != TokenKind.Punctuation || !c.Contains(_operation[_pos])) {
      return null;
    }

    var result = _operation[_pos++];
    Read();

    return result;
  }
}
