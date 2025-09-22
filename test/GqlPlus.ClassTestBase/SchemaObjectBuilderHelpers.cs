using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public static class SchemaObjectBuilderHelpers
{
  public static IGqlpObjBase DualBase(this IMockBuilder builder, string name, bool isTypeParam = false)
    => builder.ObjBase<IGqlpObjBase, IGqlpObjArg>(name, isTypeParam);
  public static IGqlpDualField DualField(this IMockBuilder builder, string name, string type, string typeDescr = "")
    => builder.ObjField<IGqlpDualField>(name, builder.DualBase(type).SetDescr(typeDescr));

  public static IGqlpObjBase InputBase(this IMockBuilder builder, string name, bool isTypeParam = false)
    => builder.ObjBase<IGqlpObjBase, IGqlpObjArg>(name, isTypeParam);
  public static IGqlpInputField InputField(this IMockBuilder builder, string name, string type, string typeDescr = "")
    => builder.ObjField<IGqlpInputField>(name, builder.InputBase(type).SetDescr(typeDescr));

  public static IGqlpObjArg OutputEnumArg(this IMockBuilder builder, string name, string enumType, string enumLabel)
  {
    IGqlpObjArg theArg = builder.ObjArg<IGqlpObjArg>(name);
    IGqlpObjType enumObjType = builder.Named<IGqlpObjType>(enumType);
    theArg.FullType.Returns(enumType);
    theArg.EnumType.Returns(enumObjType);
    theArg.EnumLabel.Returns(enumLabel);
    return theArg;
  }
  public static IGqlpObjBase OutputBase(this IMockBuilder builder, string name, bool isTypeParam = false)
  => builder.ObjBase<IGqlpObjBase, IGqlpObjArg>(name, isTypeParam);
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

  public static TBase ObjBase<TBase, TArg>(this IMockBuilder builder, string typeName, bool isTypeParam = false)
    where TBase : class, IGqlpObjBase
    where TArg : class, IGqlpObjArg
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
  public static TBase SetArgs<TBase, TArg>([NotNull] this TBase objBase, params TArg[] args)
    where TBase : class, IGqlpObjBase
    where TArg : class, IGqlpObjArg
  {
    objBase.Args.Returns(args);
    objBase.Args.Returns(args);

    return objBase;
  }

  public static TArg ObjArg<TArg>(this IMockBuilder builder, string typeName, bool isTypeParam = false)
    where TArg : class, IGqlpObjArg
  {
    TArg theArg = builder.Named<TArg, IGqlpObjArg>(typeName);
    string label = typeof(TArg).Name[5..^3];
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

    return theField;
  }
  public static TField SetModifiers<TField>([NotNull] this TField field, params IGqlpModifier[] modifiers)
    where TField : class, IGqlpModifiers
  {
    field.Modifiers.Returns(modifiers);

    return field;
  }
}
