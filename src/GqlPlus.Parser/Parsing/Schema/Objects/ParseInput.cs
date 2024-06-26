using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInput(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>>.D definition
) : ObjectParser<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>(name, param, aliases, option, definition)
{
  protected override IGqlpInputObject MakeResult(AstPartial<IGqlpTypeParameter, NullOption> partial, ObjectDefinition<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate> value)
    => new InputDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
      Parent = value.Parent,
      ObjFields = value.Fields,
      ObjAlternates = value.Alternates,
    };

  protected override IGqlpInputObject ToResult(AstPartial<IGqlpTypeParameter, NullOption> partial)
    => new InputDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
    };
}
