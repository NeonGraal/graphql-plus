using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDual(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>>.D definition
) : ObjectParser<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>(name, param, aliases, option, definition)
{
  protected override IGqlpDualObject MakeResult(AstPartial<IGqlpTypeParameter, NullOption> partial, ObjectDefinition<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate> value)
    => new DualDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
      Parent = value.Parent,
      ObjFields = value.Fields,
      ObjAlternates = value.Alternates,
    };

  protected override IGqlpDualObject ToResult(AstPartial<IGqlpTypeParameter, NullOption> partial)
    => new DualDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
    };
}
