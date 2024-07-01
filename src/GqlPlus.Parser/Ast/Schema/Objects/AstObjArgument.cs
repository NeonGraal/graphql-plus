using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjArgument(
  TokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IGqlpObjArgument
{
  bool IEquatable<IGqlpObjArgument>.Equals(IGqlpObjArgument? other)
    => Equals(other as AstObjType);
}
