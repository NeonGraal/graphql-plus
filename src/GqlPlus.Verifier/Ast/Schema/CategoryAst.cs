namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class CategoryAst(TokenAt At, string Name, string Description, string Output)
  : AstDeclaration(At, Name, Description), IEquatable<CategoryAst>
{
  internal override string Abbr => "C";
  internal override string GroupName => "Categories";

  public string Output { get; set; } = Output;

  public CategoryOption Option { get; set; } = CategoryOption.Parallel;

  public CategoryAst(TokenAt at, string output)
    : this(at, output.Camelize()!, "", output) { }

  public CategoryAst(TokenAt at, string name, string output)
    : this(at, name, "", output) { }

  public bool Equals(CategoryAst? other)
    => base.Equals(other)
    && Option == other.Option
    && Output == other.Output;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"({Option})")
      .Append(Output);
}

public enum CategoryOption
{
  Parallel,
  Single,
  Sequential
}
