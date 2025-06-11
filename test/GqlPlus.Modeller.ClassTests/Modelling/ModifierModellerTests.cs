namespace GqlPlus.Modelling;

public class ModifierModellerTests
  : ModellerClassTestBase<IGqlpModifier, ModifierModel>
{
  private readonly ModifierModeller _modeller = new();

  private IModeller<IGqlpModifier, CollectionModel> Collection => _modeller;

  protected override IModeller<IGqlpModifier, ModifierModel> Modeller => _modeller;

  [Fact]
  public void ToModel_WithValidModifier_ReturnsExpectedModifierModel()
  {
    // Arrange
    IGqlpModifier ast = A.Modifier(ModifierKind.Optional);

    // Act
    ModifierModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.ModifierKind.ShouldBe(ModifierKind.Opt);
  }

  [Fact]
  public void TryModel_WithNullModifier_ReturnsDefault()
  {
    // Act
    ModifierModel? result = Modeller.TryModel(null, TypeKinds);

    // Assert
    result.ShouldBeNull();
  }

  [Fact]
  public void ToModel_WithValidCollection_ReturnsExpectedCollectionModel()
  {
    // Arrange
    IGqlpModifier ast = A.Modifier(ModifierKind.Dict, "key");
    ast.IsOptional.Returns(true);

    TypeKindIs("key", TypeKindModel.Basic);

    // Act
    CollectionModel result = Collection.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.Key.ShouldBe("key");
    result.IsOptional.ShouldBeTrue();
  }

  [Fact]
  public void TryModel_WithNullCollection_ReturnsDefault()
  {
    // Act
    CollectionModel? result = Collection.TryModel(null, TypeKinds);

    // Assert
    result.ShouldBeNull();
  }
}
