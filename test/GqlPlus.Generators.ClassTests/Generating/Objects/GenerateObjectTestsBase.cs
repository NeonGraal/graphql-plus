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
    context.CheckForRequired(
      GeneratedCodeName(generatorType, name),
      GeneratedCodeParent(generatorType, TestPrefix + parent));
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
    context.CheckForRequired(
      GeneratedCodeName(generatorType, name),
      GeneratedCodeParent(generatorType, TestPrefix + parent));
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
    context.CheckForRequired(
      GeneratedCodeName(generatorType, name),
      GeneratedCodeParent(generatorType, TestPrefix + parent));
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
    CheckContext(context,
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedBoth(generatorType, "I" + TestPrefix + fieldType + " " + fieldName + " { get;"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithModifiedField_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string name, string fieldName, string fieldType)
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
    CheckContext(context,
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedBoth(generatorType, "I" + TestPrefix + fieldType + "? " + fieldName + " { get;"));
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
    CheckContext(context,
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedOne(GqlpGeneratorType.Interface, generatorType, $"I{TestPrefix}{alternateType}? As{alternateType} {{ get;"));
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
    CheckContext(context,
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedOne(GqlpGeneratorType.Interface, generatorType, $"I{TestPrefix}{alternateType}<I{TestPrefix}{argName}>? As{alternateType} {{ get;"));
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
    CheckContext(context,
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedOne(GqlpGeneratorType.Interface, generatorType, $"{TestPrefix}{enumType}? As{enumType}{enumLabel} {{ get;"));
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
    CheckContext(context,
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedOne(GqlpGeneratorType.Interface, generatorType, $"{expectedPrefix}{enumLabel2} {{ get;"),
      CheckGeneratedOne(GqlpGeneratorType.Interface, generatorType, $"{expectedPrefix}{enumLabel1} {{ get;"));
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
    CheckContext(context,
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedOne(GqlpGeneratorType.Interface, generatorType, $"T{alternateParam}? As{alternateParam} {{ get;"));
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
    CheckContext(context,
      CheckGeneratedCodeName(generatorType, name),
      CheckGeneratedBoth(generatorType, "I" + TestPrefix + fieldType + " " + fieldName + " { get;"),
      CheckGeneratedOne(GqlpGeneratorType.Interface, generatorType, $"I{TestPrefix}{alternateType}? As{alternateType} {{ get;"));
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

  protected static Action<string> CheckGeneratedOne(GqlpGeneratorType forType, GqlpGeneratorType generatorType, string contains)
    => result => {
      if (forType == generatorType) {
        result.ShouldContain(contains);
      }
    };

  protected static Action<string> CheckGeneratedBoth(GqlpGeneratorType generatorType, string contains)
    => CheckGeneratedEither(generatorType,
      r => r.ShouldContain(contains),
      r => r.ShouldContain(contains));

  protected static Action<string> CheckGeneratedEither(GqlpGeneratorType generatorType, Action<string> checkIntf, Action<string> checkImpl)
    => result => {
      switch (generatorType) {
        case GqlpGeneratorType.Interface:
          checkIntf(result);
          break;
        case GqlpGeneratorType.Implementation:
          checkImpl(result);
          break;
        default:
          result.ShouldBeEmpty();
          break;
      }
    };

  protected abstract ObjFieldBuilder<TObjField> MakeField(string name, string type);
}
