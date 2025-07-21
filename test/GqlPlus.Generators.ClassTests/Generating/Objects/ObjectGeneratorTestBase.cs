namespace GqlPlus.Generating.Objects;

public abstract class ObjectGeneratorTestBase<TObject, TBase, TField, TAlt>
  : TypeGeneratorClassTestBase<TObject, IGqlpObjBase>
  where TObject : class, IGqlpObject<TBase, TField, TAlt>
  where TBase : class, IGqlpObjBase
  where TField : class, IGqlpObjField
  where TAlt : class, IGqlpObjAlternate
{
  [Theory, RepeatData]
  public void GenerateType_WithField_GeneratesCorrectCode(string name, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    TObject obj = A.Parented<TObject, IGqlpObjBase>(name);
    TBase type = A.Named<TBase>(fieldType);
    TField field = A.Named<TField>(fieldName);
    field.Type.Returns(type);
    obj.Fields.Returns([field]);

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(name),
      CheckGeneratedCodeField(fieldName, fieldType));
  }

  protected virtual Action<string> CheckGeneratedCodeField(string fieldName, string fieldType)
    => result => result.ShouldContain(fieldType + " " + fieldName + " { get; }");

  [Theory, RepeatData]
  public void GenerateType_WithAlternate_GeneratesCorrectCode(string name, string alternateType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    TObject obj = A.Parented<TObject, IGqlpObjBase>(name);
    TAlt alternate = A.Named<TAlt>(alternateType);
    obj.Alternates.Returns([alternate]);

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(name),
      CheckGeneratedCodeAlternate(alternateType));
  }

  [Theory, RepeatData]
  public void GenerateType_WithAlternateArgs_GeneratesCorrectCode(string name, string alternateType, string argName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    TObject obj = A.Parented<TObject, IGqlpObjBase>(name);
    TAlt alternate = A.Named<TAlt>(alternateType);
    IGqlpObjArg arg = A.Named<IGqlpObjArg>(argName);
    alternate.Args.Returns([arg]);
    obj.Alternates.Returns([alternate]);

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(name),
      CheckGeneratedCodeAlternateArg(alternateType, argName));
  }

  protected virtual Action<string> CheckGeneratedCodeAlternate(string alternateType)
    => result => result.ShouldContain($"{alternateType} As{alternateType} {{ get; }}");

  protected virtual Action<string> CheckGeneratedCodeAlternateArg(string alternateType, string argName)
    => result => result.ShouldContain($"{alternateType}<{argName}> As{alternateType} {{ get; }}");

  [Theory, RepeatData]
  public void GenerateType_WithFieldAndAlternate_GeneratesCorrectCode(string name, string fieldName, string fieldType, string alternateType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    TObject obj = A.Parented<TObject, IGqlpObjBase>(name);
    TBase type = A.Named<TBase>(fieldType);
    TField field = A.Named<TField>(fieldName);
    field.Type.Returns(type);
    TAlt alternate = A.Named<TAlt>(alternateType);

    obj.Fields.Returns([field]);
    obj.Alternates.Returns([alternate]);

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(name),
      CheckGeneratedCodeField(fieldName, fieldType),
      CheckGeneratedCodeAlternate(alternateType));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParams_GeneratesCorrectCode(string name, string[] parameters)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    TObject type = A.Parented<TObject, IGqlpObjBase>(name);
    IGqlpTypeParam[] typeParams = [.. parameters.Select(A.Named<IGqlpTypeParam>)];
    type.TypeParams.Returns(typeParams);

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    string result = context.ToString();
    CheckGeneratedCodeName(name + parameters.Surround("<", ">", s => "T" + s, ","))(result);
  }
}
