
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public abstract class GenerateSimpleTestsBase<TSimple>
  : GenerateTypeClassTestsBase<TSimple, IGqlpTypeRef>
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
}
