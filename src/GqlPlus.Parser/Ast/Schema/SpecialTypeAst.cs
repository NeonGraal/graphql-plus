using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Ast.Schema;

internal sealed record class SpecialTypeAst
  : AstSimple
  , IAstTypeSpecial
{
  public override TypeKind Kind => TypeKind.Special;
  public new IAstTypeRef? Parent => null;

  private readonly Func<IAstType, bool> _typeMatcher;
  private readonly Func<HashSet<TypeKind>, bool> _kindsMatcher;

  public SpecialTypeAst(string label)
    : base(AstNulls.At, "_" + label, "")
    => (_abbr, Aliases, _label, _typeMatcher, _kindsMatcher) = ("TZ", [label], label, t => true, h => true);

  public SpecialTypeAst(
    string label,
    Func<IAstType, bool> typeMatcher
  ) : base(AstNulls.At, label, "")
    => (_abbr, Aliases, _label, _typeMatcher, _kindsMatcher) = ("TZ", ["_" + label], label, typeMatcher, h => h.Contains(TypeKind.Internal));

  public SpecialTypeAst(
    string label,
    TypeKind kind,
    Func<IAstType, bool> typeMatcher
  ) : this(label)
    => (_typeMatcher, _kindsMatcher) = (typeMatcher, h => h.Contains(kind));

  public bool Equals(SpecialTypeAst? other)
    => other is IAstType<IAstTypeRef> parented && Equals(parented);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Label);
  public bool MatchesTypeSpecial(IAstType type)
    => _typeMatcher(type);
  public bool MatchesKindSpecial(HashSet<TypeKind> validKinds)
    => _kindsMatcher(validKinds);
}
