//HintName: Gqlp_+Object_Intf.gen.cs
// Generated from +Object.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp__Object;

public interface I_ObjectKind
{
}

public interface I_TypeObject<Tkind,Tparent,TtypeParam,Tfield,Talternate>
  : I_ChildType
{
  TtypeParam typeParams { get; }
  Tfield fields { get; }
  Talternate alternates { get; }
  _ObjectFor<Tfield> allFields { get; }
  _ObjectFor<Talternate> allAlternates { get; }
}

public interface I_ObjTypeParam<Tkind>
  : I_Named
{
  _ObjConstraint<Tkind> constraint { get; }
}

public interface I_ObjConstraint<Tkind>
  : I_TypeRef
{
}

public interface I_ObjBase<Targ>
  : I_Named
{
  Targ typeArgs { get; }
  _TypeParam As_TypeParam { get; }
}

public interface I_ObjTypeArg
  : I_TypeRef
{
  _TypeParam As_TypeParam { get; }
}

public interface I_TypeParam
  : I_Named
{
  _Identifier typeParam { get; }
}

public interface I_Alternate<Tbase>
{
  Tbase type { get; }
  _Collections collections { get; }
}

public interface I_ObjectFor<Tfor>
  : Ifor
{
  _Identifier object { get; }
}

public interface I_Field<Tbase>
  : I_Aliased
{
  Tbase type { get; }
  _Modifiers modifiers { get; }
}

public interface I_ForParam<Tbase>
{
  _Alternate<Tbase> As_Alternate { get; }
  _Field<Tbase> As_Field { get; }
}

public interface I_TypeDual
  : I_TypeObject
{
}

public interface I_DualBase
  : I_ObjBase
{
}

public interface I_DualTypeParam
  : I_ObjTypeParam
{
}

public interface I_DualField
  : I_Field
{
}

public interface I_DualAlternate
  : I_Alternate
{
}

public interface I_DualTypeArg
  : I_ObjTypeArg
{
}

public interface I_TypeInput
  : I_TypeObject
{
}

public interface I_InputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}

public interface I_InputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
}

public interface I_InputField
  : I_Field
{
  _Value default { get; }
}

public interface I_InputAlternate
  : I_Alternate
{
}

public interface I_InputTypeArg
  : I_ObjTypeArg
{
}

public interface I_InputParam
  : I_InputBase
{
  _Modifiers modifiers { get; }
  _Value default { get; }
}

public interface I_TypeOutput
  : I_TypeObject
{
}

public interface I_OutputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}

public interface I_OutputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}

public interface I_OutputField
  : I_Field
{
  _InputParam parameters { get; }
  _OutputEnum As_OutputEnum { get; }
}

public interface I_OutputAlternate
  : I_Alternate
{
}

public interface I_OutputTypeArg
  : I_ObjTypeArg
{
  _Identifier label { get; }
}

public interface I_OutputEnum
  : I_TypeRef
{
  _Identifier field { get; }
  _Identifier label { get; }
}
