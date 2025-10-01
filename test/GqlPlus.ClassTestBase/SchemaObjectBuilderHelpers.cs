using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public static class SchemaObjectBuilderHelpers
{
  public static IGqlpObjBase DualBase(this IMockBuilder builder, string name, bool isTypeParam = false)
    => builder.ObjBase<IGqlpObjBase, IGqlpObjTypeArg>(name, isTypeParam);
  public static IGqlpDualField DualField(this IMockBuilder builder, string name, string type, string typeDescr = "")
    => builder.ObjField<IGqlpDualField>(name, builder.DualBase(type).SetDescr(typeDescr));

  public static IGqlpObjBase InputBase(this IMockBuilder builder, string name, bool isTypeParam = false)
    => builder.ObjBase<IGqlpObjBase, IGqlpObjTypeArg>(name, isTypeParam);
  public static IGqlpInputField InputField(this IMockBuilder builder, string name, string type, string typeDescr = "")
    => builder.ObjField<IGqlpInputField>(name, builder.InputBase(type).SetDescr(typeDescr));

  public static IGqlpObjTypeArg ObjEnumArg(this IMockBuilder builder, string enumType, string enumLabel)
  {
    IGqlpEnumValue enumValue = builder.EnumValue(enumType, enumLabel);
    IGqlpObjTypeArg theArg = builder.ObjTypeArg(enumType);
    theArg.EnumValue.Returns(enumValue);
    return theArg;
  }
  public static IGqlpObjBase OutputBase(this IMockBuilder builder, string name, bool isTypeParam = false)
  => builder.ObjBase<IGqlpObjBase, IGqlpObjTypeArg>(name, isTypeParam);
  public static IGqlpOutputField OutputField(this IMockBuilder builder, string name, string type, string typeDescr = "")
    => builder.ObjField<IGqlpOutputField>(name, builder.OutputBase(type).SetDescr(typeDescr));

  public static T SetDescr<T>(this T described, string description)
    where T : IGqlpDescribed
  {
    described.Description.Returns(description);
    return described;
  }

  public static TObject Obj<TObject>(this IMockBuilder builder, string typeName, string parent = "", bool isTypeParam = false)
    where TObject : class, IGqlpObject
  {
    TObject theObj = builder.Named<TObject>(typeName);
    string label = typeof(TObject).Name[5..^6];
    theObj.Label.Returns(label);
    if (!string.IsNullOrWhiteSpace(parent)) {
      IGqlpObjBase parentRef = builder.Named<IGqlpObjBase>(parent);
      parentRef.IsTypeParam.Returns(isTypeParam);
      theObj.SetParent(parentRef);
    } else {
      theObj.SetParent(null);
    }

    return theObj;
  }
  public static TObject SetParent<TObject>([NotNull] this TObject obj, IGqlpObjBase? parent)
    where TObject : class, IGqlpObject
  {
    obj.Parent.Returns(parent);

    return obj;
  }

  public static TBase ObjBase<TBase, TTypeArg>(this IMockBuilder builder, string typeName, bool isTypeParam = false)
    where TBase : class, IGqlpObjBase
    where TTypeArg : class, IGqlpObjTypeArg
  {
    TBase theType = builder.Named<TBase, IGqlpObjBase>(typeName);
    string label = typeof(TBase).Name[5..^4];
    if (isTypeParam) {
      theType.IsTypeParam.Returns(true);
      theType.FullType.Returns("$" + typeName);
    } else {
      theType.FullType.Returns(typeName);
    }

    return theType;
  }
  public static TBase SetArgs<TBase, TTypeArg>([NotNull] this TBase objBase, params TTypeArg[] args)
    where TBase : class, IGqlpObjBase
    where TTypeArg : class, IGqlpObjTypeArg
  {
    objBase.Args.Returns(args);
    objBase.Args.Returns(args);

    return objBase;
  }

  public static IGqlpObjTypeArg ObjTypeArg(this IMockBuilder builder, string typeName, bool isTypeParam = false)
  {
    IGqlpObjTypeArg theArg = builder.Named<IGqlpObjTypeArg>(typeName);
    theArg.EnumValue.Returns((IGqlpEnumValue?)null);
    if (isTypeParam) {
      theArg.IsTypeParam.Returns(true);
      theArg.FullType.Returns("$" + typeName);
    } else {
      theArg.FullType.Returns(typeName);
    }

    return theArg;
  }

  public static TField ObjField<TField>(this IMockBuilder builder, string fieldName, IGqlpObjBase type, params IGqlpModifier[] modifiers)
    where TField : class, IGqlpObjField
  {
    TField theField = builder.Named<TField>(fieldName, "");
    theField.Type.Returns(type);
    theField.Modifiers.Returns(modifiers);
    theField.EnumValue.Returns((IGqlpEnumValue?)null);

    return theField;
  }
  public static TField SetModifiers<TField>([NotNull] this TField field, params IGqlpModifier[] modifiers)
    where TField : class, IGqlpModifiers
  {
    field.Modifiers.Returns(modifiers);

    return field;
  }
}
