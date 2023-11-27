using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseInput : ObjectParser<InputAst, InputFieldAst, InputReferenceAst>
{
  public ParseInput(
    IParserArray<ModifierAst> modifiers,
    TypeName name,
    IParser<ObjectParameters> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<ObjectDefinition<InputFieldAst, InputReferenceAst>> definition
  ) : base(modifiers, name, param, aliases, option, definition) { }

  protected override string Label => "Input";

  protected override bool ApplyDefinition(InputAst result, IResult<ObjectDefinition<InputFieldAst, InputReferenceAst>> definition) => throw new NotImplementedException();
  protected override bool ApplyOption(InputAst result, IResult<NullAst> option) => throw new NotImplementedException();
  protected override void ApplyParameter(InputFieldAst field, ParameterAst? parameter) => throw new NotImplementedException();
  protected override InputFieldAst Field(ParseAt at, string name, string description, InputReferenceAst r) => throw new NotImplementedException();
  protected override IResult<InputFieldAst> FieldDefault(InputFieldAst field) => throw new NotImplementedException();
  protected override IResult<InputFieldAst> FieldEnumLabel(InputFieldAst field) => throw new NotImplementedException();
  protected override IResult<ParameterAst> FieldParameter() => throw new NotImplementedException();

  [return: NotNull]
  protected override InputAst MakeResult(ParseAt at, string? name, string description) => throw new NotImplementedException();
  protected override InputReferenceAst Reference(ParseAt at, string param) => throw new NotImplementedException();
  protected override IResult<InputReferenceAst> TypeEnumLabel(InputReferenceAst reference) => throw new NotImplementedException();
}
