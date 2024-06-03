using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

public interface IObjectBaseFactories<TObjBaseAst>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>
{
  TObjBaseAst ObjBase(TokenAt at, string name, string description = "");
}
