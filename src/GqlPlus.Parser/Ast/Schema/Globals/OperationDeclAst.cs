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
  public IEnumerable<IAstVariable> Variables { get; } = [];
  public IAstArg? Arg { get; }
  public IEnumerable<IAstSelection>? Selections { get; } = [];
  public IEnumerable<IAstFragment> Fragments { get; } = [];
  public IEnumerable<IAstDirective> Directives { get; init; } = [];
  public IEnumerable<IAstModifier> Modifiers { get; } = [];

  public OperationDeclAst(TokenAt at, string name, string category)
    : this(at, name, "", category) { }

  public bool Equals(OperationDeclAst? other)
    => base.Equals(other)
    && Category == other.Category;
  public bool Equals(IAstDirectives other)
    => Equals(other as OperationDeclAst);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Category);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Category);
}
