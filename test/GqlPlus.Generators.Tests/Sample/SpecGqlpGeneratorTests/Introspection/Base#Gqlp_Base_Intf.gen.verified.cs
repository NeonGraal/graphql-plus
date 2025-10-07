//HintName: Gqlp_Base_Intf.gen.cs
// Generated from Base.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Base;

public interface I_ObjectKind
{
}

public interface I_TypeObject<Tkind,Tfield>
  : I_ChildType
{
  _ObjTypeParam typeParams { get; }
  Tfield fields { get; }
  _ObjAlternate alternates { get; }
  _ObjectFor<Tfield> allFields { get; }
  _ObjectFor<_ObjAlternate> allAlternates { get; }
}

public interface I_ObjTypeParam
  : I_Named
{
  _TypeRef<_TypeKind> constraint { get; }
}

public interface I_ObjBase
  : I_Named
{
  _ObjTypeArg typeArgs { get; }
  _TypeParam As_TypeParam { get; }
}

public interface I_ObjTypeArg
  : I_TypeRef
{
  _Identifier label { get; }
  _TypeParam As_TypeParam { get; }
}

public interface I_TypeParam
  : I_Described
{
  _Identifier typeParam { get; }
}

public interface I_ObjAlternate
{
  _ObjBase type { get; }
  _Collections collections { get; }
  _ObjAlternateEnum As_ObjAlternateEnum { get; }
}

public interface I_ObjAlternateEnum
  : I_TypeRef
{
  _Identifier label { get; }
}

public interface I_ObjectFor<Tfor>
  : Ifor
{
  _Identifier object { get; }
}

public interface I_ObjField<Ttype>
  : I_Aliased
{
  Ttype type { get; }
}

public interface I_ObjFieldType
  : I_ObjBase
{
  _Modifiers modifiers { get; }
  _ObjFieldEnum As_ObjFieldEnum { get; }
}

public interface I_ObjFieldEnum
  : I_TypeRef
{
  _Identifier label { get; }
}

public interface I_ForParam<Ttype>
{
  _ObjAlternate As_ObjAlternate { get; }
  _ObjField<Ttype> As_ObjField { get; }
}
