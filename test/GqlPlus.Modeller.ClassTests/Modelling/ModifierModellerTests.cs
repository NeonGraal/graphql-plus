namespace GqlPlus.Modelling;

public class ModifierModellerTests
  : ModellerClassTestBase
{
  private readonly ModifierModeller _modeller;

  private IModeller<IGqlpModifier, CollectionModel> Collection => _modeller;
  private IModeller<IGqlpModifier, ModifierModel> Modifier => _modeller;

  public ModifierModellerTests()
    => _modeller = new ModifierModeller();

  [Fact]
  public void ToModel_WithValidModifier_ReturnsExpectedModifierModel()
  {
    // Arrange
    IGqlpModifier ast = For<IGqlpModifier>();
    ast.ModifierKind.Returns(ModifierKind.Optional);

    // Act
    ModifierModel result = Modifier.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.ModifierKind.ShouldBe(ModifierKind.Opt);
  }

  [Fact]
  public void TryModel_WithNullModifier_ReturnsDefault()
  {
    // Act
    ModifierModel? result = Modifier.TryModel(null, TypeKinds);

    // Assert
    result.ShouldBeNull();
  }

  [Fact]
  public void ToModel_WithValidCollection_ReturnsExpectedCollectionModel()
  {
    // Arrange
    IGqlpModifier ast = For<IGqlpModifier>();
    ast.ModifierKind.Returns(ModifierKind.Dict);
    ast.Key.Returns("key");
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
