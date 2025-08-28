﻿using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public static class SchemaObjectBuilderHelpers
{
  public static IGqlpDualBase DualBase(this IMockBuilder builder, string name, bool isTypeParam = false)
    => builder.ObjBase<IGqlpDualBase, IGqlpDualArg>(name, isTypeParam);
  public static IGqlpDualField DualField(this IMockBuilder builder, string name, string type, string typeDescr = "")
    => builder.ObjField<IGqlpDualField, IGqlpDualBase>(name, builder.DualBase(type).SetDescr(typeDescr));

  public static IGqlpInputBase InputBase(this IMockBuilder builder, string name, bool isTypeParam = false)
    => builder.ObjBase<IGqlpInputBase, IGqlpInputArg>(name, isTypeParam);
  public static IGqlpInputField InputField(this IMockBuilder builder, string name, string type, string typeDescr = "")
    => builder.ObjField<IGqlpInputField, IGqlpInputBase>(name, builder.InputBase(type).SetDescr(typeDescr));

  public static IGqlpOutputArg OutputEnumArg(this IMockBuilder builder, string name, string enumType, string enumLabel)
  {
    IGqlpOutputArg theArg = builder.Named<IGqlpOutputArg>(name);
    IGqlpObjType enumObjType = builder.Named<IGqlpObjType>(enumType);
    theArg.FullType.Returns(enumType);
    theArg.EnumType.Returns(enumObjType);
    theArg.EnumLabel.Returns(enumLabel);
    return theArg;
  }
  public static IGqlpOutputBase OutputBase(this IMockBuilder builder, string name, bool isTypeParam = false)
  => builder.ObjBase<IGqlpOutputBase, IGqlpOutputArg>(name, isTypeParam);
  public static IGqlpOutputField OutputField(this IMockBuilder builder, string name, string type, string typeDescr = "")
    => builder.ObjField<IGqlpOutputField, IGqlpOutputBase>(name, builder.OutputBase(type).SetDescr(typeDescr));

  public static T SetDescr<T>(this T described, string description)
    where T : IGqlpDescribed
  {
    described.Description.Returns(description);
    return described;
  }

  public static TObject Obj<TObject, TBase>(this IMockBuilder builder, string typeName, string parent = "", bool isTypeParam = false)
    where TObject : class, IGqlpObject<TBase>
    where TBase : class, IGqlpObjBase
  {
    TObject theObj = builder.Named<TObject>(typeName);
    string label = typeof(TObject).Name[5..^6];
    theObj.Label.Returns(label);
    if (!string.IsNullOrWhiteSpace(parent)) {
      TBase parentRef = builder.Named<TBase, IGqlpObjBase>(parent);
      parentRef.IsTypeParam.Returns(isTypeParam);
      theObj.SetParent(parentRef);
    } else {
      theObj.SetParent((TBase?)null);
    }

    return theObj;
  }
  public static TObject SetParent<TObject, TBase>([NotNull] this TObject obj, TBase? parent)
    where TObject : class, IGqlpObject<TBase>
    where TBase : class, IGqlpObjBase
  {
    obj.Parent.Returns(parent);
    obj.ObjParent.Returns(parent);

    return obj;
  }

  public static TBase ObjBase<TBase, TArg>(this IMockBuilder builder, string typeName, bool isTypeParam = false)
    where TBase : class, IGqlpObjBase<TArg>
    where TArg : class, IGqlpObjArg
  {
    TBase theType = builder.Named<TBase, IGqlpObjBase>(typeName);
    string label = typeof(TBase).Name[5..^4];
    theType.Label.Returns(label);
    if (isTypeParam) {
      theType.IsTypeParam.Returns(true);
      theType.FullType.Returns("$" + typeName);
    } else {
      theType.FullType.Returns(typeName);
    }

    return theType;
  }
  public static TBase SetArgs<TBase, TArg>([NotNull] this TBase objBase, params TArg[] args)
    where TBase : class, IGqlpObjBase<TArg>
    where TArg : class, IGqlpObjArg
  {
    objBase.Args.Returns(args);
    objBase.BaseArgs.Returns(args);

    return objBase;
  }

  public static TField ObjField<TField, TBase>(this IMockBuilder builder, string fieldName, TBase type, params IGqlpModifier[] modifiers)
    where TBase : class, IGqlpObjBase
    where TField : class, IGqlpObjField<TBase>
  {
    TField theField = builder.Named<TField>(fieldName, "");
    theField.Type.Returns(type);
    theField.BaseType.Returns(type);
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
