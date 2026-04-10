using GqlPlus.Abstractions.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus;

public static class SchemaObjectBuilderHelpers
{
  public static IAstObject<TField> Obj<TField>(this IMockBuilder builder, TypeKind kind, string typeName, string parent = "", bool isTypeParam = false)
    where TField : class, IAstObjField
    => builder.Obj<TField>(kind, typeName).WithParent(parent, t => t.IsTypeParam(isTypeParam)).AsObject;

  public static ObjBaseBuilder ObjBase(this IMockBuilder _, string name)
    => new(name);

  public static AlternateBuilder Alternate(this IMockBuilder _, string name)
    => new(name);

  public static TypeArgBuilder TypeArg(this IMockBuilder _, string typeName)
    => new(typeName);

  public static DualFieldBuilder DualField(this IMockBuilder _, string fieldName, string typeName)
    => new(fieldName, typeName);
  public static InputFieldBuilder InputField(this IMockBuilder _, string fieldName, string typeName)
    => new(fieldName, typeName);
  public static OutputFieldBuilder OutputField(this IMockBuilder _, string fieldName, string typeName)
    => new(fieldName, typeName);

  public static ObjectBuilder<TField> Obj<TField>(this IMockBuilder _, TypeKind kind, string name)
    where TField : class, IAstObjField
    => new(name, kind);
  public static ObjectBuilder<IAstDualField> DualObj(this IMockBuilder _, string name)
    => _.Obj<IAstDualField>(TypeKind.Dual, name);
  public static ObjectBuilder<IAstInputField> InputObj(this IMockBuilder _, string name)
    => _.Obj<IAstInputField>(TypeKind.Input, name);
  public static ObjectBuilder<IAstOutputField> OutputObj(this IMockBuilder _, string name)
    => _.Obj<IAstOutputField>(TypeKind.Output, name);
}
