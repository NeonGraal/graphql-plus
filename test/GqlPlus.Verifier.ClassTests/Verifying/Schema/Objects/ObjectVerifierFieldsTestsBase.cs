using GqlPlus.Building;
using GqlPlus.Building.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectVerifierFieldsTestsBase<TObjField>(
  TypeKind kind
) : ObjectVerifierTestsBase<TObjField>(kind)
  where TObjField : class, IGqlpObjField
{
  [Theory, RepeatData]
  public void Verify_WithField_ReturnsNoErrors(string fieldName)
  {
    Define(A.DomainString("String"));

    ObjectField(TheBuilder, fieldName, "String");

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldSame_ReturnsErrors(string fieldName, string name)
  {
    ObjectField(TheBuilder, fieldName, name);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatClassData<ModifersTestData>]

  public void Verify_WithFieldSameModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName)
  {
    Define(A.DomainString("String"));

    ObjectField(TheBuilder, fieldName, name, f => f.WithModifier(kind, "String"));

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithFieldSameRecurse_ReturnsErrors(string fieldName, string name, string typeName)
  {
    this.SkipEqual(typeName, name);

    DefineObject(typeName, o => ObjectField(o, fieldName, name));

    ObjectField(TheBuilder, fieldName, typeName);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatClassData<ModifersTestData>]

  public void Verify_WithFieldSameRecurseModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName, string typeName)
  {
    this.SkipEqual(typeName, name);

    Define(A.DomainString("String"));

    DefineObject(typeName, o =>
      ObjectField(o, fieldName, name, f => f
        .WithModifier(kind, "String")));

    ObjectField(TheBuilder, fieldName, typeName);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithFieldParentSame_ReturnsErrors(string fieldName, string name, string typeName)
  {
    this.SkipEqual(typeName, name);

    DefineObject(typeName, o => o.WithParent(name));

    ObjectField(TheBuilder, fieldName, typeName);

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatClassData<ModifersTestData>]

  public void Verify_WithFieldParentSameModifier_ReturnsErrors(ModifierKind kind, string name, string fieldName, string typeName)
  {
    this.SkipEqual(typeName, name);

    Define(A.DomainString("String"));

    DefineObject(typeName, o => o.WithParent(name));

    ObjectField(TheBuilder, fieldName, typeName, f => f.WithModifier(kind, "String"));

    Verify_Errors("cannot be a field of itself", name);
  }

  [Theory, RepeatData]
  public void Verify_WithFieldParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define(A.DomainString(constraint));

    TheBuilder.WithTypeParam(paramName, constraint);

    ObjectField(TheBuilder, fieldName, paramName, f => f.WithType(t => t.IsTypeParam()));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldKeyParam_ReturnsNoErrors(string fieldName, string paramName)
  {
    Define(A.DomainString("String"));

    TheBuilder.WithTypeParam(paramName, "String");

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Param, paramName));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDict_ReturnsNoErrors(string fieldName, string key)
  {
    Define(A.DomainString("String"), A.DomainString(key));

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Dict, key));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictUndefined_ReturnsError(string fieldName, string key)
  {
    Define(A.DomainString("String"));

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Dict, key));

    Verify_Errors("not defined");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictParam_ReturnsNoErrors(string fieldName, string paramName, string constraint)
  {
    Define(A.DomainString("String"), A.DomainString(constraint));

    TheBuilder.WithTypeParam(paramName, constraint);

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Param, paramName));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldDictParamUndefined_ReturnsNoErrors(string fieldName, string paramName)
  {
    Define(A.DomainString("String"));

    ObjectField(TheBuilder, fieldName, "String", f => f.WithModifier(ModifierKind.Param, paramName));

    Verify_Errors("not defined");
  }

  [Theory, RepeatData]
  public void Verify_WithParentField_ReturnsNoErrors(string fieldName, string parentName)
  {
    Define(A.DomainString("String"));

    DefineObject(parentName, o => ObjectField(o, fieldName, "String"));

    TheBuilder.WithParent(parentName);

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgGeneric_ReturnsError(string fieldName, string otherName, string paramName, string argType, string argParam)
  {
    this.SkipEqual(argType, argParam)
      .SkipEqual(otherName, argParam)
      .SkipEqual(otherName, paramName);

    Define<IGqlpSimple>(argParam);

    DefineObject(argType, o => o
      .WithTypeParam(argParam, argParam)
      .WithAlternate(argParam, a => a.IsTypeParam()));

    DefineObject(otherName, o => o
      .WithTypeParam(paramName, argType)
      .WithAlternate(paramName, a => a.IsTypeParam()));

    IGqlpTypeArg arg = A.TypeArg(argType).AsTypeArg;
    ObjectField(TheBuilder, fieldName, otherName, f => f.WithType(t => t.WithArgs(arg)));
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    Verify_Errors("Expected 1, given none");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoParam_ReturnsError(string fieldName, string otherName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    DefineObject(otherName);

    IGqlpTypeArg arg = A.TypeArg(argType).AsTypeArg;
    ObjectField(TheBuilder, fieldName, otherName, f => f.WithType(t => t.WithArgs(arg)));
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    Verify_Errors("Expected 0, given 1");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoConstraint_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    DefineObject(otherName, o => o
      .WithTypeParam(paramName, "")
      .WithParent(paramName, p => p.IsTypeParam()));

    IGqlpTypeArg arg = A.TypeArg(argType).AsTypeArg;
    ObjectField(TheBuilder, fieldName, otherName, f => f.WithType(t => t.WithArgs(arg)));
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(true);

    Verify_Errors("undefined");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldTypeArgNoMatch_ReturnsError(string fieldName, string otherName, string paramName, string argType)
  {
    this.SkipEqual(argType, otherName);

    Define<IGqlpSimple>(argType);

    DefineObject(otherName, o => o
      .WithTypeParam(paramName, argType)
      .WithParent(paramName, p => p.IsTypeParam()));

    IGqlpTypeArg arg = A.TypeArg(argType).AsTypeArg;
    ObjectField(TheBuilder, fieldName, otherName, f => f.WithType(t => t.WithArgs(arg)));
    ArgMatcher.Matches(arg, argType, Arg.Any<EnumContext>()).Returns(false);

    Verify_Errors("not match");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnum_ReturnsNoErrors(string fieldName, string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    ObjectField(TheBuilder, fieldName, enumType, f => f.WithObjEnum(enumLabel));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumLabel_ReturnsNoErrors(string fieldName, string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, [enumLabel]));

    ObjectField(TheBuilder, fieldName, "", f => f.WithObjEnum(enumLabel));

    Verify_NoErrors();
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumUndefined_ReturnsError(string fieldName, string enumType, string enumLabel)
  {
    ObjectField(TheBuilder, fieldName, enumType, f => f.WithObjEnum(enumLabel));

    Verify_Errors("not an Enum");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumWrongLabel_ReturnsError(string fieldName, string enumType, string enumLabel)
  {
    AddTypes(A.Enum(enumType, ["bad" + enumLabel]));

    ObjectField(TheBuilder, fieldName, enumType, f => f.WithObjEnum(enumLabel));

    Verify_Errors("not a Label");
  }

  [Theory, RepeatData]
  public void Verify_WithFieldEnumTypeArg_ReturnsNoErrors(string fieldName, string enumType, string enumLabel, string argName, string typeName)
  {
    this.SkipEqual(typeName, enumType).SkipEqual(typeName, enumLabel).SkipEqual(enumType, enumLabel);

    AddTypes(A.Enum(enumType, [enumLabel]));

    DefineObject(typeName, o => o
      .WithTypeParam(argName, enumType)
      .WithAlternate(argName, p => p.IsTypeParam()));

    IGqlpTypeArg arg = A.TypeArg("").WithObjEnum(enumLabel).AsTypeArg;
    ObjectField(TheBuilder, fieldName, typeName, f => f
      .WithType(t => t.WithArgs(arg)));

    ArgMatcher.Matches(arg, enumType, Arg.Any<EnumContext>()).Returns(true);

    Verify_NoErrors();
  }

  protected void ObjectField(ObjectBuilder<TObjField> builder, string fieldName, string fieldType, Action<ObjFieldBuilder<TObjField>>? config = null)
    => builder.WithObjFields(A.ObjField<TObjField>(fieldName, fieldType).FluentAction(config).AsObjField);
}

public class ModifersTestData
  : CollectionsTestData
{
  public ModifersTestData() => Add(ModifierKind.Opt);
}
