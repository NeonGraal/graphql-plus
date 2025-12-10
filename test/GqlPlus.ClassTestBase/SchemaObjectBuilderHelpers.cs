using GqlPlus.Abstractions.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus;

public static class SchemaObjectBuilderHelpers
{
  public static IGqlpObject<TField> Obj<TField>(this IMockBuilder builder, TypeKind kind, string typeName, string parent = "", bool isTypeParam = false)
    where TField : class, IGqlpObjField
    => builder.Obj<TField>(kind, typeName).WithParent(parent, t => t.IsTypeParam(isTypeParam)).AsObject;

  public static ObjBaseBuilder ObjBase(this IMockBuilder _, string name)
    => new(name);

  public static AlternateBuilder Alternate(this IMockBuilder _, string name)
    => new(name);

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

  public static ObjectBuilder<TField> Obj<TField>(this IMockBuilder _, TypeKind kind, string name)
    where TField : class, IGqlpObjField
    => new(name, kind);
  public static ObjectBuilder<IGqlpDualField> DualObj(this IMockBuilder _, string name)
    => _.Obj<IGqlpDualField>(TypeKind.Dual, name);
  public static ObjectBuilder<IGqlpInputField> InputObj(this IMockBuilder _, string name)
    => _.Obj<IGqlpInputField>(TypeKind.Input, name);
  public static ObjectBuilder<IGqlpOutputField> OutputObj(this IMockBuilder _, string name)
    => _.Obj<IGqlpOutputField>(TypeKind.Output, name);
}
