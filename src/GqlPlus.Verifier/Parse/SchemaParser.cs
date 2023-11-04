using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal class SchemaParser : CommonParser
{
  public SchemaParser(Tokenizer tokens)
    : base(tokens) { }

  private delegate bool Parser<T>(SchemaParser parser, string description, out T declaration);

  private readonly Dictionary<string, Parser<AstDescribed>> _parsers = new() {
    ["category"] = ParserFor((SchemaParser parser, string description, out CategoryAst result)
      => parser.ParseCategoryDeclaration(out result, description)),
    ["directive"] = ParserFor((SchemaParser parser, string description, out DirectiveAst result)
      => parser.ParseDirectiveDeclaration(out result, description)),
    ["enum"] = ParserFor((SchemaParser parser, string description, out EnumAst result)
      => parser.ParseEnumDeclaration(out result, description)),
    ["output"] = ParserFor((SchemaParser parser, string description, out OutputAst result)
      => parser.ParseOutputDeclaration(out result, description)),
    ["input"] = ParserFor((SchemaParser parser, string description, out InputAst result)
      => parser.ParseInputDeclaration(out result, description)),
    ["scalar"] = ParserFor((SchemaParser parser, string description, out ScalarAst result)
      => parser.ParseScalarDeclaration(out result, description)),
  };

  private static Parser<AstDescribed> ParserFor<T>(Parser<T> parser)
      where T : AstDescribed
    => (SchemaParser parent, string description, out AstDescribed declaration) => {
      var result = parser(parent, description, out T declared);
      declaration = declared;
      return result;
    };

  internal SchemaAst Parse()
  {
    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return new(_tokens.At) { Errors = new[] { _tokens.Error("Unexpected") } };
      }
    }

    var at = _tokens.At;
    SchemaAst ast = new(at);

    var declarations = new List<AstDescribed>();

    while (_tokens.Identifier(out var selector)) {
      if (_parsers.TryGetValue(selector, out var parser)) {
        if (parser(this, "", out var declaration)) {
          declarations.Add(declaration);
        }
      }
    }

    if (_tokens.AtEnd) {
      ast.Result = ParseResultKind.Success;
    } else {
      Error("Schema", "no more text");
    }

    return ast with {
      Declarations = declarations.ToArray(),
      Errors = Errors.ToArray(),
    };
  }

  internal bool ParseCategoryDeclaration(out CategoryAst result, string description)
  {
    var at = _tokens.At;
    result = new(at, "") { Description = description };

    at = _tokens.At;
    _tokens.Identifier(out var name);

    var prefix = ParsePrefix("Category");
    var categoryOption = ParseOption<CategoryOption>("Category");

    if (!prefix.Required(out var aliases) || categoryOption.IsError()) {
      return false;
    }

    if (_tokens.Identifier(out var output)) {
      if (string.IsNullOrEmpty(name)) {
        name = output.Camelize();
      }

      categoryOption.Required(out var option);

      result = new(at, name!, output) {
        Aliases = aliases,
        Option = option
      };
      return true;
    }

    return Error("Category", "output type");
  }

  private IResult<O> ParseOption<O>(string label)
    where O : struct
  {
    if (_tokens.Take('(')) {
      var enumValue = ParseEnumValue<O>(label);

      return enumValue.Required(out var result)
        ? _tokens.Take(')')
          ? enumValue
          : Partial(label, "')' after option", () => result)
        : enumValue;
    }

    return new ResultEmpty<O>();
  }

  private IResult<E> ParseEnumValue<E>(string label)
    where E : struct
    => _tokens.Identifier(out var option)
      ? Enum.TryParse<E>(option, true, out var result)
        ? result.Ok()
        : Error(label, "valid enum value", result)
      : new ResultEmpty<E>();

  internal bool ParseDirectiveDeclaration(out DirectiveAst result, string description)
  {
    if (!_tokens.Prefix('@', out var name, out var at)) {
      result = new(AstNulls.At, name ?? "", description);
      return Error("Directive", "'@' name");
    }

    result = new(at, name!, description);

    if (ParseParameter().Required(out var parameter)) {
      result.Parameter = parameter;
    }

    var prefix = ParsePrefix("Directive");
    var directiveOption = ParseOption<DirectiveOption>("Directive");

    if (!prefix.Required(out var aliases) || directiveOption.IsError()) {
      return false;
    }

    result.Aliases = aliases;
    if (directiveOption.Required(out var option)) {
      result.Option = option;
    }

    var directiveLocation = ParseEnumValue<DirectiveLocation>("Directive");
    if (!directiveLocation.Required(out var location)) {
      return Error("Directive", "at least one location");
    }

    result.Locations = location;

    while (_tokens.Take("|")) {
      directiveLocation = ParseEnumValue<DirectiveLocation>("Directive");
      if (directiveLocation.Required(out location)) {
        result.Locations |= location;
      } else {
        return Error("Directive", "location after '|'");
      }
    }

    return true;
  }

  internal bool ParseEnumDeclaration(out EnumAst result, string description)
  {
    var at = _tokens.At;
    var hasName = _tokens.Identifier(out var name);
    result = new(at, name, description);

    if (!hasName) {
      return Error("Enum", "name");
    }

    if (!ParsePrefix("Enum").Required(out var aliases)) {
      return false;
    }

    result.Aliases = aliases;

    if (_tokens.Take(':')) {
      if (_tokens.Identifier(out var extends)) {
        result.Extends = extends;
      } else {
        return Error("Enum", "type after ':'");
      }
    }

    if (ParseEnumLabel().Required(out var label)) {
      List<EnumLabelAst> labels = new() { label };

      while (_tokens.Take("|")) {
        if (ParseEnumLabel().Required(out label)) {
          labels.Add(label);
        } else {
          return Error("Enum", "label");
        }
      }

      result.Labels = labels.ToArray();
      return true;
    }

    return Error("Enum", "label");
  }

  private IResult<EnumLabelAst> ParseEnumLabel()
  {
    _tokens.String(out var description);
    var at = _tokens.At;

    if (!_tokens.Identifier(out var label)) {
      return Error<EnumLabelAst>("Enum", "label");
    }

    var enumAliases = ParseAliases("Enum");

    var enumLabel = enumAliases.Required(out var aliases)
      ? new EnumLabelAst(at, label, description) { Aliases = aliases }
      : new EnumLabelAst(at, label, description);

    return enumAliases.AsPartial(enumLabel, Errors.Add);
  }

  private bool ParseObject<O, F, R>(out O result, string description, IObjectParser<O, F, R> factories)
    where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
  {
    var at = _tokens.At;
    var getName = _tokens.Identifier(out var name);

    result = factories.Object(at, name, description);
    if (!getName) {
      return Error(factories.Label, "name");
    }

    if (!ParseTypeParameters(factories.Label).Required(out var parameters)) {
      return false;
    }

    result.Parameters = parameters;

    if (!ParsePrefix(factories.Label).Required(out var aliases)) {
      return false;
    }

    result.Aliases = aliases;

    _tokens.String(out var descr);
    var baseReference = ParseReference(factories, descr);
    if (baseReference.IsError(Errors.Add)) {
      return false;
    }

    baseReference.Required(out var reference);

    if (_tokens.Take('{')) {
      var fields = new List<F>();
      while (!_tokens.Take('}')) {
        if (ParseField(out var field, factories)) {
          fields.Add(field);
        } else {
          return Error(factories.Label, "more fields or '}'");
        }
      }

      if (reference is not null) {
        result.Extends = reference with { Description = descr };
      }

      result.Fields = fields.ToArray();
      if (!ParseAlternates(out var alternates, factories)) {
        return false;
      }

      result.Alternates = alternates;
    } else if (reference is not null) {
      if (!ParseAlternates(out var alternates, factories, reference)) {
        return false;
      }

      result.Alternates = alternates;
    }

    return true;
  }

  private bool ParseAlternates<R>(out R[] alternates, IReferenceParser<R> factories, params R[] initial)
    where R : AstReference<R>
  {
    var result = new List<R>(initial);
    while (_tokens.Take('|')) {
      _tokens.String(out var descr);
      if (ParseReference(factories, descr).Required(out var alternate)) {
        result.Add(alternate);
      } else {
        alternates = result.ToArray();
        return Error(factories.Label, "reference after '|'");
      }
    }

    alternates = result.ToArray();
    return true;
  }

  internal bool ParseField<F, R>(out F field, IFieldParser<F, R> parser)
    where F : AstField<R> where R : AstReference<R>
  {
    var at = _tokens.At;
    _tokens.String(out var description);
    if (!_tokens.Identifier(out var name)) {
      field = parser.NullField();
      return Error(parser.Label, "field name");
    }

    var hasParameter = parser.FieldParameter();
    if (hasParameter.IsError() || !ParseAliases(parser.Label).Required(out var aliases)) {
      field = parser.NullField();
      return false;
    }

    field = parser.Field(at, name, description, parser.Reference(at, ""));

    if (_tokens.Take(':')) {
      _tokens.String(out var descr);
      if (ParseReference(parser, descr).Required(out var fieldType)) {
        field = parser.Field(at, name, description, fieldType);
        field.Aliases = aliases;
        if (hasParameter.Required(out var parameter)) {
          parser.ApplyParameter(field, parameter);
        }

        var modifiers = ParseModifiers("Operation");

        if (modifiers.IsError()) {
          return false;
        }

        if (modifiers.Optional(out var value)) {
          field.Modifiers = value ?? Array.Empty<ModifierAst>();
        }

        return parser.FieldDefault(field).Required(out var _);
      }

      return Error(parser.Label, "field type");
    }

    return Error(parser.Label, "field details", parser.FieldEnumLabel(field).Required(out var _));
  }

  internal IResult<R> ParseReference<R>(IReferenceParser<R> factories, string description, bool isTypeArgument = false)
    where R : AstReference<R>
  {
    if (!_tokens.Prefix('$', out var param, out var at)) {
      return Error<R>(factories.Label, "identifier after '$'");
    }

    if (param is not null) {
      var reference = factories.Reference(at, param) with {
        Description = description,
        IsTypeParameter = true,
      };
      return reference.Ok();
    }

    at = _tokens.At;

    if (_tokens.Identifier(out var name)) {
      var reference = factories.Reference(at, name) with { Description = description };
      if (_tokens.Take('<')) {
        var arguments = new List<R>();
        _tokens.String(out var descr);
        var referenceArgument = ParseReference(factories, descr, isTypeArgument: true);
        while (referenceArgument.Required(out var argument)) {
          arguments.Add(argument);
          _tokens.String(out descr);
          referenceArgument = ParseReference(factories, descr, isTypeArgument: true);
        }

        reference.Arguments = arguments.ToArray();

        if (!_tokens.Take('>')) {
          return Error(factories.Label, "'>' after type argument(s)", reference);
        } else if (arguments.Count < 1) {
          return Error(factories.Label, "at least one type argument after '<'", reference);
        }
      } else if (isTypeArgument) {
        return factories.TypeEnumLabel(reference);
      }

      return reference.Ok();
    }

    return new ResultEmpty<R>();
  }

  internal bool ParseOutputDeclaration(out OutputAst output, string description)
   => ParseObject(out output, description, new OutputParserFactories(this));

  internal IResult<OutputReferenceAst> ParseOutputEnumLabel(OutputReferenceAst reference)
  {
    if (_tokens.Take('.')) {
      if (_tokens.Identifier(out var label)) {
        reference.Label = label;
        return reference.Ok();
      }

      return Error("Output", "label after '.'", reference);
    }

    return reference.Ok();
  }

  internal IResult<OutputFieldAst> ParseOutputFieldLabel(OutputFieldAst field)
  {
    if (_tokens.Take('=')) {
      var at = _tokens.At;

      if (!_tokens.Identifier(out var label)) {
        return Error("Output", "label after '='", field);
      }

      if (!_tokens.Take('.')) {
        field.Label = label;
        return field.Ok();
      }

      if (_tokens.Identifier(out var value)) {
        field.Type = new OutputReferenceAst(at, label);
        field.Label = value;
        return field.Ok();
      }

      return Error("Output", "label after '.'", field);
    }

    return Error("Output", "':' or '='", field);
  }

  internal IResult<ParameterAst> ParseParameter()
  {
    if (!_tokens.Take('(')) {
      return new ResultEmpty<ParameterAst>();
    }

    _tokens.String(out var descr);
    var at = _tokens.At;
    if (!ParseReference(new InputParserFactories(this), descr).Required(out var reference)) {
      return Error<ParameterAst>("Parameter", "input reference after '('");
    }

    var parameter = new ParameterAst(at, reference);
    var modifiers = ParseModifiers("Operation");

    if (modifiers.IsError(Errors.Add)) {
      return modifiers.AsResult(parameter);
    }

    if (modifiers.Optional(out var value)) {
      parameter.Modifiers = value ?? Array.Empty<ModifierAst>();
    }

    if (ParseDefault().Required(out var constant)) {
      parameter.Default = constant;
    }

    return _tokens.Take(')') ? parameter.Ok() : Partial("Parameter", "')' at end", () => parameter);
  }

  internal bool ParseInputDeclaration(out InputAst output, string description)
   => ParseObject(out output, description, new InputParserFactories(this));

  private IResultArray<string> ParseAliases(string label)
  {
    var aliases = new List<string>();
    if (_tokens.Take('[')) {
      while (_tokens.Identifier(out var alias)) {
        aliases.Add(alias);
      }

      if (!_tokens.Take("]")) {
        return PartialArray(label, "']' to end aliases", () => aliases);
      } else if (aliases.Count == 0) {
        return ErrorArray(label, "at least one alias after '['", aliases);
      }
    }

    return aliases.OkArray();
  }

  private IResultArray<string> ParsePrefix(string label)
  {
    var aliases = ParseAliases(label);
    return !aliases.Required(out var result)
      ? aliases.AsResultArray(label)
      : _tokens.Take('=') ? result.OkArray() : ErrorArray(label, "'=' before definition", result);
  }

  private IResultArray<TypeParameterAst> ParseTypeParameters(string label)
  {
    var result = new List<TypeParameterAst>();

    if (_tokens.Take('<')) {
      while (!_tokens.Take('>')) {
        _tokens.String(out var description);
        if (_tokens.Prefix('$', out var name, out var at) && name is not null) {
          result.Add(new(at, name, description));
        } else {
          return PartialArray(label, "type parameter", () => result);
        }
      }

      if (result.Count == 0) {
        return ErrorArray(label, "at least one type parameter after '<'", result);
      }
    }

    return result.OkArray();
  }

  internal bool ParseScalarDeclaration(out ScalarAst result, string description)
  {
    var at = _tokens.At;
    var hasName = _tokens.Identifier(out var name);
    result = new(at, name, description);

    if (!hasName) {
      return Error("Scalar", "name");
    }

    if (!ParsePrefix("Scalar").Required(out var aliases)) {
      return false;
    }

    result.Aliases = aliases;

    if (!ParseEnumValue<ScalarKind>("Scalar").Required(out var kind)) {
      return false;
    }

    result.Kind = kind;

    switch (kind) {
      case ScalarKind.Number:
        if (ParseRanges().Required(out var ranges)) {
          result.Ranges = ranges;
        }

        break;
      case ScalarKind.String:
        if (ParseRegexes().Required(out var regexes)) {
          result.Regexes = regexes;
        }

        break;
      default:
        return Error("Scalar", "valid kind");
    }

    return true;
  }

  private IResultArray<ScalarRangeAst> ParseRanges()
  {
    var result = new List<ScalarRangeAst>();
    while (ParseRange().Required(out var range)) {
      result.Add(range);
    }

    return result.OkArray();
  }

  private IResult<ScalarRangeAst> ParseRange()
  {
    var at = _tokens.At;
    var range = new ScalarRangeAst(at);
    var hasLower = _tokens.Number(out var min);
    var excludesLower = _tokens.Take('>');
    if (!_tokens.Take("..") && hasLower) {
      return Error("Scalar", "range operator ('..')", range);
    }

    var excludesUpper = _tokens.Take('<');
    var hasUpper = _tokens.Number(out var max);

    if (hasLower) {
      range.Lower = min;
      range.LowerExcluded = excludesLower;
    }

    if (hasUpper) {
      range.Upper = max;
      range.UpperExcluded = excludesUpper;
    }

    return hasLower || hasUpper ? range.Ok() : range.Empty();
  }

  private IResultArray<ScalarRegexAst> ParseRegexes()
  {
    var result = new List<ScalarRegexAst>();
    var at = _tokens.At;

    while (_tokens.Regex(out var regex)) {
      var excluded = _tokens.Take('!');
      result.Add(new(at, regex, excluded));
      at = _tokens.At;
    }

    return result.OkArray();
  }
}
