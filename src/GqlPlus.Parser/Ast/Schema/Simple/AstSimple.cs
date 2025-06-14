using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

internal abstract record class AstSimple(
  ITokenAt At,
  string Name,
  string Description
) : AstType<IGqlpTypeRef>(At, Name, Description)
  , IGqlpSimple
{ }

internal abstract record class AstSimple<TItemAst>(
  ITokenAt At,
  string Name,
  string Description,
  TItemAst[] Items
) : AstSimple(At, Name, Description)
  , IGqlpSimple<TItemAst>
  where TItemAst : IGqlpNamed
{
  IEnumerable<TItemAst> IGqlpSimple<TItemAst>.Items => Items;

  public virtual bool Equals(AstSimple<TItemAst>? other)
    => other is IGqlpSimple<TItemAst> simple && Equals(simple);
  public virtual bool Equals(IGqlpSimple<TItemAst>? other)
    => base.Equals(other)
      && Items.SequenceEqual(other.Items);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Items.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Parent.Prefixed(":"))
      .Concat(Items.Bracket());
}
