using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOutput(
  TypeName name,
  Parser<TypeParameterAst>.DA param,
  Parser<string>.DA aliases,
  Parser<NullAst>.D option,
  Parser<ObjectDefinition<OutputFieldAst, OutputReferenceAst>>.D definition
) : ObjectParser<OutputDeclAst, OutputFieldAst, OutputReferenceAst>(name, param, aliases, option, definition)
{
  protected override void ApplyDefinition(OutputDeclAst result, ObjectDefinition<OutputFieldAst, OutputReferenceAst> value)
  {
    result.Extends = value.Extends;
    result.Fields = value.Fields;
    result.Alternates = value.Alternates;
  }

  protected override bool ApplyOption(OutputDeclAst result, IResult<NullAst> option) => true;

  [return: NotNull]
  protected override OutputDeclAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class ParseOutputDefinition(
  Parser<OutputFieldAst>.D field,
  Parser<ModifierAst>.DA modifiers,
  Parser<OutputReferenceAst>.D reference
) : ParseObjectDefinition<OutputFieldAst, OutputReferenceAst>(field, modifiers, reference)
{
  protected override string Label => "Output";
}
