using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOutput : ObjectParser<OutputAst, OutputFieldAst, OutputReferenceAst>
{
  public ParseOutput(
    TypeName name,
    Parser<TypeParameterAst>.DA param,
    Parser<string>.DA aliases,
    Parser<NullAst>.D option,
    Parser<ObjectDefinition<OutputFieldAst, OutputReferenceAst>>.D definition
  ) : base(name, param, aliases, option, definition)
  { }

  protected override void ApplyDefinition(OutputAst result, ObjectDefinition<OutputFieldAst, OutputReferenceAst> value)
  {
    result.Extends = value.Extends;
    result.Fields = value.Fields;
    result.Alternates = value.Alternates;
  }

  protected override bool ApplyOption(OutputAst result, IResult<NullAst> option) => true;

  [return: NotNull]
  protected override OutputAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class ParseOutputDefinition : ParseObjectDefinition<OutputFieldAst, OutputReferenceAst>
{
  public ParseOutputDefinition(
    Parser<OutputFieldAst>.D field,
    Parser<ModifierAst>.DA modifiers,
    Parser<OutputReferenceAst>.D reference
  ) : base(field, modifiers, reference) { }

  protected override string Label => "Output";
}
