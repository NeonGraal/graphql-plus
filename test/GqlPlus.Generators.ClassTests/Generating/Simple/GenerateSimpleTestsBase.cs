
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public abstract class GenerateSimpleTestsBase<TSimple>
  : GenerateTypeClassTestsBase<TSimple, IGqlpTypeRef, MapPair<string>>
  where TSimple : class, IGqlpSimple
{
  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParent_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent)
  {
    this.SkipIf(generatorType != GeneratorType);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TSimple type = MakeSimple(name)
      .WithParent(parent)
      .AsSimple;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent(TestPrefix + parent));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithoutParent_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name)
  {
    this.SkipIf(generatorType != GeneratorType);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TSimple type = MakeSimple(name)
      .AsSimple;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithItem_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string item)
  {
    this.SkipIf(generatorType != GeneratorType);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    SimpleBuilder<TSimple> builder = MakeSimple(name);
    MakeItems(builder, item);

    // Act
    TypeGenerator.GenerateType(builder.AsSimple, context);

    // Assert
    context.CheckFor(ForGeneratedCodeName(name));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithItems_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string[] items)
  {
    this.SkipIf(generatorType != GeneratorType);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    SimpleBuilder<TSimple> builder = MakeSimple(name);
    MakeItems(builder, items);

    // Act
    TypeGenerator.GenerateType(builder.AsSimple, context);

    // Assert
    context.CheckFor(ForGeneratedCodeName(name));
  }

  protected abstract SimpleBuilder<TSimple> MakeSimple(string name);
  protected abstract void MakeItems(SimpleBuilder<TSimple> builder, params string[] items);
}
