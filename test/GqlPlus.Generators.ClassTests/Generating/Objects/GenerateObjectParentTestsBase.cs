using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public abstract class GenerateObjectParentTestsBase<TObjField>(
  TypeKind kind
) : GenerateObjectTestsBase<TObjField>(kind)
  where TObjField : class, IGqlpObjField
{
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
  public void GenerateType_WithParentFieldParam_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent, string parentArg, string fieldName, string fieldType)
  {
    this.SkipEqual4(name, parent, parentArg, fieldType);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpObject<TObjField> parentType = A.Obj<TObjField>(Kind, parent)
      .WithTypeParam(parentArg, "_All")
      .WithObjFields(MakeField(fieldName, parentArg).IsTypeParam().AsObjField)
      .AsObject;
    context.AddTypes(parentType);

    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithParent(parent, p => p.WithArg(fieldType))
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent(TestPrefix + parent),
      ForGeneratedImplementation("I" + TestPrefix + fieldType + " " + fieldName),
      ForGeneratedImplementation(") : base(" + fieldName + ")"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParentFieldParamEnum_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string parent, string parentArg, string fieldName, string enumName, string enumLabel)
  {
    this.SkipEqual4(name, parent, parentArg, enumName);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnum enumType = A.Enum(enumName, [enumLabel]);
    IGqlpObject<TObjField> parentType = A.Obj<TObjField>(Kind, parent)
      .WithTypeParam(parentArg, "_Enum")
      .WithObjFields(MakeField(fieldName, parentArg).IsTypeParam().AsObjField)
      .AsObject;
    context.AddTypes(enumType, parentType);

    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithParent(parent, p => p.WithArg(enumName, a => a.WithObjEnum(enumLabel)))
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent(TestPrefix + parent),
      ForGeneratedImplementation("()"),
      ForGeneratedImplementation(": base(" + TestPrefix + enumName + "." + enumLabel + ")"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithGrandParentFieldParamEnum_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string grandParent, string parent, string grandParentArg, string fieldName, string enumName, string enumLabel)
  {
    this.SkipEqual4(name, parent, grandParentArg, enumName);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnum enumType = A.Enum(enumName, [enumLabel]);
    IGqlpObject<TObjField> grandParentType = A.Obj<TObjField>(Kind, grandParent)
      .WithTypeParam(grandParentArg, "_Enum")
      .WithObjFields(MakeField(fieldName, grandParentArg).IsTypeParam().AsObjField)
      .AsObject;
    IGqlpObject<TObjField> parentType = A.Obj<TObjField>(Kind, parent)
      .WithParent(grandParent, p => p.WithArg(enumName, a => a.WithObjEnum(enumLabel)))
      .AsObject;
    context.AddTypes(enumType, grandParentType, parentType);

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
  public void GenerateType_WithDeepParentFieldParamEnum_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string deepParent, string grandParent, string parent, string kindParam, string fieldName, string enumName, string enumLabel)
  {
    this.SkipEqual4(name, deepParent, grandParent, enumName);
    this.SkipEqual4(parent, kindParam, enumName, enumLabel);

    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnum enumType = A.Enum(enumName, [enumLabel]);
    // deepParent<$kindParam> with required field kindField: $kindParam
    IGqlpObject<TObjField> deepParentType = A.Obj<TObjField>(Kind, deepParent)
      .WithTypeParam(kindParam, "_Enum")
      .WithObjFields(MakeField(fieldName, kindParam).IsTypeParam().AsObjField)
      .AsObject;
    // grandParent<$kindParam> passes $kindParam through to deepParent
    IGqlpObject<TObjField> grandParentType = A.Obj<TObjField>(Kind, grandParent)
      .WithTypeParam(kindParam, "_Enum")
      .WithParent(deepParent, p => p.WithArg(kindParam, a => a.IsTypeParam()))
      .AsObject;
    // parent : grandParent<enumName.enumLabel> (concrete enum value arg)
    IGqlpObject<TObjField> parentType = A.Obj<TObjField>(Kind, parent)
      .WithParent(grandParent, p => p.WithArg(enumName, a => a.WithObjEnum(enumLabel)))
      .AsObject;
    context.AddTypes(enumType, deepParentType, grandParentType, parentType);

    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithParent(parent)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent(TestPrefix + parent),
      ForGeneratedImplementation("()"),
      ForGeneratedImplementation(": base(" + TestPrefix + enumName + "." + enumLabel + ")"));
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
}
