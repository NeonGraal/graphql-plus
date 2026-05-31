using GqlPlus.Ast.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class OperationDeclAst(
  ITokenAt At,
  string Name,
  string Description,
  string Category
) : AstDeclaration(At, Name, Description)
  , IEquatable<OperationDeclAst>
  , IAstSchemaOperation
{
  internal override string Abbr => "SO";
  public override string Label => "Operation";

  public string Category { get; } = Category;
  public IEnumerable<IAstVariable> Variables { get; init; } = [];
  public IAstTypeRef? Domain { get; init; }
  public IAstArg? Argument { get; init; }
  public IEnumerable<IAstSelection> Selections { get; init; } = [];
  public IEnumerable<IAstFragment> Fragments { get; init; } = [];
  public IEnumerable<IAstDirective> Directives { get; init; } = [];
  public IEnumerable<IAstModifier> Modifiers { get; init; } = [];

  public OperationDeclAst(TokenAt at, string name, string category)
    : this(at, name, "", category) { }

  public bool Equals(OperationDeclAst? other)
    => base.Equals(other)
    && Category.NullEqual(other.Category)
    && Variables.SequenceEqual(other.Variables)
    && Fragments.SequenceEqual(other.Fragments)
    && ResultEqual(other);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Category);

  private bool ResultEqual(OperationDeclAst other)
    => Directives.SequenceEqual(other.Directives)
    && Modifiers.SequenceEqual(other.Modifiers)
    && Domain is null ? Selections.SequenceEqual(other.Selections)
      : Domain.NullEqual(other.Domain) && Argument.NullEqual(other.Argument);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Category)
      .Concat(Variables.Bracket())
      .Concat(Directives.AsString())
      .Concat(Fragments.Bracket()
      .ConcatNull(Domain,
        d => d.GetFields().Concat(Argument.Bracket("(", ")")),
        () => Selections.Bracket("{", "}"))
      .Concat(Modifiers.AsString()));
}
