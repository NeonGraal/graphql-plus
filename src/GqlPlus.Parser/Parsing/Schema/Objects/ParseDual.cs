using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDual(
  ISimpleName name,
  Parser<IGqlpTypeParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<IGqlpDualField>>.D definition
) : ObjectParser<IGqlpDualObject, IGqlpDualField>(name, param, aliases, option, definition)
{
  protected override IGqlpDualObject MakeResult(AstPartial<IGqlpTypeParam, NullOption> partial, ObjectDefinition<IGqlpDualField> value)
    => new DualDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params.ArrayOf<TypeParamAst>(),
      Parent = value.Parent,
      ObjFields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override IGqlpDualObject ToResult(AstPartial<IGqlpTypeParam, NullOption> partial)
    => new DualDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params.ArrayOf<TypeParamAst>(),
    };
}
