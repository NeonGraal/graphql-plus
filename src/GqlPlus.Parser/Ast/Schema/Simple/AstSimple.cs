using GqlPlus;

namespace GqlPlus.Ast.Schema.Simple;

internal abstract record class AstSimple(
  ITokenAt At,
  string Name,
  string Description
) : AstType<IAstTypeRef>(At, Name, Description)
  , IAstSimple
{ }

internal abstract record class AstSimple<TItemAst>(
  ITokenAt At,
  string Name,
  string Description,
  TItemAst[] Items
) : AstSimple(At, Name, Description)
  , IAstSimple<TItemAst>
  where TItemAst : IAstNamed
{
  IEnumerable<TItemAst> IAstSimple<TItemAst>.Items => Items;

  public virtual bool Equals(AstSimple<TItemAst>? other)
    => other is IAstSimple<TItemAst> simple && Equals(simple);
  public virtual bool Equals(IAstSimple<TItemAst>? other)
    => base.Equals(other)
      && Items.SequenceEqual(other.Items);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Items.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Parent.Prefixed(":"))
      .Concat(Items.Bracket());
}
