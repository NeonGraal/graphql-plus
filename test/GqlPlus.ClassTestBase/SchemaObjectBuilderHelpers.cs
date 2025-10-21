using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus;

public static class SchemaObjectBuilderHelpers
{
  public static TObject Obj<TObject>(this IMockBuilder builder, TypeKind kind, string typeName, string parent = "", bool isTypeParam = false)
    where TObject : class, IGqlpObject
  {
    TObject theObj = builder.Obj<TObject>(kind, typeName).WithParent(parent, t => t.IsTypeParam(isTypeParam)).AsObject;

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

  public static AlternateBuilder Alternate(this IMockBuilder _, string name)
    => new(name);

  public static ObjBaseBuilder ObjBase(this IMockBuilder _, string typeName)
    => new(typeName);

  public static TypeArgBuilder TypeArg(this IMockBuilder _, string typeName)
    => new(typeName);

  public static ObjFieldBuilder<TField> ObjField<TField>(this IMockBuilder _, string fieldName, string typeName)
    where TField : class, IGqlpObjField
    => new(fieldName, typeName);
  public static DualFieldBuilder DualField(this IMockBuilder _, string fieldName, string typeName)
    => new(fieldName, typeName);
  public static InputFieldBuilder InputField(this IMockBuilder _, string fieldName, string typeName)
    => new(fieldName, typeName);
  public static OutputFieldBuilder OutputField(this IMockBuilder _, string fieldName, string typeName)
    => new(fieldName, typeName);

  public static ObjectBuilder<TObject> Obj<TObject>(this IMockBuilder _, TypeKind kind, string name)
    where TObject : class, IGqlpObject
    => new(name, kind);
}
