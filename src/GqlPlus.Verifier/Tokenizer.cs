namespace GqlPlus.Verifier;

internal ref struct Tokenizer
{
  internal const int ErrorContext = 10;

  private readonly ReadOnlySpan<char> _operation;
  private readonly int _len;
  private TokenKind _kind;
  private int _pos;

  private static readonly TokenKind[] _kinds = new TokenKind[96];
  private static readonly bool[] _identifier = new bool[75];
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
    _operation = operation.AsSpan();
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
    SkipWhitespace();

    if (_pos >= _len) {
      _kind = TokenKind.End;
      return false;
    }

    _kind = _kinds[_operation[_pos] - ' '];

    return true;
  }

  private void SkipWhitespace()
  {
    while (_pos < _len) {
      var code = _operation[_pos];

      if (code <= ' ' || code > '~'
        || IgnoreSeparators && (code == ';' || code == ',')
      ) {
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
    int code;
    do {
      if (++end >= _len) {
        _kind = TokenKind.End;
        break;
      }

      code = _operation[end] - '0';
      if (code is < 0 or > 74) {
        break;
      }
    } while (_identifier[code]);

    return end;
  }

  private string GetString(int end)
  {
    ReadOnlySpan<char> result = end < _len ? _operation[_pos..end] : _operation[_pos..];
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
    var len = _operation.Length;

    char code;
    do {
      if (++end >= len) {
        break;
      }

      code = _operation[end];
    } while (code is '_' or >= '0' and <= '9');
    return end;
  }

  private int Decimal(int end)
  {
    end = Digits(end);

    if (end < _len && _operation[end] == '.') {
      end = Digits(end);
    }

    return end;
  }

  internal bool String(out string contents)
  {
    contents = "";
    return _kind == TokenKind.String
      && Delimited(_operation[_pos], out contents);
  }

  internal bool Regex(out string regex)
  {
    regex = "";
    return _kind == TokenKind.Regex
      && Delimited('/', out regex);
  }

  private bool Delimited(char delimiter, out string contents)
  {
    var end = _pos;
    do {
      if (_operation[end] == '\\') {
        ++end;
      }

      ++end;
    } while (end < _len && _operation[end] != delimiter);

    _pos++;
    contents = GetString(end).Replace(@"\" + delimiter, delimiter.ToString()).Replace(@"\\", @"\");

    _pos = end + 1;
    Read();

    return end < _len;
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
    if (_pos + text.Length > _len
      || !_operation.Slice(_pos, text.Length).Equals(text, StringComparison.InvariantCulture)
    ) {
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

      if (next < _len) {
        var code = _operation[next] - ' ';
        if (code > 0 && code < 95 && _kinds[code] == TokenKind.Identifer) {
          _pos += 1;
          _kind = TokenKind.Identifer;
          return Identifier(out identifier);
        }
      }
    }

    identifier = "";
    return false;
  }

  internal ParseError Error(string text)
    => _kind switch {
      TokenKind.End => new(_kind, _pos, "<END>", text),
      TokenKind.Number => new(_kind, _pos, GetString(Decimal(_pos)), text),
      TokenKind.Identifer => new(_kind, _pos, GetString(Letters(_pos)), text),
      _ when _pos + ErrorContext < _len => new(_kind, _pos, _operation[_pos..(_pos + ErrorContext)].ToString(), text),
      _ => new(_kind, _pos, _operation[_pos..].ToString() + "<END>", text),
    };
}
