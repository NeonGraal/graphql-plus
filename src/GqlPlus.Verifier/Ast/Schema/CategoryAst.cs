namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class CategoryAst(ParseAt At, string Name, string Output)
  : AstAliased(At, Name), IEquatable<CategoryAst>
{
  internal override string Abbr => "C";

  public CategoryOption Option { get; set; } = CategoryOption.Parallel;

  public CategoryAst(ParseAt at, string output)
    : this(at, output.Camelize()!, output) { }

  public bool Equals(CategoryAst? other)
    => base.Equals(other)
    && Option == other.Option;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"({Option})")
      .Append(Output);
}
