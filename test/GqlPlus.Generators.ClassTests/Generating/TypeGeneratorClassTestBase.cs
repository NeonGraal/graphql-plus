namespace GqlPlus.Generating;

public abstract class TypeGeneratorClassTestBase<TType, TParent>
  : TypeGeneratorClassTestBase
  where TType : class, IGqlpType<TParent>
  where TParent : class, IGqlpNamed
{
  internal abstract GenerateForType<TType> TypeGenerator { get; }

  [Fact]
  public void ForType_WithType_ReturnsTrue()
  {
    // Arrange
    TType type = A.Error<TType>();

    // Act
    bool result = TypeGenerator.ForType(type);

    // Assert
    result.ShouldBeTrue();
  }

  [Fact]
  public void ForType_WithNotType_ReturnsFalse()
  {
    // Arrange
    IGqlpTypeSpecial type = A.Error<IGqlpTypeSpecial>();

    // Act
    bool result = TypeGenerator.ForType(type);

    // Assert
    result.ShouldBeFalse();
  }

  [Fact]
  public void TypePrefix_ReturnsExpected() =>
    TypeGenerator.TypePrefix.ShouldBe(ExpectedTypePrefix);

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithName_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TType type = A.Parented<TType, TParent>(name);

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    string result = context.ToString();
    CheckGeneratedCodeName(generatorType, name)(result);
  }

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithParent_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TType type = A.Parented<TType, TParent>(name, parent);

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedCodeParent(generatorType, parent));
  }
}

public abstract class TypeGeneratorClassTestBase
  : GeneratorClassTestBase
{
  public abstract string ExpectedTypePrefix { get; }

  protected virtual Action<string> CheckGeneratedCodeName(GqlpGeneratorType generatorType, string name)
    => result => {
      switch (generatorType) {
        case GqlpGeneratorType.Interface: result.ShouldContain("public interface I" + name); break;
        case GqlpGeneratorType.Implementation: result.ShouldContain("public class " + ExpectedTypePrefix + name); break;
        default: result.ShouldBeEmpty(); break;
      }
    };

  protected virtual Action<string> CheckGeneratedCodeParent(GqlpGeneratorType generatorType, string parent)
    => result => {
      switch (generatorType) {
        case GqlpGeneratorType.Interface: result.ShouldContain(": I" + parent); break;
        case GqlpGeneratorType.Implementation: result.ShouldContain(": " + ExpectedTypePrefix + parent); break;
        default: result.ShouldBeEmpty(); break;
      }
    };

  public static IEnumerable<object[]> BaseGeneratorData
    => [
        [GqlpBaseType.Interface, GqlpGeneratorType.Interface],
        [GqlpBaseType.Class, GqlpGeneratorType.Implementation],
        [GqlpBaseType.Other, GqlpGeneratorType.Enum],
        [GqlpBaseType.Other, GqlpGeneratorType.Static],
        [GqlpBaseType.Other, GqlpGeneratorType.Enum],
        [GqlpBaseType.Class, GqlpGeneratorType.Test],
      ];
}
