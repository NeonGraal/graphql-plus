using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class EnumModelTests(
  IEnumModelChecks checks
) : TestTypeModel<SimpleKindModel, TypeEnumModel>(checks)
{
  [Theory, RepeatData]
  public void Model_Labels(string name, string[] labels)
    => checks.EnumExpected(
      new EnumDeclAst(AstNulls.At, name, labels.EnumLabels()),
      new(name,
        labels: checks.ExpectedItems("items:", labels),
        allLabels: checks.ExpectedAllItems("allItems:", labels, name)));

  [Theory, RepeatData]
  public void Model_LabelsParent(string name, string parent, string[] parentLabels)
    => checks
    .AddParent(checks.NewParent(parent, parentLabels))
    .EnumExpected(
      new EnumDeclAst(AstNulls.At, name, []) { Parent = parent, },
      new(name, parent, allLabels: checks.ExpectedAllItems("allItems:", parentLabels, parent)));

  [Theory, RepeatData]
  public void Model_LabelsGrandParent(string name, string parent, string[] parentLabels, string grandParent, string[] grandParentLabels)
    => checks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddParent(checks.NewParent(parent, parentLabels, grandParent))
    .AddParent(checks.NewParent(grandParent, grandParentLabels))
    .EnumExpected(
      new EnumDeclAst(AstNulls.At, name, []) { Parent = parent, },
      new(name, parent, allLabels: checks
        .ExpectedAllItems("allItems:", grandParentLabels, grandParent)
        .Concat(checks.ExpectedAllItems("", parentLabels, parent))));

  [Theory, RepeatData]
  public void Model_All(
    string name,
    string contents,
    string[] aliases,
    string parent,
    string[] labels,
    string[] parentLabels
  ) => checks
    .AddParent(checks.NewParent(parent, parentLabels))
    .EnumExpected(
      new EnumDeclAst(AstNulls.At, name, labels.EnumLabels()) {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      new(name, parent, aliases, contents, checks.ExpectedItems("items:", labels),
        checks.ExpectedAllItems("allItems:", parentLabels, parent)
        .Concat(checks.ExpectedAllItems("", labels, name))));
}

internal sealed class EnumModelChecks(
  CheckTypeInputs<IGqlpEnum, TypeEnumModel> inputs
) : CheckParentModel<IGqlpEnum, SimpleKindModel, TypeEnumModel, string>(inputs, SimpleKindModel.Enum)
  , IEnumModelChecks
{
  public void EnumExpected(IGqlpEnum ast, ExpectedEnumInput input)
    => AstExpected(ast, ExpectedEnum(input));

  protected override ToExpected<string> ExpectedAllItem(string type)
    => label => ["- !_EnumLabel", "  enum: " + type, "  name: " + label];

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedEnum(new(input));

  private string[] ExpectedEnum(ExpectedEnumInput input)
    => ["!_TypeEnum",
      .. input.ExpectedAliases,
      .. input.AllLabels,
      .. input.ExpectedDescription,
      .. input.Labels,
      "name: " + input.Name,
      .. input.Parent.TypeRefFor(SimpleKindModel.Enum),
      "typeKind: !_TypeKind Enum"];

  protected override EnumDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, []);

  internal override TypeEnumModel NewParent(string name, string[] labels, string? parent = null)
    => new(name) {
      Parent = parent?.TypeRef(SimpleKindModel.Enum),
      Items = [.. labels.Select(m => new AliasedModel(m))]
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
  IEnumerable<string>? labels = null,
  IEnumerable<string>? allLabels = null
) : ExpectedTypeInput<string>(name, parent, aliases, description)
{
#pragma warning disable CA1819 // Properties should not return arrays
  public string[] Labels { get; } = [.. labels ?? []];
  public string[] AllLabels { get; } = [.. allLabels ?? []];
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
