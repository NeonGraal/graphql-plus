using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Building;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public abstract class GenerateObjectTestsBase<TObjField>(
  TypeKind kind
) : GenerateTypeClassTestsBase<IAstObject<TObjField>, IAstObjBase, MapPair<string>>
  where TObjField : class, IAstObjField
{
  protected TypeKind Kind { get; } = kind;

  [Theory, RepeatData]
  public void GenerateType_WithField_GeneratesCorrectCode(string name, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(MakeField(fieldName, fieldType).AsObjField)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedBoth("I" + TestPrefix + fieldType + " " + fieldName + " { get;"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithOptStringField_GeneratesCorrectCode(string name, string fieldName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(MakeField(fieldName, "String")
        .WithModifier(ModifierKind.Optional)
        .AsObjField)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedBoth("string? " + fieldName + " { get;"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithOptField_GeneratesCorrectCode(string name, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
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

  [Theory, RepeatData]
  public void GenerateType_WithListField_GeneratesCorrectCode(string name, string fieldName, string fieldType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
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

  [Theory, RepeatData]
  public void GenerateType_WithDictField_GeneratesCorrectCode(string name, string fieldName, string fieldType, string fieldKey)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
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

  [Theory, RepeatData]
  public void GenerateType_WithParamField_GeneratesCorrectCode(string name, string fieldName, string fieldType, string fieldParam)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
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

  [Theory, RepeatData]
  public void GenerateType_WithPrimitiveField_GeneratesCorrectCode(string name, string fieldName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithObjFields(MakeField(fieldName, "String")
        .AsObjField)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedBoth("string " + fieldName + " { get;"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithAlternate_GeneratesCorrectCode(string name, string alternateType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithAlternate(alternateType)
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedInterface($"I{TestPrefix}{alternateType}? As{alternateType} {{ get;"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithAlternateArgs_GeneratesCorrectCode(string name, string alternateType, string argName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithAlternate(alternateType, a => a.WithArg(argName))
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedInterface($"I{TestPrefix}{alternateType}<I{TestPrefix}{argName}>? As{alternateType} {{ get;"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithAlternateEnum_GeneratesCorrectCode(string name, string enumType, string enumLabel)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
      .WithAlternate(enumType, a => a.WithObjEnum(enumLabel))
      .AsObject;

    // Act
    TypeGenerator.GenerateType(obj, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(name),
      ForGeneratedInterface($"{TestPrefix}{enumType}? As{enumType}{enumLabel} {{ get;"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithAlternateEnumArg_GeneratesCorrectCode(string name, string alternateType, string enumType, string enumLabel1, string enumLabel2)
  {
    this.SkipEqualAny([name, alternateType, enumType, enumLabel1, enumLabel2]);

    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstEnum theEnum = A.Enum(enumType, [enumLabel1, enumLabel2]);
    context.AddTypes(theEnum);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
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

  [Theory, RepeatData]
  public void GenerateType_WithAlternateParam_GeneratesCorrectCode(string name, string alternateParam)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
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

  [Theory, RepeatData]
  public void GenerateType_WithFieldAndAlternate_GeneratesCorrectCode(string name, string fieldName, string fieldType, string alternateType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
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

  [Theory, RepeatData]
  public void GenerateType_WithParams_GeneratesCorrectCode(string name, string[] parameters)
  {
    // Arrange
    GqlpGeneratorContext context = Context(BaseType, GeneratorType);
    IAstObject<TObjField> obj = A.Obj<TObjField>(Kind, name)
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
