using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal class SchemaParser : CommonParser
{
  public SchemaParser(Tokenizer tokens)
    : base(tokens) { }

  private delegate IResult<T> Parser<T>(SchemaParser parser, string description);
  private readonly Dictionary<string, Parser<AstDescribed>> _parsers = new() {
    ["category"] = (parser, description)
      => parser.ParseCategoryDeclaration(description).AsResult<AstDescribed>(),
    ["directive"] = (parser, description)
      => parser.ParseDirectiveDeclaration(description).AsResult<AstDescribed>(),
    ["enum"] = (parser, description)
      => parser.ParseEnumDeclaration(description).AsResult<AstDescribed>(),
    ["output"] = (parser, description)
      => parser.ParseOutputDeclaration(description).AsResult<AstDescribed>(),
    ["input"] = (parser, description)
      => parser.ParseInputDeclaration(description).AsResult<AstDescribed>(),
    ["scalar"] = (parser, description)
      => parser.ParseScalarDeclaration(description).AsResult<AstDescribed>(),
  };

  internal IResult<SchemaAst> Parse()
  {
    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return Error<SchemaAst>("Schema", "text");
      }
    }

    var at = _tokens.At;
    SchemaAst ast = new(at);

    var declarations = new List<AstDescribed>();

    while (_tokens.Identifier(out var selector)) {
      if (_parsers.TryGetValue(selector, out var parser)) {
        var declaration = parser(this, "");
        declaration.WithMessage(Errors.Add);
        declaration.WithResult(declarations.Add);
      } else {
        Error("Schema", $"declaration selector. '{selector}' unknown");
      }
    }

    if (!_tokens.AtEnd) {
      Error("Schema", "no more text");
    }

    if (Errors.Count == 0) {
      ast.Result = ParseResultKind.Success;
    }

    ast = ast with {
      Declarations = declarations.ToArray(),
      Errors = Errors.ToArray(),
    };

    return ast.Ok();
  }

  internal IResult<CategoryAst> ParseCategoryDeclaration(string description)
  {
    var at = _tokens.At;
    _tokens.Identifier(out var name);
    CategoryAst result = new(at, name, "") { Description = description };

    var prefix = ParsePrefix("Category");
    if (!prefix.Optional(aliases => result.Aliases = aliases)) {
      return prefix.AsResult(result);
    }

    var categoryOption = ParseOption<CategoryOption>("Category");
    if (!categoryOption.Optional(option => result.Option = option)) {
      return categoryOption.AsResult(result);
    }

    if (_tokens.Identifier(out var output)) {
      if (string.IsNullOrEmpty(name)) {
        name = output.Camelize();
      }

      result = result with { Name = name!, Output = output };

      return End("Category", () => result);
    }

    return Partial("Category", "output type", () => result);
  }

  internal IResult<DirectiveAst> ParseDirectiveDeclaration(string description)
  {
    var hasPrefix = _tokens.Prefix('@', out var name, out var at);
    DirectiveAst result = new(at, name!, description);
    if (!hasPrefix) {
      return Error("Directive", "'@' name", result);
    }

    var parameter = ParseParameter();
    if (!parameter.Optional(parameter => result.Parameter = parameter)) {
      return parameter.AsResult(result);
    }

    var prefix = ParsePrefix("Directive");
    if (!prefix.Optional(aliases => result.Aliases = aliases)) {
      return prefix.AsResult(result);
    }

    var directiveOption = ParseOption<DirectiveOption>("Directive");
    if (!directiveOption.Optional(option => result.Option = option)) {
      return directiveOption.AsResult(result);
    }

    while (!_tokens.Take("}")) {
      var directiveLocation = ParseEnumValue<DirectiveLocation>("Directive");
      if (!directiveLocation.Required(location => result.Locations |= location)) {
        return Error("Directive", "location", result);
      }
    }

    return Partial("Directive", "at least one location", () => result, result.Locations != DirectiveLocation.None);
  }

  internal IResult<EnumAst> ParseEnumDeclaration(string description)
  {
    var at = _tokens.At;
    var hasName = _tokens.Identifier(out var name);
    EnumAst result = new(at, name, description);

    if (!hasName) {
      return Error("Enum", "name", result);
    }

    var prefix = ParsePrefix("Enum");
    if (!prefix.Required(aliases => result.Aliases = aliases)) {
      return prefix.AsResult(result);
    }

    if (_tokens.Take(':')) {
      if (_tokens.Identifier(out var extends)) {
        result.Extends = extends;
      } else {
        return Error("Enum", "type after ':'", result);
      }
    }

    List<EnumLabelAst> labels = new();
    while (!_tokens.Take("}")) {
      var enumLabel = ParseEnumLabel();
      if (!enumLabel.Required(labels.Add)) {
        result.Labels = labels.ToArray();
        return enumLabel.AsResult(result);
      }
    }

    result.Labels = labels.ToArray();
    return Partial("Enum", "at least one label", () => result, labels.Any());
  }

  internal IResult<InputAst> ParseInputDeclaration(string description)
   => ParseObject(description, new InputParserFactories(this));

  internal IResult<OutputAst> ParseOutputDeclaration(string description)
   => ParseObject(description, new OutputParserFactories(this));

  internal IResult<ScalarAst> ParseScalarDeclaration(string description)
  {
    var at = _tokens.At;
    var hasName = _tokens.Identifier(out var name);
    ScalarAst result = new(at, name, description);

    if (!hasName) {
      return Error("Scalar", "name", result);
    }

    var prefix = ParsePrefix("Scalar");
    if (!prefix.Required(aliases => result.Aliases = aliases)) {
      return prefix.AsResult(result);
    }

    var scalarKind = ParseEnumValue<ScalarKind>("Scalar");
    if (!scalarKind.Required(kind => result.Kind = kind)) {
      return scalarKind.AsResult(result);
    }

    switch (result.Kind) {
      case ScalarKind.Number:
        var scalarRanges = ParseRanges();
        if (scalarRanges.Required(ranges => result.Ranges = ranges)) {
          return End("Scalar", () => result);
        }

        return scalarRanges.AsResult(result);
      case ScalarKind.String:
        var scalarRegexes = ParseRegexes();
        if (scalarRegexes.Required(regexes => result.Regexes = regexes)) {
          return End("Scalar", () => result);
        }

        return scalarRegexes.AsResult(result);
      default:
        return Partial("Scalar", "valid kind", () => result);
    }
  }

  private IResultArray<string> ParsePrefix(string label)
  {
    var aliases = ParseAliases(label);
    return aliases.MapOk(
      result => _tokens.Take('{') ? result.OkArray() : ErrorArray(label, "'{' before definition", result),
      () => aliases);
  }

  private IResult<T> End<T>(string label, Func<T> result)
    => Partial(label, "'}' at end of definition", result, _tokens.Take('}'));

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

  private IResult<O> ParseOption<O>(string label)
    where O : struct
  {
    if (_tokens.Take('(')) {
      var enumValue = ParseEnumValue<O>(label);

      return enumValue.Map(result =>
        _tokens.Take(')')
          ? enumValue
          : Partial(label, "')' after option", () => result));
    }

    return 0.Empty<O>();
  }

  private IResult<E> ParseEnumValue<E>(string label)
    where E : struct
    => _tokens.Identifier(out var option)
      ? Enum.TryParse<E>(option, true, out var result)
        ? result.Ok()
        : Error(label, "valid enum value", result)
      : 0.Empty<E>();

  internal IResult<ParameterAst> ParseParameter()
  {
    if (!_tokens.Take('(')) {
      return default(ParameterAst).Empty();
    }

    _tokens.String(out var descr);
    var at = _tokens.At;
    var input = ParseReference(new InputParserFactories(this), descr);
    if (!input.IsOk()) {
      return Error<ParameterAst>("Parameter", "input reference after '('");
    }

    var parameter = new ParameterAst(at, input.Required());
    var modifiers = ParseModifiers("Operation");

    if (modifiers.IsError(Errors.Add)) {
      return modifiers.AsResult(parameter);
    }

    modifiers.Optional(value => parameter.Modifiers = value);

    var constant = ParseDefault();
    return !constant.Optional(value => parameter.Default = value)
      ? constant.AsResult(parameter)
      : _tokens.Take(')') ? parameter.Ok() : Partial("Parameter", "')' at end", () => parameter);
  }

  private IResult<EnumLabelAst> ParseEnumLabel()
  {
    _tokens.String(out var description);
    var at = _tokens.At;

    if (!_tokens.Identifier(out var label)) {
      return Error<EnumLabelAst>("Enum", "label");
    }

    var enumAliases = ParseAliases("Enum");
    var enumLabel = enumAliases.IsOk()
      ? new EnumLabelAst(at, label, description) { Aliases = enumAliases.Required() }
      : new EnumLabelAst(at, label, description);

    return enumAliases.AsPartial(enumLabel, Errors.Add);
  }

  private IResult<O> ParseObject<O, F, R>(string description, IObjectParser<O, F, R> factories)
    where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
  {
    var at = _tokens.At;
    var getName = _tokens.Identifier(out var name);

    O result = factories.Object(at, name, description);
    if (!getName) {
      return Error(factories.Label, "name", result);
    }

    var typeParameters = ParseTypeParameters(factories.Label);
    if (!typeParameters.Optional(parameters => result.Parameters = parameters)) {
      return typeParameters.AsPartial(result);
    }

    var prefix = ParsePrefix(factories.Label);
    if (!prefix.Required(aliases => result.Aliases = aliases)) {
      return prefix.AsPartial(result);
    }

    if (_tokens.Take(':')) {
      _tokens.String(out var descr);
      var baseReference = ParseReference(factories, descr);
      if (baseReference.IsError()) {
        return baseReference.AsResult(result);
      }

      baseReference.WithResult(reference => result.Extends = reference with { Description = descr });
    }

    var fields = new List<F>();
    var objectField = ParseField(factories);
    if (objectField.IsError()) {
      return objectField.AsPartial(result);
    }

    while (objectField.Required(fields.Add)) {
      objectField = ParseField(factories);
      if (objectField.IsError()) {
        result.Fields = fields.ToArray();
        return objectField.AsPartial(result);
      }
    }

    result.Fields = fields.ToArray();
    var objectAlternates = ParseAlternates(factories);
    return !objectAlternates.Optional(alternates => result.Alternates = alternates)
      ? objectAlternates.AsPartial(result)
      : End(factories.Label, () => result);
  }

  private IResultArray<R> ParseAlternates<R>(IReferenceParser<R> factories, params R[] initial)
    where R : AstReference<R>
  {
    var result = new List<R>(initial);
    while (_tokens.Take('|')) {
      _tokens.String(out var descr);
      var reference = ParseReference(factories, descr);
      if (!reference.Required(result.Add)) {
        return PartialArray(factories.Label, "reference after '|'", () => result);
      }
    }

    return result.OkArray();
  }

  internal IResult<F> ParseField<F, R>(IFieldParser<F, R> parser)
    where F : AstField<R> where R : AstReference<R>
  {
    var at = _tokens.At;
    _tokens.String(out var description);
    if (!_tokens.Identifier(out var name)) {
      return 0.Empty<F>();
    }

    var hasParameter = parser.FieldParameter();
    if (hasParameter.IsError()) {
      return hasParameter.AsResult<F>();
    }

    var hasAliases = ParseAliases(parser.Label);
    if (hasAliases.IsError()) {
      return hasAliases.AsResult<F>();
    }

    var field = parser.Field(at, name, description, parser.Reference(at, ""));

    if (_tokens.Take(':')) {
      _tokens.String(out var descr);
      if (ParseReference(parser, descr).Required(fieldType
        => field = parser.Field(at, name, description, fieldType))
        ) {
        hasAliases.WithResult(aliases => field.Aliases = aliases);
        hasParameter.WithResult(parameter => parser.ApplyParameter(field, parameter));

        var modifiers = ParseModifiers("Operation");
        if (modifiers.IsError()) {
          return modifiers.AsResult<F>();
        }

        modifiers.WithResult(modifiers => field.Modifiers = modifiers);

        return parser.FieldDefault(field);
      }

      return Error(parser.Label, "field type", field);
    }

    return parser.FieldEnumLabel(field);
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
        while (referenceArgument.Required(arguments.Add)) {
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

    return 0.Empty<R>();
  }

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

  internal IResult<InputFieldAst> ParseInputFieldLabel(InputFieldAst field)
    => Error("Input", "':'", field);

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

  private IResultArray<ScalarRangeAst> ParseRanges()
  {
    var result = new List<ScalarRangeAst>();
    while (ParseRange().Required(result.Add)) { }

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
