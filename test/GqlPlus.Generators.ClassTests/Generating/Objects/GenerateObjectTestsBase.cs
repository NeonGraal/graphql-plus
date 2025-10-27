using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public abstract class GenerateObjectTestsBase<TObjField>(
  TypeKind kind
) : GenerateTypeClassTestsBase<IGqlpObject<TObjField>, IGqlpObjBase>
  where TObjField : class, IGqlpObjField
{
  protected TypeKind Kind { get; } = kind;

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParent_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithParent(parent)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckForRequired(
      GeneratedCodeName(generatorType, name),
      GeneratedCodeParent(generatorType, parent));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithField_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(A.ObjField<TObjField>(fieldName, fieldType).AsObjField)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedCodeField(generatorType, fieldName, fieldType));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithAlternate_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string alternateType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithAlternate(alternateType)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedCodeAlternate(generatorType, alternateType));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithAlternateArgs_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string alternateType, string argName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithAlternate(alternateType, a => a.WithArg(argName))
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedCodeAlternateArg(generatorType, alternateType, argName));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithFieldAndAlternate_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType, string alternateType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(A.ObjField<TObjField>(fieldName, fieldType).AsObjField)
      .WithAlternate(alternateType)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedCodeField(generatorType, fieldName, fieldType),
      CheckGeneratedCodeAlternate(generatorType, alternateType));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParams_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string[] parameters)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithTypeParams([.. parameters.Select(t => A.TypeParam(t, "String"))])
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    CheckGeneratedCodeName(generatorType, name + parameters.Surround("<", ">", s => "T" + s, ","))(result);
  }

  private static Action<string> CheckGeneratedBoth(GqlpGeneratorType generatorType, string contains)
    => result => {
      switch (generatorType) {
        case GqlpGeneratorType.Interface:
        case GqlpGeneratorType.Implementation:
          result.ShouldContain(contains);
          break;
        default:
          result.ShouldBeEmpty();
          break;
      }
    };

  protected virtual Action<string> CheckGeneratedCodeField(GqlpGeneratorType generatorType, string fieldName, string fieldType)
    => GenerateObjectTestsBase<TObjField>.CheckGeneratedBoth(generatorType, fieldType + " " + fieldName + " { get;");

  protected virtual Action<string> CheckGeneratedCodeAlternate(GqlpGeneratorType generatorType, string alternateType)
    => GenerateObjectTestsBase<TObjField>.CheckGeneratedBoth(generatorType, $"{alternateType} As{alternateType} {{ get;");

  protected virtual Action<string> CheckGeneratedCodeAlternateArg(GqlpGeneratorType generatorType, string alternateType, string argName)
    => GenerateObjectTestsBase<TObjField>.CheckGeneratedBoth(generatorType, $"{alternateType}<{argName}> As{alternateType} {{ get;");

  internal override GenerateForType<IGqlpObject<TObjField>> TypeGenerator { get; }
    = new GenerateForObject<TObjField>();
}
