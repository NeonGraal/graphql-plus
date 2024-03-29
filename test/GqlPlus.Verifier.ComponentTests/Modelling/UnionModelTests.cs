using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class UnionModelTests
  : TestTypeModel<SimpleKindModel>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] members)
    => _checks
    .AstExpected(
      new(AstNulls.At, name, members.UnionMembers()),
      ["!_TypeUnion",
        .. _checks.ExpectedAllMembers("allItems:", members, name),
        .. _checks.ExpectedMembers("items:", members),
        "kind: !_TypeKind Union",
        "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_MembersParent(string name, string parent, string[] parentMembers)
    => _checks
    .AddParent(_checks.NewParent(parent, parentMembers))
    .AstExpected(
      new(AstNulls.At, name, []) { Parent = parent, },
      ["!_TypeUnion",
        .. _checks.ExpectedAllMembers("allItems:", parentMembers, parent),
        "kind: !_TypeKind Union",
        "name: " + name,
        .. parent.TypeRefFor(SimpleKindModel.Union)]);

  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string[] parentMembers, string grandParent, string[] grandParentMembers)
    => _checks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddParent(_checks.NewParent(parent, parentMembers, grandParent))
    .AddParent(_checks.NewParent(grandParent, grandParentMembers))
    .AstExpected(
      new(AstNulls.At, name, []) { Parent = parent, },
      ["!_TypeUnion",
        .. _checks.ExpectedAllMembers("allItems:", grandParentMembers, grandParent),
        .. _checks.ExpectedAllMembers("", parentMembers, parent),
        "kind: !_TypeKind Union",
        "name: " + name,
        .. parent.TypeRefFor(SimpleKindModel.Union)]);

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
      new(AstNulls.At, name, members.UnionMembers()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ["!_TypeUnion",
        $"aliases: [{string.Join(", ", aliases)}]",
        .. _checks.ExpectedAllMembers("allItems:", parentMembers, parent),
        .. _checks.ExpectedAllMembers("", members, name),
        "description: " + _checks.YamlQuoted(contents),
        .. _checks.ExpectedMembers("items:", members),
        "kind: !_TypeKind Union",
        "name: " + name,
        .. parent.TypeRefFor(SimpleKindModel.Union)]);

  internal override ICheckTypeModel<SimpleKindModel> TypeChecks => _checks;

  private readonly UnionModelChecks _checks = new();
}

internal sealed class UnionModelChecks
  : CheckTypeModel<UnionDeclAst, SimpleKindModel, TypeUnionModel, string>
{
  public UnionModelChecks()
    : base(new UnionModeller(), SimpleKindModel.Union)
  { }

  internal override TypeUnionModel NewParent(string name, string[] members, string? parent = null)
    => new(name) {
      Parent = parent?.TypeRef(SimpleKindModel.Union),
      Items = [.. members.Select(m => new AliasedModel(m))]
    };

  internal IEnumerable<string> ExpectedMembers(string field, string[] members)
    => ItemsExpected(field, members, m => ["- !_Aliased " + m]);

  internal IEnumerable<string> ExpectedAllMembers(string field, string[] members, string ofUnion)
    => ItemsExpected(field, members, m => ["- !_UnionMember", "  name: " + m, "  union: " + ofUnion]);

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => [$"!_TypeUnion",
        .. input.Aliases ?? [],
        .. input.Description ?? [],
        $"kind: !_TypeKind {TypeKind}",
        "name: " + input.Name,
        .. ExpectedParent(input.Parent)];

  protected override UnionDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, []);

  internal override UnionDeclAst NewTypeAst(string name, string? parent, string description)
    => new(AstNulls.At, name, description, []) { Parent = parent };
}
