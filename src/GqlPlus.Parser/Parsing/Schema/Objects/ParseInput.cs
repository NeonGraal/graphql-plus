using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInput(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<InputFieldAst, IGqlpInputBase>>.D definition
) : ObjectParser<InputDeclAst, InputFieldAst, IGqlpInputBase>(name, param, aliases, option, definition)
{
  protected override InputDeclAst MakeResult(AstPartial<IGqlpTypeParameter, NullOption> partial, ObjectDefinition<InputFieldAst, IGqlpInputBase> value)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
      Parent = value.Parent,
      Fields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override InputDeclAst ToResult(AstPartial<IGqlpTypeParameter, NullOption> partial)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
    };
}
