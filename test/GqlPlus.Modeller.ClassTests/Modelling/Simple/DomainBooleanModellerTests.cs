namespace GqlPlus.Modelling.Simple;

public class DomainBooleanModellerTests
  : DomainModellerClassTestBase<IGqlpDomainTrueFalse, DomainTrueFalseModel>
{
  protected override IDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel> DomainModeller { get; }
    = new DomainBooleanModeller();

  protected override DomainKind Kind => DomainKind.Boolean;
  protected override DomainKindModel KindModel => DomainKindModel.Boolean;

  [Theory, RepeatData]
  public void ToModel_WithBooleanItems_ReturnsCorrectBaseDomainModel(
    string name,
    string parent,
    bool[] boolValues,
    bool[] excludeValues)
  {
    // Arrange
    ArgumentNullException.ThrowIfNull(boolValues);
    ArgumentNullException.ThrowIfNull(excludeValues);
    this.SkipIf(boolValues.Length != excludeValues.Length);

    IGqlpDomainTrueFalse[] items = [.. boolValues.Zip(excludeValues, A.DomainTrueFalse)];

    IGqlpDomain<IGqlpDomainTrueFalse> ast = A.Domain(name, [], parent, "", Kind, items);

    // Act
    BaseDomainModel<DomainTrueFalseModel> result = DomainModeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.DomainKind.ShouldBe(DomainKindModel.Boolean),
        r => r.Parent.ShouldNotBeNull().TypeName.ShouldBe(parent),
        r => r.Items.Length.ShouldBe(boolValues.Length),
        r => r.AllItems.Length.ShouldBe(boolValues.Length));

    // Verify individual items
    for (int i = 0; i < boolValues.Length; i++) {
      result.Items[i].ShouldSatisfyAllConditions(
        item => item.Value.ShouldBe(boolValues[i]),
        item => item.Exclude.ShouldBe(excludeValues[i]));

      result.AllItems[i].ShouldSatisfyAllConditions(
        allItem => allItem.Item.Value.ShouldBe(boolValues[i]),
        allItem => allItem.Item.Exclude.ShouldBe(excludeValues[i]),
        allItem => allItem.Domain.ShouldBe(name));
    }
  }

  [Theory, RepeatData]
  public void ToModel_WithEmptyItems_ReturnsBaseDomainModelWithEmptyCollections(
    string name,
    string parent)
  {
    // Arrange
    IGqlpDomain<IGqlpDomainTrueFalse> ast = A.Domain<IGqlpDomainTrueFalse>(name, [], parent, "", Kind);

    // Act
    BaseDomainModel<DomainTrueFalseModel> result = DomainModeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.DomainKind.ShouldBe(DomainKindModel.Boolean),
        r => r.Parent.ShouldNotBeNull().TypeName.ShouldBe(parent),
        r => r.Items.ShouldBeEmpty(),
        r => r.AllItems.ShouldBeEmpty());
  }

  [Fact]
  public void ToModel_WithMixedTrueFalseValues_ReturnsCorrectModels()
  {
    // Arrange
    IGqlpDomainTrueFalse trueItem = A.DomainTrueFalse(true, false);
    IGqlpDomainTrueFalse falseItem = A.DomainTrueFalse(false, true);
    IGqlpDomainTrueFalse excludedTrueItem = A.DomainTrueFalse(true, true);

    IGqlpDomain<IGqlpDomainTrueFalse> ast = A.Domain<IGqlpDomainTrueFalse>("TestDomain", [], "parent", "",
      Kind, trueItem, falseItem, excludedTrueItem);

    // Act
    BaseDomainModel<DomainTrueFalseModel> result = DomainModeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.Items.Length.ShouldBe(3);

    result.Items[0].ShouldSatisfyAllConditions(
      item => item.Value.ShouldBeTrue(),
      item => item.Exclude.ShouldBeFalse());

    result.Items[1].ShouldSatisfyAllConditions(
      item => item.Value.ShouldBeFalse(),
      item => item.Exclude.ShouldBeTrue());

    result.Items[2].ShouldSatisfyAllConditions(
      item => item.Value.ShouldBeTrue(),
      item => item.Exclude.ShouldBeTrue());
  }
}
