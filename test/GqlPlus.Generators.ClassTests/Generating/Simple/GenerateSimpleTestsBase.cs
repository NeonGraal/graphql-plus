
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public abstract class GenerateSimpleTestsBase<TSimple>
  : GenerateTypeClassTestsBase<TSimple, IGqlpTypeRef, MapPair<string>>
  where TSimple : class, IGqlpSimple
{
  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParent_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TSimple type = A.Simple<TSimple>(name)
      .WithParent(parent)
      .AsSimple;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckForRequired(
      GeneratedCodeName(generatorType, name),
      GeneratedCodeParent(generatorType, TestPrefix + parent));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithoutParent_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TSimple type = A.Simple<TSimple>(name)
      .AsSimple;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckForRequired(
      GeneratedCodeName(generatorType, name));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithItem_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string item)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    SimpleBuilder<TSimple> builder = A.Simple<TSimple>(name);
    MakeItems(builder, item);

    // Act
    TypeGenerator.GenerateType(builder.AsSimple, context);

    // Assert
    context.CheckForRequired(GeneratedCodeName(generatorType, name), item);
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithItems_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string[] items)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    SimpleBuilder<TSimple> builder = A.Simple<TSimple>(name);
    MakeItems(builder, items);

    // Act
    TypeGenerator.GenerateType(builder.AsSimple, context);

    // Assert
    context.CheckForRequired([GeneratedCodeName(generatorType, name), .. items]);
  }

  protected abstract void MakeItems(SimpleBuilder builder, params string[] items);
}
