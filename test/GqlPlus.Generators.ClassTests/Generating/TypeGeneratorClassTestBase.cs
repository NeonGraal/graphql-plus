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

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithName_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TType type = A.Parented<TType, TParent>(name);

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckForRequired(GeneratedCodeName(generatorType, name));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParent_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TType type = A.Parented<TType, TParent>(name, parent);

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckForRequired(
      GeneratedCodeName(generatorType, name),
      GeneratedCodeParent(generatorType, parent));
  }
}

public abstract class TypeGeneratorClassTestBase
  : GeneratorClassTestBase
{
  protected virtual string GeneratedCodeName(GqlpGeneratorType generatorType, string name)
    => generatorType switch {
      GqlpGeneratorType.Interface
        => "public interface Itest" + name,
      GqlpGeneratorType.Implementation
        => "public class test" + name,
      _ => ""
    };

  protected virtual Action<string> CheckGeneratedCodeName(GqlpGeneratorType generatorType, string name)
    => result => {
      switch (generatorType) {
        case GqlpGeneratorType.Interface: result.ShouldContain("public interface Itest" + name); break;
        case GqlpGeneratorType.Implementation: result.ShouldContain("public class test" + name); break;
        default: result.ShouldBeEmpty(); break;
      }
    };

  protected virtual string GeneratedCodeParent(GqlpGeneratorType generatorType, string parent)
    => generatorType switch {
      GqlpGeneratorType.Interface => ": I" + "test" + parent,
      GqlpGeneratorType.Implementation => ": test" + parent,
      _ => "",
    };

  protected virtual Action<string> CheckGeneratedCodeParent(GqlpGeneratorType generatorType, string parent)
    => result => {
      switch (generatorType) {
        case GqlpGeneratorType.Interface: result.ShouldContain(": I" + "test" + parent); break;
        case GqlpGeneratorType.Implementation: result.ShouldContain(": test" + parent); break;
        default: result.ShouldBeEmpty(); break;
      }
    };
}

public class BaseGeneratorData
  : TheoryData<GqlpBaseType, GqlpGeneratorType>
{
  public BaseGeneratorData()
  {
    Add(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    Add(GqlpBaseType.Class, GqlpGeneratorType.Implementation);
    Add(GqlpBaseType.Other, GqlpGeneratorType.Enum);
    Add(GqlpBaseType.Other, GqlpGeneratorType.Static);
    Add(GqlpBaseType.Other, GqlpGeneratorType.Enum);
    Add(GqlpBaseType.Class, GqlpGeneratorType.Test);
  }
}
