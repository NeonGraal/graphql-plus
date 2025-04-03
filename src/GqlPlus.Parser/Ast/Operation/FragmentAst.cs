using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class FragmentAst(
  TokenAt At,
  string Identifier,
  string OnType,
  params IGqlpSelection[] Selections
) : AstDirectives(At, Identifier)
  , IEquatable<FragmentAst>
  , IGqlpFragment
{
  internal override string Abbr => "t";

  IEnumerable<IGqlpSelection> IGqlpFragment.Selections => Selections;

  public bool Equals(FragmentAst? other)
    => base.Equals(other)
    && OnType == other.OnType
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), OnType, Selections.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"))
      .Concat(Selections.Bracket("{", "}"));
}
