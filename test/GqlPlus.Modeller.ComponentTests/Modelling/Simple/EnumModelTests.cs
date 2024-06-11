using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class EnumModelTests(
  IModeller<IGqlpEnum, TypeEnumModel> modeller,
  IRenderer<TypeEnumModel> rendering
) : TestTypeModel<SimpleKindModel>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, string[] members)
    => _checks.EnumExpected(
      new(AstNulls.At, name, members.EnumMembers()),
      new(name,
        members: _checks.ExpectedMembers("items:", members),
        allMembers: _checks.ExpectedAllMembers("allItems:", members, name)));

  [Theory, RepeatData(Repeats)]
  public void Model_MembersParent(string name, string parent, string[] parentMembers)
    => _checks
    .AddParent(_checks.NewParent(parent, parentMembers))
    .EnumExpected(
      new(AstNulls.At, name, []) { Parent = parent, },
      new(name, parent, allMembers: _checks.ExpectedAllMembers("allItems:", parentMembers, parent)));

  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string[] parentMembers, string grandParent, string[] grandParentMembers)
    => _checks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddParent(_checks.NewParent(parent, parentMembers, grandParent))
    .AddParent(_checks.NewParent(grandParent, grandParentMembers))
    .EnumExpected(
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
    .EnumExpected(
      new(AstNulls.At, name, members.EnumMembers()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      new(name, parent, aliases, contents, _checks.ExpectedMembers("items:", members),
        _checks.ExpectedAllMembers("allItems:", parentMembers, parent)
        .Concat(_checks.ExpectedAllMembers("", members, name))));

  internal override ICheckTypeModel<SimpleKindModel> TypeChecks => _checks;

  private readonly EnumModelChecks _checks = new(modeller, rendering);
}

internal sealed class EnumModelChecks(
  IModeller<IGqlpEnum, TypeEnumModel> modeller,
  IRenderer<TypeEnumModel> rendering
) : CheckTypeModel<IGqlpEnum, SimpleKindModel, TypeEnumModel, string>(modeller, rendering, SimpleKindModel.Enum)
{
  internal void EnumExpected(EnumDeclAst ast, ExpectedEnumInput input)
    => AstExpected(ast, ExpectedEnum(input));

  protected override ToExpected<string> ExpectedAllMember(string type)
    => member => ["- !_EnumMember", "  enum: " + type, "  name: " + member];

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedEnum(new(input));

  private string[] ExpectedEnum(ExpectedEnumInput input)
    => ["!_TypeEnum",
      .. input.Aliases,
      .. input.AllItems,
      .. input.Description,
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

internal sealed class ExpectedEnumInput(
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

  internal ExpectedEnumInput(ExpectedTypeInput<string> input)
    : this(input.Name, input.Parent)
  {
    Aliases = input.Aliases;
    Description = input.Description;
  }
}
