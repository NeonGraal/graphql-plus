namespace GqlPlus.Generating;

public abstract class GenerateTypeClassTestsBase<TType, TParent, TMember>
  : GenerateTypeClassTestsBase
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
    TType type = A.Named<TType>(name);

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckForRequired(GeneratedCodeName(generatorType, name));
  }
}

public abstract class GenerateTypeClassTestsBase
  : GenerateClassTestsBase
{
  protected virtual string GeneratedCodeName(GqlpGeneratorType generatorType, string name)
    => generatorType switch {
      GqlpGeneratorType.Interface
        => "public interface I" + TestPrefix + name,
      GqlpGeneratorType.Implementation
        => "public class " + TestPrefix + name,
      _ => ""
    };

  protected virtual Action<string> CheckGeneratedCodeName(GqlpGeneratorType generatorType, string name)
    => result => {
      switch (generatorType) {
        case GqlpGeneratorType.Interface: result.ShouldContain("public interface I" + TestPrefix + name); break;
        case GqlpGeneratorType.Implementation: result.ShouldContain("public class " + TestPrefix + name); break;
        default: result.ShouldBeEmpty(); break;
      }
    };

  protected virtual string GeneratedCodeParent(GqlpGeneratorType generatorType, string parent)
    => generatorType switch {
      GqlpGeneratorType.Interface => ": I" + parent,
      GqlpGeneratorType.Implementation => ": " + parent,
      _ => "",
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
