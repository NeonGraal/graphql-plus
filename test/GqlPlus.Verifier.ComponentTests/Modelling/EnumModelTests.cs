using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class EnumModelTests
  : TypeModelTests<SimpleKindModel>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] members)
    => _checks
    .AstExpected(
      new(AstNulls.At, name) { Members = members.EnumMembers() },
      ["!_TypeEnum",
        "allMembers:",
        .. members.SelectMany(m => ExpectedMember(m, name)),
        "kind: !_TypeKind Enum",
        "members:",
        .. members.SelectMany(m => ExpectedMember(m, name)),
        "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(
    string name,
    string contents,
    string[] aliases,
    string parent,
    string[] members
  ) => _checks
    .AstExpected(
      new(AstNulls.At, name) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
        Members = members.EnumMembers()
      },
      ["!_TypeEnum",
        $"aliases: [{string.Join(", ", aliases)}]",
        "allMembers:",
        .. members.SelectMany(m => ExpectedMember(m, name)),
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Enum),
        "kind: !_TypeKind Enum",
        "members:",
        .. members.SelectMany(m => ExpectedMember(m, name)),
        "name: " + name]);

  [SuppressMessage("Performance", "CA1822:Mark members as static")]
  private string[] ExpectedMember(string member, string ofEnum)
    => ["- !_EnumMember", "  enum: " + ofEnum, "  name: " + member];

  internal override ITypeModelChecks<SimpleKindModel> TypeChecks => _checks;

  private readonly EnumModelChecks _checks = new();
}

internal sealed class EnumModelChecks
  : TypeModelChecks<EnumDeclAst, SimpleKindModel, TypeEnumModel>
{
  public EnumModelChecks()
    : base(new EnumModeller(), SimpleKindModel.Enum)
  { }

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected override string[] ExpectedType(string name, string? parent, IEnumerable<string>? aliases = null, IEnumerable<string>? description = null)
    => [$"!_TypeEnum",
        .. aliases ?? [],
        .. description ?? [],
        $"kind: !_TypeKind {TypeKind}",
        "name: " + name,
        .. ExpectedParent(parent)];

  protected override EnumDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);

  internal override EnumDeclAst NewTypeAst(string name, string? parent, string description)
    => new(AstNulls.At, name, description) { Parent = parent };
}
