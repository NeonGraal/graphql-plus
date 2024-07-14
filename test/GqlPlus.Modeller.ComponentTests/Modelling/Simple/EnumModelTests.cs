using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Resolving;

namespace GqlPlus.Modelling.Simple;

public class EnumModelTests(
  IEnumModelChecks checks
) : TestTypeModel<SimpleKindModel, TypeEnumModel>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] members)
    => checks.EnumExpected(
      new EnumDeclAst(AstNulls.At, name, members.EnumMembers()),
      new(name,
        members: checks.ExpectedMembers("items:", members),
        allMembers: checks.ExpectedAllMembers("allItems:", members, name)));

  [Theory, RepeatData(Repeats)]
  public void Model_MembersParent(string name, string parent, string[] parentMembers)
    => checks
    .AddParent(checks.NewParent(parent, parentMembers))
    .EnumExpected(
      new EnumDeclAst(AstNulls.At, name, []) { Parent = parent, },
      new(name, parent, allMembers: checks.ExpectedAllMembers("allItems:", parentMembers, parent)));

  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string[] parentMembers, string grandParent, string[] grandParentMembers)
    => checks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddParent(checks.NewParent(parent, parentMembers, grandParent))
    .AddParent(checks.NewParent(grandParent, grandParentMembers))
    .EnumExpected(
      new EnumDeclAst(AstNulls.At, name, []) { Parent = parent, },
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
    .EnumExpected(
      new EnumDeclAst(AstNulls.At, name, members.EnumMembers()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      new(name, parent, aliases, contents, checks.ExpectedMembers("items:", members),
        checks.ExpectedAllMembers("allItems:", parentMembers, parent)
        .Concat(checks.ExpectedAllMembers("", members, name))));
}

internal sealed class EnumModelChecks(
  CheckParentInputs<IGqlpEnum, TypeEnumModel> inputs
) : CheckParentModel<IGqlpEnum, SimpleKindModel, TypeEnumModel, string>(inputs, SimpleKindModel.Enum)
  , IEnumModelChecks
{
  public void EnumExpected(IGqlpEnum ast, ExpectedEnumInput input)
    => AstExpected(ast, ExpectedEnum(input));

  protected override ToExpected<string> ExpectedAllMember(string type)
    => member => ["- !_EnumMember", "  enum: " + type, "  name: " + member];

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedEnum(new(input));

  private string[] ExpectedEnum(ExpectedEnumInput input)
    => ["!_TypeEnum",
      .. input.ExpectedAliases,
      .. input.AllItems,
      .. input.ExpectedDescription,
      .. input.Items,
      "name: " + input.Name,
      .. input.Parent.TypeRefFor(SimpleKindModel.Enum),
      "typeKind: !_TypeKind Enum"];

  protected override EnumDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, []);

  internal override TypeEnumModel NewParent(string name, string[] members, string? parent = null)
    => new(name) {
      Parent = parent?.TypeRef(SimpleKindModel.Enum),
      Items = [.. members.Select(m => new AliasedModel(m))]
    };

  internal override EnumDeclAst NewTypeAst(string name, string? parent, string? description, string[]? aliases)
    => new(AstNulls.At, name, description ?? "", []) {
      Parent = parent,
      Aliases = aliases ?? [],
    };
}

public interface IEnumModelChecks
  : ICheckParentModel<SimpleKindModel, TypeEnumModel>
  , IParentModel<string>
{
  void EnumExpected(IGqlpEnum ast, ExpectedEnumInput input);
}

public sealed class ExpectedEnumInput(
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

  internal ExpectedEnumInput(ExpectedTypeInput<string> input)
    : this(input.Name, input.Parent)
  {
    Aliases = input.Aliases;
    ExpectedAliases = input.ExpectedAliases;
    Description = input.Description;
    ExpectedDescription = input.ExpectedDescription;
  }
}
