﻿using GqlPlus.Verifier.Ast.Schema;

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
        "kind: !_TypeKind Enum",
        .. _checks.ExpectedMembers("items:", members),
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
        .. parent.TypeRefFor(SimpleKindModel.Enum),
        "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string[] parentMembers, string grandParent, string[] grandParentMembers)
    => _checks
    .AddParent(_checks.NewParent(parent, parentMembers, grandParent))
    .AddParent(_checks.NewParent(grandParent, grandParentMembers))
    .AstExpected(
      new(AstNulls.At, name) { Parent = parent, },
      ["!_TypeEnum",
        .. _checks.ExpectedAllMembers("allItems:", parentMembers, parent),
        .. _checks.ExpectedAllMembers("", grandParentMembers, grandParent),
        "kind: !_TypeKind Enum",
        .. parent.TypeRefFor(SimpleKindModel.Enum),
        "name: " + name]);

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
        .. _checks.ExpectedAllMembers("allItems:", members, name),
        .. _checks.ExpectedAllMembers("", parentMembers, parent),
        "description: " + _checks.YamlQuoted(contents),
        .. parent.TypeRefFor(SimpleKindModel.Enum),
        "kind: !_TypeKind Enum",
        .. _checks.ExpectedMembers("items:", members),
        "name: " + name]);

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
