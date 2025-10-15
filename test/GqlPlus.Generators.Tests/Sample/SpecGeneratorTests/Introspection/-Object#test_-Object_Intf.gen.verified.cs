//HintName: test_-Object_Intf.gen.cs
// Generated from -Object.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Object;

public interface Itest_ObjectKind
{
}

public interface Itest_TypeObject<Tkind,Tfield>
  : Itest_ChildType
{
  _ObjTypeParam typeParams { get; }
  Tfield fields { get; }
  _ObjAlternate alternates { get; }
  _ObjectFor<Tfield> allFields { get; }
  _ObjectFor<_ObjAlternate> allAlternates { get; }
}

public interface Itest_ObjTypeParam
  : Itest_Named
{
  _TypeRef<_TypeKind> constraint { get; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  _ObjTypeArg typeArgs { get; }
  _TypeParam As_TypeParam { get; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef
{
  _Identifier label { get; }
  _TypeParam As_TypeParam { get; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  _Identifier typeParam { get; }
}

public interface Itest_ObjAlternate
{
  _ObjBase type { get; }
  _Collections collections { get; }
  _ObjAlternateEnum As_ObjAlternateEnum { get; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
  _Identifier label { get; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
  _Identifier object { get; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
  Ttype type { get; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  _Modifiers modifiers { get; }
  _ObjFieldEnum As_ObjFieldEnum { get; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
  _Identifier label { get; }
}

public interface Itest_ForParam<Ttype>
{
  _ObjAlternate As_ObjAlternate { get; }
  _ObjField<Ttype> As_ObjField { get; }
}

public interface Itest_TypeDual
  : Itest_TypeObject
{
}

public interface Itest_DualField
  : Itest_ObjField
{
}

public interface Itest_TypeInput
  : Itest_TypeObject
{
}

public interface Itest_InputField
  : Itest_ObjField
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  _Value default { get; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
}

public interface Itest_TypeOutput
  : Itest_TypeObject
{
}

public interface Itest_OutputField
  : Itest_ObjField
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  _InputParam parameters { get; }
}
