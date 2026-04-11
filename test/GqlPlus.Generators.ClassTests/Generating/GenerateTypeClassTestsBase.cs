using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating;

public abstract class GenerateTypeClassTestsBase<TType, TParent, TMember>
  : GenerateTypeClassTestsBase
  where TType : class, IAstType<TParent>
  where TParent : class, IAstNamed
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
    IAstTypeSpecial type = A.Error<IAstTypeSpecial>();

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
    => generatorType => generatorType switch {
      GqlpGeneratorType.Interface
        => r => r.ShouldContain(contains),
      GqlpGeneratorType.Model
        => r => r.ShouldContain(contains),
      _ => result => { }
    };

  internal ForType ForGeneratedAll(string genIntf, string genImpl, string genDec, string genEnc)
    => generatorType => generatorType switch {
      GqlpGeneratorType.Interface
        => r => r.ShouldContain(genIntf),
      GqlpGeneratorType.Model
        => r => r.ShouldContain(genImpl),
      GqlpGeneratorType.Dec
        => r => r.ShouldContain(genDec),
      GqlpGeneratorType.Enc
        => r => r.ShouldContain(genEnc),
      _ => result => { }
    };

  internal virtual ForType ForGeneratedCodeName(string name)
    => ForGeneratedAll(
      "public interface I" + TestPrefix + name,
      "public class " + TestPrefix + name,
      "internal class " + TestPrefix + name + "Decoder",
      "internal class " + TestPrefix + name + "Encoder");

  internal virtual ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedAll(
      ": I" + parent,
      ": " + parent,
      ": " + parent + "Decoder",
      ": " + parent + "Encoder");
}
