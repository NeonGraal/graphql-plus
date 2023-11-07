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
        return PartialArray(label, "']' at end of list or dictionary modifier.", () => list);
      }

      at = _tokens.At;
    }

    if (_tokens.Take('?')) {
      list.Add(ModifierAst.Optional(at));
    }

    return list.OkArray();
  }

  internal IResult<ConstantAst> ParseDefault()
    => _tokens.Take('=') ? ParseConstant() : new ResultEmpty<ConstantAst>();

  internal IResult<ConstantAst> ParseConstant()
  {
    var at = _tokens.At;

    var fieldKey = ParseFieldKey();
    if (fieldKey.HasValue()) {
      return fieldKey.Select(value => new ConstantAst(value));
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      var list = ParseConstList();
      return list.Required(out var theList)
        ? new ConstantAst(at, theList).Ok()
        : list.IsError()
          ? list.AsResult(AstNulls.Constant)
          : ParseConstObject().Select(fields => new ConstantAst(at, fields));
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
      var constant = ParseConstant();
      if (!constant.Required(list.Add)) {
        return PartialArray("Constant", "value in list", () => list);
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
      var field = ParseField("Constant", ParseConstant);

      if (!field.Required(value => fields.Add(value.Key, value.Value))) {
        return field.AsResult(fields);
      }

      _tokens.Take(',');
    }

    return fields.Ok();
  }

  internal IResult<Field<T>> ParseField<T>(string label, Func<IResult<T>> parseValue)
    where T : AstValues<T>
  {
    var fieldKey = ParseFieldKey();
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<Field<T>>();
    }

    if (!_tokens.Take(':')) {
      return Error<Field<T>>(label, "':' after key");
    } else if (!fieldKey.IsOk()) {
      return Error<Field<T>>(label, "key before ':'");
    }

    var fieldValue = parseValue();
    return fieldValue.SelectOk(value => new Field<T>(fieldKey.Required(), value));
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

  protected IResultArray<T> PartialArray<T>(string label, string message, Func<IEnumerable<T>> result)
  {
    var error = _tokens.Error(label, message);
    Errors.Add(error);
    return new ResultArrayPartial<T>(result().ToArray(), error);
  }

  protected IResult<T> Partial<T>(string label, string message, Func<T> result)
  {
    var error = _tokens.Error(label, message);
    Errors.Add(error);
    return new ResultPartial<T>(result(), error);
  }
}

internal record struct Field<T>(FieldKeyAst Key, T Value)
  where T : AstValues<T>;
