using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal sealed record class FragmentAst(
  ITokenAt At,
  string Identifier,
  string OnType,
  params IGqlpSelection[] Selections
) : AstDirectives(At, Identifier)
  , IGqlpFragment
{
  internal override string Abbr => "t";

  IEnumerable<IGqlpSelection> IGqlpSelections.Selections => Selections;

  public bool Equals(IGqlpFragment? other)
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
