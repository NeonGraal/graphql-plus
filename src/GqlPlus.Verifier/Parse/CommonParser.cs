using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

internal class CommonParser
{
  internal readonly List<ParseMessage> Errors = new();

  protected Tokenizer _tokens;

  public CommonParser(Tokenizer tokens)
    => _tokens = tokens;

  private readonly Dictionary<string, string> _labelTypes = new() {
    ["_"] = "Unit",
    ["null"] = "Null",
    ["true"] = "Boolean",
    ["false"] = "Boolean",
  };

  internal bool ParseFieldKey(out FieldKeyAst constant)
  {
    var at = _tokens.At;
    constant = new FieldKeyAst(at);

    if (_tokens.Number(out var number)) {
      constant = new FieldKeyAst(at, number);
      return true;
    }

    if (_tokens.String(out var contents)) {
      constant = new FieldKeyAst(at, contents);
      return true;
    }

    if (_tokens.Identifier(out var identifier)) {
      if (_tokens.Take('.')) {
        if (_tokens.Identifier(out var label)) {
          constant = new FieldKeyAst(at, identifier, label);
          return true;
        }

        return false;
      }

      var type = _labelTypes.GetValueOrDefault(identifier, "");
      constant = new FieldKeyAst(at, type, identifier);
      return true;
    }

    return false;
  }

  internal IParseResult<ModifierAst[]> ParseModifiers(string label)
  {
    var result = new List<ModifierAst>();

    var at = _tokens.At;
    while (_tokens.Take('[')) {
      var modifier = ModifierAst.List(at);
      if (_tokens.Identifier(out var key)) {
        modifier = new(at, key, _tokens.Take('?'));
      } else {
        if (_tokens.TakeAny(out var charType, '~', '0', '*')) {
          modifier = new(at, charType.ToString(), _tokens.Take('?'));
        }
      }

      if (_tokens.Take(']')) {
        result.Add(modifier);
      } else {
        return Error<ModifierAst[]>(label, "']' at end of list or dictionary modifier.");
      }

      at = _tokens.At;
    }

    if (_tokens.Take('?')) {
      result.Add(ModifierAst.Optional(at));
    }

    return result.Ok();
  }

  internal bool ParseDefault(out ConstantAst? constant)
  {
    if (_tokens.Take('=')) {
      return ParseConstant(out constant);
    }

    constant = default;
    return true;
  }

  internal bool ParseConstant(out ConstantAst constant)
  {
    var at = _tokens.At;
    constant = new ConstantAst(at);

    if (ParseFieldKey(out FieldKeyAst fieldKey)) {
      constant = fieldKey;
      return true;
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      if (ParseConstList(out ConstantAst[] list)) {
        constant = new ConstantAst(at, list);
        return true;
      }

      if (ParseConstObject(out AstValues<ConstantAst>.ObjectAst fields)) {
        constant = new ConstantAst(at, fields);
        return true;
      }

      return false;
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }
  }

  private bool ParseConstList(out ConstantAst[] list)
  {
    list = Array.Empty<ConstantAst>();

    if (!_tokens.Take('[')) {
      return false;
    }

    var values = new List<ConstantAst>();
    while (!_tokens.Take(']')) {
      if (ParseConstant(out var item)) {
        values.Add(item);
      } else {
        return Error("Constant", "value in list");
      }

      _tokens.Take(',');
    }

    list = values.ToArray();
    return true;
  }

  private bool ParseConstObject(out ConstantAst.ObjectAst fields)
  {
    fields = new ConstantAst.ObjectAst();
    if (!_tokens.Take('{')) {
      return false;
    }

    while (!_tokens.Take('}')) {
      if (ParseFieldKey(out var key)
        && _tokens.Take(':')
        && ParseConstant(out var value)
      ) {
        fields.Add(key, value);
      } else {
        Error("Constant", "field in object");
        return false;
      }

      _tokens.Take(',');
    }

    return true;
  }

  protected bool Error(string label, string message, bool result = false)
  {
    if (!result) {
      Errors.Add(_tokens.Error($"Invalid {label}. Expected {message}."));
    }

    return result;
  }

  protected IParseResult<T> Error<T>(string label, string message)
    => new ParseError<T>(_tokens.Error(label, message));
}
