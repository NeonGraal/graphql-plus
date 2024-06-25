using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class UnionModelTests(
  IModeller<IGqlpUnion, TypeUnionModel> modeller,
  IRenderer<TypeUnionModel> rendering
) : TestTypeModel<SimpleKindModel>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] members)
    => _checks.UnionExpected(
      new(AstNulls.At, name, members.UnionMembers()),
      new(name,
        members: _checks.ExpectedMembers("items:", members),
        allMembers: _checks.ExpectedAllMembers("allItems:", members, name)));

  [Theory, RepeatData(Repeats)]
  public void Model_MembersParent(string name, string parent, string[] parentMembers)
    => _checks
    .AddParent(_checks.NewParent(parent, parentMembers))
    .UnionExpected(
      new(AstNulls.At, name, []) { Parent = parent, },
      new(name, parent, allMembers: _checks.ExpectedAllMembers("allItems:", parentMembers, parent)));

  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string[] parentMembers, string grandParent, string[] grandParentMembers)
    => _checks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddParent(_checks.NewParent(parent, parentMembers, grandParent))
    .AddParent(_checks.NewParent(grandParent, grandParentMembers))
    .UnionExpected(
      new(AstNulls.At, name, []) { Parent = parent, },
      new(name, parent, allMembers: _checks
        .ExpectedAllMembers("allItems:", grandParentMembers, grandParent)
        .Concat(_checks.ExpectedAllMembers("", parentMembers, parent))));

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
    .UnionExpected(
      new(AstNulls.At, name, members.UnionMembers()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      new(name, parent, aliases, contents, _checks.ExpectedMembers("items:", members),
        _checks.ExpectedAllMembers("allItems:", parentMembers, parent)
        .Concat(_checks.ExpectedAllMembers("", members, name))));

  internal override ICheckTypeModel<SimpleKindModel> TypeChecks => _checks;

  private readonly UnionModelChecks _checks = new(modeller, rendering);
}

internal sealed class UnionModelChecks(
  IModeller<IGqlpUnion, TypeUnionModel> modeller,
  IRenderer<TypeUnionModel> rendering
) : CheckTypeModel<IGqlpUnion, SimpleKindModel, TypeUnionModel, string>(modeller, rendering, SimpleKindModel.Union)
{
  internal void UnionExpected(UnionDeclAst ast, ExpectedUnionInput input)
  => AstExpected(ast, ExpectedUnion(input));

  protected override ToExpected<string> ExpectedAllMember(string type)
    => member => ["- !_UnionMember", "  name: " + member, "  union: " + type];

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedUnion(new(input));

  private string[] ExpectedUnion(ExpectedUnionInput input)
    => ["!_TypeUnion",
      .. input.ExpectedAliases,
      .. input.AllItems,
      .. input.ExpectedDescription,
      .. input.Items,
      "name: " + input.Name,
      .. input.Parent.TypeRefFor(SimpleKindModel.Union),
      "typeKind: !_TypeKind Union"];

  protected override UnionDeclAst NewAliasedAst(string input, string? description = null, string[]? aliases = null)
    => new(AstNulls.At, input, description ?? "", []) { Aliases = aliases ?? [] };

  internal override TypeUnionModel NewParent(string name, string[] members, string? parent = null)
    => new(name) {
      Parent = parent?.TypeRef(SimpleKindModel.Union),
      Items = [.. members.Select(m => new AliasedModel(m))]
    };

  internal override UnionDeclAst NewTypeAst(string name, string? parent = default, string? description = null, string[]? aliases = null)
    => new(AstNulls.At, name, description ?? "", []) {
      Parent = parent,
      Aliases = aliases ?? [],
    };
}

internal sealed class ExpectedUnionInput(
  string name,
  string? parent = null,
  IEnumerable<string>? aliases = null,
  string? description = null,
  IEnumerable<string>? members = null,
  IEnumerable<string>? allMembers = null
) : ExpectedTypeInput<string>(name, parent, aliases, description)
{
  public string[] Items { get; } = [.. members ?? []];
  public string[] AllItems { get; } = [.. allMembers ?? []];

  internal ExpectedUnionInput(ExpectedTypeInput<string> input)
    : this(input.Name, input.Parent)
  {
    Aliases = input.Aliases;
    ExpectedAliases = input.ExpectedAliases;
    Description = input.Description;
    ExpectedDescription = input.ExpectedDescription;
  }
}
