namespace GqlPlus.Verifier.Ast;

internal sealed record class CategoryAst(ParseAt At, string Name)
  : AstAliased(At, Name), IEquatable<CategoryAst>
{
  protected override string Abbr => "c";

  public CategoryOption Option { get; set; } = CategoryOption.Parallel;

  public bool Equals(CategoryAst? other)
    => base.Equals(other)
    && Option == other.Option;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append($"({Option})");
}
