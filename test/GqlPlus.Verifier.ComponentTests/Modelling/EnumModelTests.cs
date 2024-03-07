using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class EnumModelTests
  : TestTypeModel<SimpleKindModel>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] members)
    => _checks
    .AstExpected(
      new(AstNulls.At, name) { Members = members.EnumMembers() },
      ["!_TypeEnum",
        .. _checks.ExpectedMembers("allMembers:", members, name),
        "kind: !_TypeKind Enum",
        .. _checks.ExpectedMembers("members:", members, ""),
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
        .. _checks.ExpectedMembers("allMembers:", members, name),
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Enum),
        "kind: !_TypeKind Enum",
        .. _checks.ExpectedMembers("members:", members, ""),
        "name: " + name]);

  internal override ICheckTypeModel<SimpleKindModel> TypeChecks => _checks;

  private readonly EnumModelChecks _checks = new();
}

internal sealed class EnumModelChecks
  : CheckTypeModel<EnumDeclAst, SimpleKindModel, TypeEnumModel>
{
  public EnumModelChecks()
    : base(new EnumModeller(), SimpleKindModel.Enum)
  { }

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  internal IEnumerable<string> ExpectedMembers(string field, string[] members, string ofEnum)
    => ItemsExpected(field, members, m => string.IsNullOrWhiteSpace(ofEnum)
      ? ["- !_Aliased " + m]
      : ["- !_EnumMember", "  enum: " + ofEnum, "  name: " + m]);

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
