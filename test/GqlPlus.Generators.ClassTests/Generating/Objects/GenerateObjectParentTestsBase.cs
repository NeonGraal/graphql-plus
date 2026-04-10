using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public abstract class GenerateObjectParentTestsBase<TObjField>(
  TypeKind kind
) : GenerateObjectTestsBase<TObjField>(kind)
  where TObjField : class, IGqlpObjField
{
  [Theory, RepeatData]
  public void GenerateType_WithParent_GeneratesCorrectCode(string name, string parent)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
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

  [Theory, RepeatData]
  public void GenerateType_WithParentArg_GeneratesCorrectCode(string name, string parent, string parentArg)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
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

  [Theory, RepeatData]
  public void GenerateType_WithParentField_GeneratesCorrectCode(string name, string parent, string fieldName, string fieldType)
  {
    SkipBuiltInTypes(name, parent, fieldType);

    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
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
      ForGeneratedModel("I" + TestPrefix + fieldType + " " + fieldName),
      ForGeneratedModel(": base(" + fieldName + ")"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParentFieldParam_GeneratesCorrectCode(string name, string parent, string parentArg, string fieldName, string fieldType)
  {
    this.SkipEqualAny([name, parent, parentArg, fieldType]);

    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
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
      ForGeneratedModel("I" + TestPrefix + fieldType + " " + fieldName),
      ForGeneratedModel(") : base(" + fieldName + ")"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParentFieldParamEnum_GeneratesCorrectCode(string name, string parent, string parentArg, string fieldName, string enumName, string enumLabel)
  {
    this.SkipEqualAny([name, parent, parentArg, enumName]);

    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstEnum enumType = A.Enum(enumName, [enumLabel]);
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
      ForGeneratedModel("()"),
      ForGeneratedModel(": base(" + TestPrefix + enumName + "." + enumLabel + ")"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithGrandParentFieldParamEnum_GeneratesCorrectCode(string name, string grandParent, string parent, string grandParentArg, string fieldName, string enumName, string enumLabel)
  {
    this.SkipEqualAny([name, parent, grandParent, enumName]);

    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstEnum enumType = A.Enum(enumName, [enumLabel]);
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

  [Theory, RepeatData]
  public void GenerateType_WithDeepParentFieldParamEnum_GeneratesCorrectCode(string name, string kindParam,
      string deepParent, string deepField, string deepParam,
      string grandParent, string grandField, string grandParam,
      string parent, string parentField, string parentParam,
      string fieldName, string enumName, string enumLabel)
  {
    this.SkipEqualAny([name, parent, deepParent, grandParent, enumName]);
    this.SkipEqualAny([parent, kindParam, enumName, enumLabel]);
    this.SkipEqualAny([kindParam, deepParam, grandParam, parentParam]);
    this.SkipEqualAny([fieldName, deepField, grandField, parentField]);

    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstEnum enumType = A.Enum(enumName, [enumLabel]);
    // deepParent<$kindParam> with required field kindField: $kindParam
    IGqlpObject<TObjField> deepParentType = A.Obj<TObjField>(Kind, deepParent)
      .WithTypeParams(A.TypeParam(kindParam, "_Enum"), A.TypeParam(deepParam, "_Any"))
      .WithObjFields(
        MakeField(fieldName, kindParam).IsTypeParam().AsObjField,
        MakeField(deepField, deepParam).IsTypeParam().AsObjField)
      .AsObject;
    // grandParent<$kindParam> passes $kindParam through to deepParent
    IGqlpObject<TObjField> grandParentType = A.Obj<TObjField>(Kind, grandParent)
      .WithTypeParams(A.TypeParam(kindParam, "_Enum"), A.TypeParam(grandParam, "_Any"))
      .WithParent(deepParent, p => p.WithArgs(A.TypeArg(kindParam).IsTypeParam(), A.TypeArg("String")))
      .WithObjFields(MakeField(grandField, grandParam).IsTypeParam().AsObjField)
      .AsObject;
    // parent : grandParent<enumName.enumLabel> (concrete enum value arg)
    IGqlpObject<TObjField> parentType = A.Obj<TObjField>(Kind, parent)
      .WithTypeParam(parentParam, "_Any")
      .WithParent(grandParent, p => p.WithArgs(A.TypeArg(enumName).WithObjEnum(enumLabel), A.TypeArg("String")))
      .WithObjFields(MakeField(parentField, parentParam).IsTypeParam().AsObjField)
      .AsObject;
    context.AddTypes(enumType, deepParentType, grandParentType, parentType);

    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithParent(parent, p => p.WithArg("String"))
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedCodeParent(TestPrefix + parent),
      ForGeneratedModel(": base(" + TestPrefix + enumName + "." + enumLabel + ","));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParentParam_GeneratesCorrectCode(string name, string parent)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IGqlpObject<TObjField> type = A.Obj<TObjField>(Kind, name)
      .WithTypeParam(parent, "_Any")
      .WithParent(parent, p => p.IsTypeParam())
      .AsObject;

    // Act
    TypeGenerator.GenerateType(type, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedModel("T" + parent + "? As_Parent"));
  }
}
