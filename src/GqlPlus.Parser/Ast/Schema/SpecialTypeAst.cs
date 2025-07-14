using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Ast.Schema;

internal sealed record class SpecialTypeAst
  : AstSimple
  , IGqlpTypeSpecial
{
  internal override string Abbr => "TZ";
  public override string Label { get; }
  public new IGqlpTypeRef? Parent => null;

  private readonly Func<IGqlpType, bool> _matcher;

  public SpecialTypeAst(string label, Func<IGqlpType, bool> matcher)
    : base(AstNulls.At, "_" + label, "")
    => (Aliases, Label, _matcher) = ([label], label, matcher);

  public bool Equals(SpecialTypeAst? other)
    => other is IGqlpType<IGqlpTypeRef> parented && Equals(parented);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Label);
  public bool MatchesTypeSpecial(IGqlpType type)
    => _matcher(type);
}
