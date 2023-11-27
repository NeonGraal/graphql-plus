using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOutput : ObjectParser<OutputAst, OutputFieldAst, OutputReferenceAst>
{
  public ParseOutput(
    IParserArray<ModifierAst> modifiers,
    TypeName name,
    IParser<ObjectParameters> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<ObjectDefinition<OutputFieldAst, OutputReferenceAst>> definition
  ) : base(modifiers, name, param, aliases, option, definition) { }

  protected override string Label => "Output";

  protected override bool ApplyDefinition(OutputAst result, IResult<ObjectDefinition<OutputFieldAst, OutputReferenceAst>> definition) => throw new NotImplementedException();
  protected override bool ApplyOption(OutputAst result, IResult<NullAst> option) => throw new NotImplementedException();
  protected override void ApplyParameter(OutputFieldAst field, ParameterAst? parameter) => throw new NotImplementedException();
  protected override OutputFieldAst Field(ParseAt at, string name, string description, OutputReferenceAst r) => throw new NotImplementedException();
  protected override IResult<OutputFieldAst> FieldDefault(OutputFieldAst field) => throw new NotImplementedException();
  protected override IResult<OutputFieldAst> FieldEnumLabel(OutputFieldAst field) => throw new NotImplementedException();
  protected override IResult<ParameterAst> FieldParameter() => throw new NotImplementedException();
  [return: NotNull]
  protected override OutputAst MakeResult(ParseAt at, string? name, string description) => throw new NotImplementedException();
  protected override OutputReferenceAst Reference(ParseAt at, string param) => throw new NotImplementedException();
  protected override IResult<OutputReferenceAst> TypeEnumLabel(OutputReferenceAst reference) => throw new NotImplementedException();
}
