namespace GqlPlus.Generating;

public abstract class GenerateTypeClassTestsBase<TType, TParent, TMember>
  : GenerateTypeClassTestsBase
  where TType : class, IGqlpType<TParent>
  where TParent : class, IGqlpNamed
{
  internal abstract GenerateForType<TType> TypeGenerator { get; }
  internal abstract GqlpGeneratorType GeneratorType { get; }
  internal abstract GqlpBaseType BaseType { get; }

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

  [Theory, RepeatData]
  public void GenerateType_WithName_GeneratesCorrectCode(string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
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
  internal virtual ForType ForGeneratedModel(string contains)
    => generatorType => GqlpGeneratorType.Model == generatorType
      ? r => r.ShouldContain(contains)
      : r => { };

  internal virtual ForType ForGeneratedInterface(string contains)
    => generatorType => GqlpGeneratorType.Interface == generatorType
      ? r => r.ShouldContain(contains)
      : r => { };

  internal virtual ForType ForGeneratedDecoder(string contains)
    => generatorType => GqlpGeneratorType.Dec == generatorType
      ? r => r.ShouldContain(contains)
      : r => { };

  internal virtual ForType ForGeneratedEncoder(string contains)
    => generatorType => GqlpGeneratorType.Enc == generatorType
      ? r => r.ShouldContain(contains)
      : r => { };

  internal virtual ForType ForGeneratedBoth(string contains)
    => ForGeneratedEither(contains, contains);

  internal ForType ForGeneratedEither(string genIntf, string genImpl)
    => generatorType => generatorType switch {
      GqlpGeneratorType.Interface or GqlpGeneratorType.Dec
        => r => r.ShouldContain(genIntf),
      GqlpGeneratorType.Model or GqlpGeneratorType.Enc
        => r => r.ShouldContain(genImpl),
      _ => result => { }
    };

  internal virtual ForType ForGeneratedCodeName(string name)
    => ForGeneratedEither("public interface I" + TestPrefix + name, "public class " + TestPrefix + name);

  internal virtual ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedEither(": I" + parent, ": " + parent);
}
