
using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public abstract class GenerateSimpleTestsBase<TSimple>
  : GenerateTypeClassTestsBase<TSimple, IAstTypeRef, MapPair<string>>
  where TSimple : class, IAstSimple
{
  [Theory, RepeatData]
  public void GenerateType_WithParent_GeneratesCorrectCode(string name, string parent)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
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

  [Theory, RepeatData]
  public void GenerateType_WithoutParent_GeneratesCorrectCode(string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    TSimple type = MakeSimple(name)
      .AsSimple;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name));
  }

  [Theory, RepeatData]
  public void GenerateType_WithItem_GeneratesCorrectCode(string name, string item)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    SimpleBuilder<TSimple> builder = MakeSimple(name);
    MakeItems(builder, item);

    // Act
    TypeGenerator.GenerateType(builder.AsSimple, context);

    // Assert
    context.CheckFor(ForGeneratedCodeName(name));
  }

  [Theory, RepeatData]
  public void GenerateType_WithItems_GeneratesCorrectCode(string name, string[] items)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
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
