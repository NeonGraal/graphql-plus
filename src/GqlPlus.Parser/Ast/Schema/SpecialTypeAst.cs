using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Ast.Schema;

internal sealed record class SpecialTypeAst
  : AstSimple
  , IGqlpTypeSpecial
{
  public override TypeKind Kind => TypeKind.Special;
  public new IGqlpTypeRef? Parent => null;

  private readonly Func<IGqlpType, bool> _typeMatcher;
  private readonly Func<HashSet<TypeKind>, bool> _kindsMatcher;

  public SpecialTypeAst(string label)
    : base(AstNulls.At, "_" + label, "")
    => (_abbr, Aliases, _label, _typeMatcher, _kindsMatcher) = ("TZ", [label], label, t => true, h => true);

  public SpecialTypeAst(string label, TypeKind kind, Func<IGqlpType, bool> typeMatcher)
    : this(label)
    => (_typeMatcher, _kindsMatcher) = (typeMatcher, h => h.Contains(kind));

  public bool Equals(SpecialTypeAst? other)
    => other is IGqlpType<IGqlpTypeRef> parented && Equals(parented);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Label);
  public bool MatchesTypeSpecial(IGqlpType type)
    => _typeMatcher(type);
  public bool MatchesKindSpecial(HashSet<TypeKind> validKinds)
    => _kindsMatcher(validKinds);
}
