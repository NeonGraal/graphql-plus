namespace GqlPlus.Generating;

public abstract class TypeGeneratorClassTestBase<TType, TParent>
  : GeneratorClassTestBase
  where TType : class, IGqlpType<TParent>
  where TParent : class, IGqlpNamed
{
  public abstract string ExpectedTypePrefix { get; }
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
  public void TypePrefix_ReturnsDomain() =>
    TypeGenerator.TypePrefix.ShouldBe(ExpectedTypePrefix);

  [Theory, RepeatData]
  public void GenerateType_WithName_GeneratesCorrectCode(string name)
  {
    // Arrange
    GqlpGeneratorContext context = BaseContext();
    TType type = A.Parented<TType, TParent>(name);

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    string result = context.ToString();
    CheckGeneratedCodeName(name)(result);
  }

  [Theory, RepeatData]
  public void GenerateType_WithParent_GeneratesCorrectCode(string name, string parent)
  {
    // Arrange
    GqlpGeneratorContext context = BaseContext();
    TType type = A.Parented<TType, TParent>(name, parent);

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(name),
      CheckGeneratedCodeParent(parent));
  }

  internal virtual GqlpGeneratorContext BaseContext()
    => Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);

  protected virtual Action<string> CheckGeneratedCodeName(string name)
    => result => result.ShouldContain("public interface I" + name);

  protected virtual Action<string> CheckGeneratedCodeParent(string parent)
    => result => result.ShouldContain(": I" + parent);
}
