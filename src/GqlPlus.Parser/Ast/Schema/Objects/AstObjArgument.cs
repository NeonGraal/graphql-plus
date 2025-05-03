using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjArg(
  ITokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IGqlpObjArg
{
  bool IEquatable<IGqlpObjArg>.Equals(IGqlpObjArg? other)
    => Equals(other as AstObjType);
}
