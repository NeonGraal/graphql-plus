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
        .. _checks.ExpectedAllMembers("allItems:", members, name),
        .. _checks.ExpectedMembers("items:", members),
        "kind: !_TypeKind Enum",
        "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_MembersParent(string name, string parent, string[] parentMembers)
    => _checks
    .AddParent(_checks.NewParent(parent, parentMembers))
    .AstExpected(
      new(AstNulls.At, name) { Parent = parent, },
      ["!_TypeEnum",
        .. _checks.ExpectedAllMembers("allItems:", parentMembers, parent),
        "kind: !_TypeKind Enum",
        "name: " + name,
        .. parent.TypeRefFor(SimpleKindModel.Enum)]);

  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string[] parentMembers, string grandParent, string[] grandParentMembers)
    => _checks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddParent(_checks.NewParent(parent, parentMembers, grandParent))
    .AddParent(_checks.NewParent(grandParent, grandParentMembers))
    .AstExpected(
      new(AstNulls.At, name) { Parent = parent, },
      ["!_TypeEnum",
        .. _checks.ExpectedAllMembers("allItems:", grandParentMembers, grandParent),
        .. _checks.ExpectedAllMembers("", parentMembers, parent),
        "kind: !_TypeKind Enum",
        "name: " + name,
        .. parent.TypeRefFor(SimpleKindModel.Enum)]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(
    string name,
    string contents,
    string[] aliases,
    string parent,
    string[] members,
    string[] parentMembers
  ) => _checks
    .AddParent(_checks.NewParent(parent, parentMembers))
    .AstExpected(
      new(AstNulls.At, name) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
        Members = members.EnumMembers()
      },
      ["!_TypeEnum",
        $"aliases: [{string.Join(", ", aliases)}]",
        .. _checks.ExpectedAllMembers("allItems:", parentMembers, parent),
        .. _checks.ExpectedAllMembers("", members, name),
        "description: " + _checks.YamlQuoted(contents),
        .. _checks.ExpectedMembers("items:", members),
        "kind: !_TypeKind Enum",
        "name: " + name,
        .. parent.TypeRefFor(SimpleKindModel.Enum)]);

  internal override ICheckTypeModel<SimpleKindModel> TypeChecks => _checks;

  private readonly EnumModelChecks _checks = new();
}

internal sealed class EnumModelChecks
  : CheckTypeModel<EnumDeclAst, SimpleKindModel, TypeEnumModel, string>
{
  public EnumModelChecks()
    : base(new EnumModeller(), SimpleKindModel.Enum)
  { }

  internal override TypeEnumModel NewParent(string name, string[] members, string? parent = null)
    => new(name) {
      Parent = parent?.TypeRef(SimpleKindModel.Enum),
      Items = [.. members.Select(m => new AliasedModel(m))]
    };

  internal IEnumerable<string> ExpectedMembers(string field, string[] members)
    => ItemsExpected(field, members, m => ["- !_Aliased " + m]);

  internal IEnumerable<string> ExpectedAllMembers(string field, string[] members, string ofEnum)
    => ItemsExpected(field, members, m => ["- !_EnumMember", "  enum: " + ofEnum, "  name: " + m]);

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => [$"!_TypeEnum",
        .. input.Aliases ?? [],
        .. input.Description ?? [],
        $"kind: !_TypeKind {TypeKind}",
        "name: " + input.Name,
        .. ExpectedParent(input.Parent)];

  protected override EnumDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);

  internal override EnumDeclAst NewTypeAst(string name, string? parent, string description)
    => new(AstNulls.At, name, description) { Parent = parent };
}
