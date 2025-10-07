﻿namespace GqlPlus.Generating.Objects;

public abstract class ObjectGeneratorTestBase<TObject, TField>
  : TypeGeneratorClassTestBase<TObject, IGqlpObjBase>
  where TObject : class, IGqlpObject<TField>
  where TField : class, IGqlpObjField
{
  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithField_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TObject obj = A.Parented<TObject, IGqlpObjBase>(name);
    IGqlpObjBase type = A.Named<IGqlpObjBase>(fieldType);
    TField field = A.Named<TField>(fieldName);
    field.Type.Returns(type);
    obj.Fields.Returns([field]);

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedCodeField(generatorType, fieldName, fieldType));
  }

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithAlternate_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string alternateType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TObject obj = A.Parented<TObject, IGqlpObjBase>(name);
    IGqlpObjAlt alternate = A.Named<IGqlpObjAlt>(alternateType);
    obj.Alternates.Returns([alternate]);

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedCodeAlternate(generatorType, alternateType));
  }

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithAlternateArgs_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string alternateType, string argName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TObject obj = A.Parented<TObject, IGqlpObjBase>(name);
    IGqlpObjAlt alternate = A.Named<IGqlpObjAlt>(alternateType);
    IGqlpObjTypeArg arg = A.Named<IGqlpObjTypeArg>(argName);
    alternate.Args.Returns([arg]);
    obj.Alternates.Returns([alternate]);

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedCodeAlternateArg(generatorType, alternateType, argName));
  }

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithFieldAndAlternate_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType, string alternateType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TObject obj = A.Parented<TObject, IGqlpObjBase>(name);
    IGqlpObjBase type = A.Named<IGqlpObjBase>(fieldType);
    TField field = A.Named<TField>(fieldName);
    field.Type.Returns(type);
    IGqlpObjAlt alternate = A.Named<IGqlpObjAlt>(alternateType);

    obj.Fields.Returns([field]);
    obj.Alternates.Returns([alternate]);

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedCodeField(generatorType, fieldName, fieldType),
      CheckGeneratedCodeAlternate(generatorType, alternateType));
  }

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithParams_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string[] parameters)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    TObject type = A.Parented<TObject, IGqlpObjBase>(name);
    IGqlpTypeParam[] typeParams = [.. parameters.Select(A.Named<IGqlpTypeParam>)];
    type.TypeParams.Returns(typeParams);

    // Act
    TypeGenerator.GenerateType(type, context);

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
    => ObjectGeneratorTestBase<TObject, TField>.CheckGeneratedBoth(generatorType, fieldType + " " + fieldName + " { get;");

  protected virtual Action<string> CheckGeneratedCodeAlternate(GqlpGeneratorType generatorType, string alternateType)
    => ObjectGeneratorTestBase<TObject, TField>.CheckGeneratedBoth(generatorType, $"{alternateType} As{alternateType} {{ get;");

  protected virtual Action<string> CheckGeneratedCodeAlternateArg(GqlpGeneratorType generatorType, string alternateType, string argName)
    => ObjectGeneratorTestBase<TObject, TField>.CheckGeneratedBoth(generatorType, $"{alternateType}<{argName}> As{alternateType} {{ get;");
}
