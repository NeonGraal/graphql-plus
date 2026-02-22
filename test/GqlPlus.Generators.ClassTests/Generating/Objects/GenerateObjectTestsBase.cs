using GqlPlus.Building;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public abstract class GenerateObjectTestsBase<TObjField>(
  TypeKind kind
) : GenerateTypeClassTestsBase<IGqlpObject<TObjField>, IGqlpObjBase, MapPair<string>>
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
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent(TestPrefix + parent));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParentArg_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent, string parentArg)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithParent(parent, p => p.WithArg(parentArg))
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent(TestPrefix + parent));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParentField_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> parentType = A.Obj<TObjField>(Kind, parent)
      .WithObjFields(MakeField(fieldName, fieldType).AsObjField)
      .AsObject;
    context.AddTypes(parentType);
    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithParent(parent)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent(TestPrefix + parent),
      ForGeneratedImplementation("I" + TestPrefix + fieldType + " " + fieldName),
      ForGeneratedImplementation(": base(" + fieldName + ")"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParentFieldParam_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent, string fieldName, string fieldType, string parentArg)
  {
    this.SkipEqual3(name, parent, parentArg);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> parentType = A.Obj<TObjField>(Kind, parent)
      .WithTypeParam(fieldType, "_All")
      .WithObjFields(MakeField(fieldName, fieldType).IsTypeParam().AsObjField)
      .AsObject;
    context.AddTypes(parentType);

    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithParent(parent, p => p.WithArg(parentArg))
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent(TestPrefix + parent),
      ForGeneratedImplementation("I" + TestPrefix + parentArg + " " + fieldName),
      ForGeneratedImplementation(": base(" + fieldName + ")"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParentParam_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithTypeParam(parent, "_Any")
      .WithParent(parent, p => p.IsTypeParam())
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedImplementation("T" + parent + "? As_Parent"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithField_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(MakeField(fieldName, fieldType).AsObjField)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedBoth("I" + TestPrefix + fieldType + " " + fieldName + " { get;"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithOptField_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(MakeField(fieldName, fieldType)
        .WithModifier(ModifierKind.Optional)
        .AsObjField)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedBoth("I" + TestPrefix + fieldType + "? " + fieldName + " { get;"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithListField_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(MakeField(fieldName, fieldType)
        .WithModifier(ModifierKind.List)
        .AsObjField)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedBoth("ICollection<I" + TestPrefix + fieldType + "> " + fieldName + " { get;"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithDictField_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType, string fieldKey)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(MakeField(fieldName, fieldType)
        .WithModifier(ModifierKind.Dict, fieldKey)
        .AsObjField)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedBoth("IDictionary<I" + TestPrefix + fieldKey + ", I" + TestPrefix + fieldType + "> " + fieldName + " { get;"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParamField_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType, string fieldParam)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(MakeField(fieldName, fieldType)
        .WithModifier(ModifierKind.Param, fieldParam)
        .AsObjField)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedBoth("IDictionary<T" + fieldParam + ", I" + TestPrefix + fieldType + "> " + fieldName + " { get;"));
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
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedInterface($"I{TestPrefix}{alternateType}? As{alternateType} {{ get;"));
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
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedInterface($"I{TestPrefix}{alternateType}<I{TestPrefix}{argName}>? As{alternateType} {{ get;"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithAlternateEnum_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string enumType, string enumLabel)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithAlternate(enumType, a => a.WithObjEnum(enumLabel))
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedInterface($"{TestPrefix}{enumType}? As{enumType}{enumLabel} {{ get;"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithAlternateEnumArg_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string alternateType, string enumType, string enumLabel1, string enumLabel2)
  {
    this.SkipEqual5(name, alternateType, enumType, enumLabel1, enumLabel2);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnum theEnum = A.Enum(enumType, [enumLabel1, enumLabel2]);
    context.AddTypes(theEnum);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithAlternates(
      A.Alternate(alternateType).WithArg(enumType, e => e.WithObjEnum(enumLabel1)),
      A.Alternate(alternateType).WithArg(enumType, e => e.WithObjEnum(enumLabel2))
      ).AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    string expectedPrefix = $"I{TestPrefix}{alternateType}<{TestPrefix}{enumType}>? As{enumType}";
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedInterface($"{expectedPrefix}{enumLabel2} {{ get;"),
      ForGeneratedInterface($"{expectedPrefix}{enumLabel1} {{ get;"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithAlternateParam_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string alternateParam)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithTypeParam(alternateParam, "_Any")
      .WithAlternate(alternateParam, a => a.IsTypeParam())
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedInterface($"T{alternateParam}? As{alternateParam} {{ get;"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithFieldAndAlternate_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType, string alternateType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(MakeField(fieldName, fieldType).AsObjField)
      .WithAlternate(alternateType)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedBoth("I" + TestPrefix + fieldType + " " + fieldName + " { get;"),
      ForGeneratedInterface($"I{TestPrefix}{alternateType}? As{alternateType} {{ get;"));
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
    context.CheckFor(
       ForGeneratedCodeName(name + parameters.Surround("<", ">", s => "T" + s, ",")));
  }

  protected abstract ObjFieldBuilder<TObjField> MakeField(string name, string type);
}
