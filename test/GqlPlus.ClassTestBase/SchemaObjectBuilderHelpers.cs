using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public static class SchemaObjectBuilderHelpers
{
  public static IGqlpDualBase DualBase(this IMockBuilder builder, string name, string typeDescr = "", bool isTypeParam = false)
  {
    IGqlpDualBase theBase = builder.ObjBase<IGqlpDualBase>(name, typeDescr, isTypeParam);
    theBase.Dual.Returns(name);
    return theBase;
  }
  public static IGqlpDualField DualField(this IMockBuilder builder, string name, string type, string fieldDescr, string typeDescr = "")
    => builder.ObjField<IGqlpDualField, IGqlpDualBase>(name, builder.DualBase(type, typeDescr), fieldDescr);
  public static IGqlpDualField DualField(this IMockBuilder builder, string name, string type, params IGqlpModifier[] modifiers)
    => builder.ObjField<IGqlpDualField, IGqlpDualBase>(name, builder.DualBase(type, ""), "", modifiers);

  public static IGqlpInputBase InputBase(this IMockBuilder builder, string name, string typeDescr = "", bool isTypeParam = false)
  {
    IGqlpInputBase theBase = builder.ObjBase<IGqlpInputBase>(name, typeDescr, isTypeParam);
    theBase.Input.Returns(name);
    return theBase;
  }
  public static IGqlpInputField InputField(this IMockBuilder builder, string name, string type, string fieldDescr, string typeDescr = "")
    => builder.ObjField<IGqlpInputField, IGqlpInputBase>(name, builder.InputBase(type, typeDescr), fieldDescr);
  public static IGqlpInputField InputField(this IMockBuilder builder, string name, string type, params IGqlpModifier[] modifiers)
    => builder.ObjField<IGqlpInputField, IGqlpInputBase>(name, builder.InputBase(type, ""), "", modifiers);

  public static IGqlpOutputArg OutputEnumArg(this IMockBuilder builder, string name, string enumType, string enumLabel)
  {
    IGqlpOutputArg theArg = builder.Named<IGqlpOutputArg>(name);
    IGqlpObjType enumObjType = builder.Named<IGqlpObjType>(enumType);
    theArg.FullType.Returns(enumType);
    theArg.EnumType.Returns(enumObjType);
    theArg.EnumLabel.Returns(enumLabel);
    return theArg;
  }
  public static IGqlpOutputBase OutputBase(this IMockBuilder builder, string name, params IGqlpOutputArg[] args)
  {
    IGqlpOutputBase theBase = builder.ObjBase<IGqlpOutputBase, IGqlpOutputArg>(name, args);
    theBase.Output.Returns(name);
    return theBase;
  }
  public static IGqlpOutputBase OutputBase(this IMockBuilder builder, string name, string typeDescr = "", bool isTypeParam = false)
  {
    IGqlpOutputBase theBase = builder.ObjBase<IGqlpOutputBase>(name, typeDescr, isTypeParam);
    theBase.Output.Returns(name);
    return theBase;
  }
  public static IGqlpOutputField OutputField(this IMockBuilder builder, string name, string type, string fieldDescr, string typeDescr = "")
    => builder.ObjField<IGqlpOutputField, IGqlpOutputBase>(name, builder.OutputBase(type, typeDescr), fieldDescr);
  public static IGqlpOutputField OutputField(this IMockBuilder builder, string name, string type, params IGqlpModifier[] modifiers)
    => builder.ObjField<IGqlpOutputField, IGqlpOutputBase>(name, builder.OutputBase(type, ""), "", modifiers);
  public static IGqlpOutputField OutputField(this IMockBuilder builder, string name, IGqlpOutputBase type, params IGqlpModifier[] modifiers)
    => builder.ObjField<IGqlpOutputField, IGqlpOutputBase>(name, type, "", modifiers);

  public static TBase ObjBase<TBase, TArg>(this IMockBuilder builder, string typeName, params TArg[] args)
    where TBase : class, IGqlpObjBase<TArg>
    where TArg : class, IGqlpObjArg
  {
    TBase theType = builder.Named<TBase>(typeName);
    theType.Args.Returns(args);
    theType.BaseArgs.Returns(args);

    return theType;
  }
  public static TBase ObjBase<TBase>(this IMockBuilder builder, string typeName, string typeDescr = "", bool isTypeParam = false)
    where TBase : class, IGqlpObjBase
  {
    TBase theType = builder.Named<TBase>(typeName, typeDescr);
    if (isTypeParam) {
      theType.IsTypeParam.Returns(true);
      theType.FullType.Returns("$" + typeName);
    } else {
      theType.FullType.Returns(typeName);
    }

    return theType;
  }
  public static TField ObjField<TField, TBase>(this IMockBuilder builder, string fieldName, TBase type, string fieldDescr, params IGqlpModifier[] modifiers)
    where TBase : class, IGqlpObjBase
    where TField : class, IGqlpObjField<TBase>
  {
    TField theField = builder.Named<TField>(fieldName, fieldDescr);
    theField.Type.Returns(type);
    theField.BaseType.Returns(type);
    theField.Modifiers.Returns(modifiers);

    return theField;
  }
}
