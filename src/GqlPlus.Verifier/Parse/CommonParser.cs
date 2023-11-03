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

  internal IResult<FieldKeyAst> ParseFieldKey()
  {
    var at = _tokens.At;
    if (_tokens.Number(out var number)) {
      return new FieldKeyAst(at, number).Ok();
    }

    if (_tokens.String(out var contents)) {
      return new FieldKeyAst(at, contents).Ok();
    }

    if (_tokens.Identifier(out var identifier)) {
      if (_tokens.Take('.')) {
        return _tokens.Identifier(out var label)
          ? new FieldKeyAst(at, identifier, label).Ok()
          : Error<FieldKeyAst>("FieldKey", "label after '.'");
      }

      var type = _labelTypes.GetValueOrDefault(identifier, "");
      return new FieldKeyAst(at, type, identifier).Ok();
    }

    return new ResultEmpty<FieldKeyAst>();
  }

  internal IResultArray<ModifierAst> ParseModifiers(string label)
  {
    var list = new List<ModifierAst>();

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
        list.Add(modifier);
      } else {
        return PartialArray(label, "']' at end of list or dictionary modifier.", list);
      }

      at = _tokens.At;
    }

    if (_tokens.Take('?')) {
      list.Add(ModifierAst.Optional(at));
    }

    return list.OkArray();
  }

  internal IResult<ConstantAst> ParseDefault() => _tokens.Take('=') ? ParseConstant() : new ResultEmpty<ConstantAst>();

  internal IResult<ConstantAst> ParseConstant()
  {
    var at = _tokens.At;

    if (ParseFieldKey().Required(out var fieldKey)) {
      return new ConstantAst(fieldKey).Ok();
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      var list = ParseConstList();
      return list.Required(out var theList)
        ? new ConstantAst(at, theList).Ok()
        : list.IsError()
        ? list.AsResult<ConstantAst, ConstantAst>()
        : ParseConstObject().Required(out AstValues<ConstantAst>.ObjectAst? fields)
        ? new ConstantAst(at, fields).Ok()
        : new ResultEmpty<ConstantAst>();
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }
  }

  private IResultArray<ConstantAst> ParseConstList()
  {
    var list = new List<ConstantAst>();

    if (!_tokens.Take('[')) {
      return list.EmptyArray();
    }

    while (!_tokens.Take(']')) {
      if (ParseConstant().Required(out var item)) {
        list.Add(item);
      } else {
        return PartialArray("Constant", "value in list", list);
      }

      _tokens.Take(',');
    }

    return list.OkArray();
  }

  private IResult<ConstantAst.ObjectAst> ParseConstObject()
  {
    var fields = new ConstantAst.ObjectAst();

    if (!_tokens.Take('{')) {
      return fields.Empty();
    }

    while (!_tokens.Take('}')) {
      if (ParseFieldKey().Required(out var key)
        && _tokens.Take(':')
        && ParseConstant().Required(out var value)
      ) {
        fields.Add(key, value);
      } else {
        return Error("Constant", "field in object", fields);
      }

      _tokens.Take(',');
    }

    return fields.Ok();
  }

  protected bool Error(string label, string message, bool result = false)
  {
    if (!result) {
      Errors.Add(_tokens.Error($"Invalid {label}. Expected {message}."));
    }

    return result;
  }

  protected IResultArray<T> ErrorArray<T>(string label, string message, IEnumerable<T>? _ = default)
  {
    var error = _tokens.Error(label, message);
    Errors.Add(error);
    return new ResultArrayError<T>(error);
  }

  protected IResult<T> Error<T>(string label, string message, T? _ = default)
  {
    var error = _tokens.Error(label, message);
    Errors.Add(error);
    return new ResultError<T>(error);
  }

  protected IResultArray<T> PartialArray<T>(string label, string message, IEnumerable<T> result)
  {
    var error = _tokens.Error(label, message);
    Errors.Add(error);
    return new ResultArrayPartial<T>(result.ToArray(), error);
  }

  protected IResult<T> Partial<T>(string label, string message, T result)
  {
    var error = _tokens.Error(label, message);
    Errors.Add(error);
    return new ResultPartial<T>(result, error);
  }
}
