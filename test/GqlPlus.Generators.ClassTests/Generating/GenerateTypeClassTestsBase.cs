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
    context.CheckFor(ForGeneratedCodeName(name));
  }
}

public abstract class GenerateTypeClassTestsBase
  : GenerateClassTestsBase
{
  internal ForType ForGeneratedImplementation(string contains)
    => generatorType => GqlpGeneratorType.Implementation == generatorType
      ? r => r.ShouldContain(contains)
      : r => { };

  internal ForType ForGeneratedInterface(string contains)
    => generatorType => GqlpGeneratorType.Interface == generatorType
      ? r => r.ShouldContain(contains)
      : r => { };

  internal ForType ForGeneratedEnum(string contains)
    => generatorType => GqlpGeneratorType.Enum == generatorType
      ? r => r.ShouldContain(contains)
      : r => r.ShouldBeEmpty();

  internal ForType ForGeneratedBoth(string contains)
    => ForGeneratedEither(contains, contains);

  internal ForType ForGeneratedEither(string genIntf, string genImpl)
    => generatorType => generatorType switch {
      GqlpGeneratorType.Interface
        => r => r.ShouldContain(genIntf),
      GqlpGeneratorType.Implementation
        => r => r.ShouldContain(genImpl),
      _ => result => { }
    };

  internal virtual ForType ForGeneratedCodeName(string name)
    => ForGeneratedEither("public interface I" + TestPrefix + name, "public class " + TestPrefix + name);

  internal virtual ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedEither(": I" + parent, ": " + parent);
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
