using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class UnionModelTests(
  IUnionModelChecks checks
) : TestTypeModel<SimpleKindModel, TypeUnionModel>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] members)
    => checks.UnionExpected(
      new UnionDeclAst(AstNulls.At, name, members.UnionMembers()),
      new(name,
        members: checks.ExpectedMembers("items:", members),
        allMembers: checks.ExpectedAllMembers("allItems:", members, name)));

  [Theory, RepeatData(Repeats)]
  public void Model_MembersParent(string name, string parent, string[] parentMembers)
    => checks
    .AddParent(checks.NewParent(parent, parentMembers))
    .UnionExpected(
      new UnionDeclAst(AstNulls.At, name, []) { Parent = parent, },
      new(name, parent, allMembers: checks.ExpectedAllMembers("allItems:", parentMembers, parent)));

  [Theory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string[] parentMembers, string grandParent, string[] grandParentMembers)
    => checks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddParent(checks.NewParent(parent, parentMembers, grandParent))
    .AddParent(checks.NewParent(grandParent, grandParentMembers))
    .UnionExpected(
      new UnionDeclAst(AstNulls.At, name, []) { Parent = parent, },
      new(name, parent, allMembers: checks
        .ExpectedAllMembers("allItems:", grandParentMembers, grandParent)
        .Concat(checks.ExpectedAllMembers("", parentMembers, parent))));

  [Theory, RepeatData(Repeats)]
  public void Model_All(
    string name,
    string contents,
    string[] aliases,
    string parent,
    string[] members,
    string[] parentMembers
  ) => checks
    .AddParent(checks.NewParent(parent, parentMembers))
    .UnionExpected(
      new UnionDeclAst(AstNulls.At, name, members.UnionMembers()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      new(name, parent, aliases, contents, checks.ExpectedMembers("items:", members),
        checks.ExpectedAllMembers("allItems:", parentMembers, parent)
        .Concat(checks.ExpectedAllMembers("", members, name))));
}

internal sealed class UnionModelChecks(
  CheckTypeInputs<IGqlpUnion, TypeUnionModel> inputs
) : CheckParentModel<IGqlpUnion, SimpleKindModel, TypeUnionModel, string>(inputs, SimpleKindModel.Union)
  , IUnionModelChecks
{
  public void UnionExpected(IGqlpUnion ast, ExpectedUnionInput input)
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

public interface IUnionModelChecks
  : ICheckParentModel<SimpleKindModel, TypeUnionModel>
  , IParentModel<string>
{
  void UnionExpected(IGqlpUnion ast, ExpectedUnionInput input);
}

public sealed class ExpectedUnionInput(
  string name,
  string? parent = null,
  IEnumerable<string>? aliases = null,
  string? description = null,
  IEnumerable<string>? members = null,
  IEnumerable<string>? allMembers = null
) : ExpectedTypeInput<string>(name, parent, aliases, description)
{
#pragma warning disable CA1819 // Properties should not return arrays
  public string[] Items { get; } = [.. members ?? []];
  public string[] AllItems { get; } = [.. allMembers ?? []];
#pragma warning restore CA1819 // Properties should not return arrays

  internal ExpectedUnionInput(ExpectedTypeInput<string> input)
    : this(input.Name, input.Parent)
  {
    Aliases = input.Aliases;
    ExpectedAliases = input.ExpectedAliases;
    Description = input.Description;
    ExpectedDescription = input.ExpectedDescription;
  }
}
