﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse;

internal class OperationParser : CommonParser
{
  internal readonly List<ArgumentAst> Variables = new();
  internal readonly List<SpreadAst> Spreads = new();

  public OperationParser(Tokenizer tokens)
    : base(tokens) { }

  internal OperationAst Parse()
  {
    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return new(_tokens.At) { Errors = new[] { _tokens.Error("Unexpected") } };
      }
    }

    var at = _tokens.At;
    OperationAst ast = new(at);

    if (_tokens.Identifier(out var category)) {
      if (_tokens.Identifier(out var name)) {
        ast = new(at, name) { Category = category };
      } else {
        ast.Category = category;
      }
    }

    if (ParseVariables(out VariableAst[] variables)) {
      ast.Variables = variables;
    }

    ast.Directives = ParseDirectives();
    ast.Fragments = ParseFragStart();
    if (_tokens.Prefix(':', out var result, out _)) {
      ast.ResultType = result;
      if (ParseArgument(out var argument)) {
        ast.Argument = argument;
      }
    } else if (ParseObject(out IAstSelection[] selections)) {
      ast.Object = selections;
    } else {
      Error("Operation", "Object or Type");
      return ast with {
        Errors = Errors.ToArray(),
        Usages = Variables.ToArray(),
        Spreads = Spreads.ToArray(),
      };
    }

    if (!ParseModifiers("Operation", out var modifiers)) {
      return ast with {
        Errors = Errors.ToArray(),
        Usages = Variables.ToArray(),
        Spreads = Spreads.ToArray(),
      };
    }

    ast.Modifiers = modifiers;
    ast.Fragments = ParseFragEnd(ast.Fragments);

    if (_tokens.AtEnd) {
      ast.Result = ParseResult.Success;
    } else {
      Error("Operation", "no more text");
    }

    return ast with {
      Errors = Errors.ToArray(),
      Usages = Variables.ToArray(),
      Spreads = Spreads.ToArray(),
    };
  }

  internal bool ParseVariables(out VariableAst[] variables)
  {
    variables = Array.Empty<VariableAst>();
    if (!_tokens.Take('(')) {
      return false;
    }

    var result = new List<VariableAst>();

    while (_tokens.Prefix('$', out var name, out var at)) {
      var variable = new VariableAst(at, name);

      if (_tokens.Take(':')
        && ParseVarType(out var varType)
      ) {
        variable.Type = varType;
      }

      if (!ParseModifiers("Variables", out var modifiers)) {
        return false;
      }

      variable.Modifers = modifiers;

      if (ParseDefault(out var constant)) {
        variable.Default = constant;
      }

      variable.Directives = ParseDirectives();

      result.Add(variable);
    }

    if (!result.Any()) {
      return Error("Variables", "at least one variable");
    }

    variables = result.ToArray();

    return Error("Variables", "')'.", _tokens.Take(')'));
  }

  internal bool ParseVarType(out string varType)
  {
    if (ParseVarNull(out var nullType)) {
      varType = _tokens.Take('!') ? nullType + '!' : nullType;
      return true;
    }

    varType = "";
    return false;
  }

  internal bool ParseVarNull(out string varNull)
  {
    if (_tokens.Take('[')) {
      if (ParseVarType(out var varType)
        && _tokens.Take(']')
      ) {
        varNull = "[" + varType + "]";
        return true;
      }

      varNull = "";
      return Error("Variable Type", "an inner variable type");
    } else {
      return _tokens.Identifier(out varNull);
    }
  }

  internal DirectiveAst[] ParseDirectives()
  {
    var directives = new List<DirectiveAst>();

    while (_tokens.Prefix('@', out var name, out var at)) {
      var directive = new DirectiveAst(at, name);
      if (ParseArgument(out ArgumentAst? argument)) {
        directive.Argument = argument;
      }

      directives.Add(directive);
    }

    return directives.ToArray();
  }

  internal bool ParseObject(out IAstSelection[] selections)
  {
    selections = Array.Empty<IAstSelection>();
    if (!_tokens.Take('{')) {
      return false;
    }

    var fields = new List<IAstSelection>();

    while (!_tokens.Take('}')) {
      if (ParseSelection(out IAstSelection fragment)) {
        fields.Add(fragment);
      } else if (ParseField(out IAstSelection field)) {
        fields.Add(field);
      } else {
        selections = fields.ToArray();

        return Error("Object", "a field or selection");
      }
    }

    selections = fields.ToArray();
    return Error("Object", "at least one field or selection", fields.Any());
  }

  internal bool ParseSelection(out IAstSelection selection)
  {
    selection = AstNulls.Selection;

    if (_tokens.Take("...") || _tokens.Take('|')) {
      var at = _tokens.At;
      string? onType = null;
      if (_tokens.Take("on") || _tokens.Take(':')) {
        if (!_tokens.Identifier(out onType)) {
          return Error("Spread", "a type");
        }
      } else {
        if (_tokens.Identifier(out var name)) {
          selection = new SpreadAst(at, name) { Directives = ParseDirectives() };
          Spreads.Add((SpreadAst)selection);
          return true;
        }
      }

      DirectiveAst[] directives = ParseDirectives();

      if (ParseObject(out IAstSelection[] selections)) {
        selection = new InlineAst(at, selections) {
          OnType = onType,
          Directives = directives,
        };
        return true;
      }

      return Error("Inline", "an object");
    }

    return false;
  }

  internal bool ParseField(out IAstSelection field)
  {
    var at = _tokens.At;
    field = AstNulls.Selection;

    if (!_tokens.Identifier(out var alias)) {
      return false;
    }

    var result = new FieldAst(at, alias);

    if (_tokens.Take(':')) {
      at = _tokens.At;
      if (!_tokens.Identifier(out var name)) {
        return Error("Field", "a name after an alias");
      }

      result = new FieldAst(at, name) { Alias = alias };
    }

    if (ParseArgument(out ArgumentAst argument)) {
      result.Argument = argument;
    }

    if (!ParseModifiers("Field", out var modifiers)) {
      return false;
    }

    result.Modifiers = modifiers;
    result.Directives = ParseDirectives();

    if (ParseObject(out IAstSelection[] selections)) {
      result.Selections = selections;
    }

    field = result;
    return true;
  }

  internal FragmentAst[] ParseFragStart()
    => ParseFragment(
        Array.Empty<FragmentAst>(),
        (ref Tokenizer tokens) => tokens.Take('&'),
        (ref Tokenizer tokens) => tokens.Take(':')
      );

  internal FragmentAst[] ParseFragEnd(FragmentAst[] initial)
    => ParseFragment(
        initial,
        (ref Tokenizer tokens) => tokens.Take("fragment") || tokens.Take('&'),
        (ref Tokenizer tokens) => tokens.Take("on") || tokens.Take(':')
      );

  private delegate bool Prefix(ref Tokenizer tokens);

  private FragmentAst[] ParseFragment(
    FragmentAst[] initial,
    Prefix fragPrefix,
    Prefix typePrefix)
  {
    var definitions = new List<FragmentAst>(initial);

    while (fragPrefix(ref _tokens)) {
      var at = _tokens.At;
      if (_tokens.Identifier(out var name)
        && typePrefix(ref _tokens)
        && _tokens.Identifier(out var onType)
      ) {
        DirectiveAst[] directives = ParseDirectives();
        if (ParseObject(out IAstSelection[] selections)) {
          var fragment = new FragmentAst(at, name, onType, selections) { Directives = directives };
          definitions.Add(fragment);
        }
      }
    }

    return definitions.ToArray();
  }

  internal bool ParseArgument(out ArgumentAst argument)
  {
    argument = new ArgumentAst(_tokens.At);

    if (!_tokens.Take('(')) {
      return false;
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      var at = _tokens.At;
      ArgumentAst value = new(at);
      if (ParseFieldKey(out var key)) {
        value = key;
        return _tokens.Take(':')
          ? ParseArgValue(out var item)
            ? ParseArgumentMid(at, new() { [key] = item }, out argument)
            : Error("Argument", "a value after field key separator")
          : ParseArgumentEnd(at, value, out argument);
      }

      return ParseArgValue(out value)
        && ParseArgumentEnd(at, value, out argument);
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }
  }

  internal bool ParseArgValue(out ArgumentAst argument)
  {
    var at = _tokens.At;
    argument = new ArgumentAst(at);

    if (_tokens.Prefix('$', out var variable, out at)) {
      argument = new ArgumentAst(at, variable);

      Variables.Add(argument);

      return true;
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      if (ParseArgList(out ArgumentAst[] list)) {
        argument = new ArgumentAst(at, list);
        return true;
      }

      if (ParseArgObject(out AstValues<ArgumentAst>.ObjectAst fields)) {
        argument = new ArgumentAst(at, fields);
        return true;
      }
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }

    if (ParseConstant(out ConstantAst constant)) {
      argument = constant;
      return true;
    }

    return false;
  }

  private ArgumentAst ParseArgValues(ArgumentAst initial)
  {
    var at = initial.At;
    var values = new List<ArgumentAst> { initial };
    while (_tokens.Take(',')) {
      if (ParseArgValue(out ArgumentAst value)) {
        values.Add(value);
      }
    }

    return values.Count > 1
      ? new(at, values.ToArray())
      : initial;
  }

  private bool ParseArgFieldValues(char end, ArgumentAst.ObjectAst fields)
  {
    var result = new ArgumentAst.ObjectAst(fields);
    fields.Clear();

    while (!_tokens.Take(end)) {
      if (ParseFieldKey(out var key)
        && _tokens.Take(':')
        && ParseArgValue(out var value)
      ) {
        result.Add(key, value);
      } else {
        return Error("Argument", "a field in object");
      }

      _tokens.Take(',');
    }

    foreach (var item in result) {
      fields.Add(item.Key, item.Value);
    }

    return true;
  }

  private bool ParseArgList(out ArgumentAst[] list)
  {
    list = Array.Empty<ArgumentAst>();

    if (!_tokens.Take('[')) {
      return false;
    }

    var values = new List<ArgumentAst>();
    while (!_tokens.Take(']')) {
      if (ParseArgValue(out var item)) {
        values.Add(item);
      } else {
        return Error("Argument", "a value in list");
      }

      _tokens.Take(',');
    }

    list = values.ToArray();
    return true;
  }

  private bool ParseArgObject(out ArgumentAst.ObjectAst fields)
  {
    fields = new ArgumentAst.ObjectAst();

    return _tokens.Take('{')
      && ParseArgFieldValues('}', fields);
  }

  private bool ParseArgumentMid(ParseAt at, ArgumentAst.ObjectAst fields, out ArgumentAst argument)
  {
    argument = new(at);

    if (_tokens.Take(',')) {
      if (ParseArgFieldValues(')', fields)) {
        argument = new ArgumentAst(at, fields);
        return true;
      }

      return Error("Argument", "a field after ','");
    }

    while (!_tokens.Take(')')) {
      if (ParseFieldKey(out var key1)
        && _tokens.Take(":")
        && ParseArgValue(out var item1)
      ) {
        fields.Add(key1, ParseArgValues(item1));
      } else {
        return Error("Argument", "a field");
      }
    }

    argument = new ArgumentAst(at, fields);
    return true;
  }

  private bool ParseArgumentEnd(ParseAt at, ArgumentAst value, out ArgumentAst argument)
  {
    var more = ParseArgValues(value);
    if (more.Values.Length > 1) {
      argument = more;
      return true;
    }

    var values = new List<ArgumentAst> { value };
    while (ParseArgValue(out var item)) {
      values.Add(item);
    }

    if (_tokens.Take(")")) {
      argument = values.Count > 1 ? new(at, values.ToArray()) : value;
      return true;
    }

    argument = new(at);
    return Error("Argument", "a value");
  }
}
