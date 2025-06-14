﻿namespace GqlPlus.Modelling;

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
    result.ShouldNotBeNull()
      .ModifierKind.ShouldBe(ModifierKind.Opt);
  }

  [Fact]
  public void TryModel_WithNullModifier_ReturnsDefault()
  {
    // Act
    ModifierModel? result = Modeller.TryModel(null, TypeKinds);

    // Assert
    result.ShouldBeNull();
  }

  [Theory, RepeatData]
  public void ToModel_WithValidCollection_ReturnsExpectedCollectionModel(string key)
  {
    // Arrange
    IGqlpModifier ast = A.Modifier(ModifierKind.Dict, key);
    ast.IsOptional.Returns(true);

    TypeKindIs(key, TypeKindModel.Basic);

    // Act
    CollectionModel result = Collection.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.ModifierKind.ShouldBe(ModifierKind.Dict),
        r => r.Key.ShouldBe(key),
        r => r.IsOptional.ShouldBeTrue());
  }

  [Fact]
  public void TryModel_WithNullCollection_ReturnsDefault()
  {
    // Act
    CollectionModel? result = Collection.TryModel(null, TypeKinds);

    // Assert
    result.ShouldBeNull();
  }

  [Fact]
  public void ToModels_WithMultipleModifiers_ReturnsExpectedModifierModels()
  {
    // Arrange
    IGqlpModifier[] astList = [A.Modifier(ModifierKind.Optional), A.Modifier(ModifierKind.List)];

    // Act
    ModifierModel[] results = Modeller.ToModels(astList, TypeKinds);

    // Assert
    results.Length.ShouldBe(2);
    results[0].ModifierKind.ShouldBe(ModifierKind.Opt);
    results[1].ModifierKind.ShouldBe(ModifierKind.List);
  }

  [Fact]
  public void TryModels_WithNullModifiers_ReturnsEmpty()
  {
    // Act
    IEnumerable<ModifierModel?> results = Modeller.TryModels(null, TypeKinds);

    // Assert
    results.ShouldBeEmpty();
  }

  [Fact]
  public void TryModels_WithSomeNullModifiers_IncludesNulls()
  {
    // Arrange
    IGqlpModifier[] astList = [A.Modifier(ModifierKind.Optional), null!, A.Modifier(ModifierKind.List)];

    // Act
    ModifierModel?[] results = [.. Modeller.TryModels(astList, TypeKinds)];

    // Assert
    results.Length.ShouldBe(3);
    results[0].ShouldNotBeNull().ModifierKind.ShouldBe(ModifierKind.Opt);
    results[1].ShouldBeNull();
    results[2].ShouldNotBeNull().ModifierKind.ShouldBe(ModifierKind.List);
  }

  [Theory, RepeatData]
  public void ToModels_WithMultipleCollections_ReturnsExpectedModifierModels(string key)
  {
    // Arrange
    IGqlpModifier[] astList = [A.Modifier(ModifierKind.Dict, key), A.Modifier(ModifierKind.List)];

    // Act
    CollectionModel[] results = Collection.ToModels(astList, TypeKinds);

    // Assert
    results.Length.ShouldBe(2);
    results[0].ModifierKind.ShouldBe(ModifierKind.Dict);
    results[1].ModifierKind.ShouldBe(ModifierKind.List);
  }

  [Fact]
  public void TryModels_WithNullCollections_ReturnsEmpty()
  {
    // Act
    IEnumerable<CollectionModel?> results = Collection.TryModels(null, TypeKinds);

    // Assert
    results.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void TryModels_WithSomeNullCollections_IncludesNulls(string key)
  {
    // Arrange
    IGqlpModifier[] astList = [A.Modifier(ModifierKind.Dict, key), null!, A.Modifier(ModifierKind.List)];

    // Act
    CollectionModel?[] results = [.. Collection.TryModels(astList, TypeKinds)];

    // Assert
    results.Length.ShouldBe(3);
    results[0].ShouldNotBeNull().ModifierKind.ShouldBe(ModifierKind.Dict);
    results[1].ShouldBeNull();
    results[2].ShouldNotBeNull().ModifierKind.ShouldBe(ModifierKind.List);
  }
}
