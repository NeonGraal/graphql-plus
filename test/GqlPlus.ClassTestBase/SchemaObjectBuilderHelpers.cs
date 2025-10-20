using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus;

public static class SchemaObjectBuilderHelpers
{
  public static T SetDescr<T>(this T described, string description)
    where T : IGqlpDescribed
  {
    described.Description.Returns(description);
    return described;
  }

  public static TObject Obj<TObject>(this IMockBuilder builder, TypeKind kind, string typeName, string parent = "", bool isTypeParam = false)
    where TObject : class, IGqlpObject
  {
    TObject theObj = builder.Named<TObject, IGqlpType>(typeName);
    theObj.Kind.Returns(kind);
    theObj.Label.Returns(kind.ToString());
    if (!string.IsNullOrWhiteSpace(parent)) {
      IGqlpObjBase parentRef = builder.ObjBase(parent).IsTypeParam(isTypeParam).AsObjBase;
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

  public static TBase SetArgs<TBase, TTypeArg>([NotNull] this TBase objBase, params TTypeArg[] args)
    where TBase : class, IGqlpObjBase
    where TTypeArg : class, IGqlpTypeArg
  {
    string typeName = args.Bracket("<", ">")
      .Prepend(objBase.TypeName).Joined();

    objBase.FullType.Returns(typeName);
    objBase.Args.Returns(args);

    return objBase;
  }

  public static IGqlpTypeArg TypeArg(this IMockBuilder _, string typeName, bool isTypeParam = false)
    => new TypeArgBuilder(typeName).IsTypeParam(isTypeParam).AsTypeArg;

  public static IGqlpTypeArg EnumArg(this IMockBuilder _, string enumType, string enumLabel)
    => new TypeArgBuilder(enumType).WithObjEnum(enumLabel).AsTypeArg;

  public static TField ObjField<TField>(this IMockBuilder builder, string fieldName, IGqlpObjBase type, params IGqlpModifier[] modifiers)
    where TField : class, IGqlpObjField
  {
    TField theField = builder.Named<TField>(fieldName, "");
    theField.Type.Returns(type);
    theField.Modifiers.Returns(modifiers);
    theField.EnumValue.Returns((IGqlpEnumValue?)null);

    return theField;
  }
  public static TField ObjField<TField>(this IMockBuilder builder, string fieldName, string typeName, params IGqlpModifier[] modifiers)
    where TField : class, IGqlpObjField
    => builder.ObjField<TField>(fieldName, builder.ObjBase(typeName).AsObjBase, modifiers);
  public static TField SetModifiers<TField>([NotNull] this TField field, params IGqlpModifier[] modifiers)
    where TField : class, IGqlpModifiers
  {
    field.Modifiers.Returns(modifiers);

    return field;
  }

  public static AlternateBuilder Alternate(this IMockBuilder _, string name)
    => new(name);
  public static ObjBaseBuilder ObjBase(this IMockBuilder _, string typeName)
    => new(typeName);
}
