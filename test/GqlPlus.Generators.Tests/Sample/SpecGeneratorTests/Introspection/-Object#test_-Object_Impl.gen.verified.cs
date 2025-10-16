//HintName: test_-Object_Impl.gen.cs
// Generated from -Object.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Object;

public class test_ObjectKind
  : Itest_ObjectKind
{
}

public class test_TypeObject<Tkind,Tfield>
  : test_ChildType
  , Itest_TypeObject<Tkind,Tfield>
{
  public _ObjTypeParam typeParams { get; set; }
  public Tfield fields { get; set; }
  public _ObjAlternate alternates { get; set; }
  public _ObjectFor<Tfield> allFields { get; set; }
  public _ObjectFor<_ObjAlternate> allAlternates { get; set; }
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public _TypeRef<_TypeKind> constraint { get; set; }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public _ObjTypeArg typeArgs { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class test_ObjTypeArg
  : test_TypeRef
  , Itest_ObjTypeArg
{
  public _Identifier label { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public _Identifier typeParam { get; set; }
}

public class test_ObjAlternate
  : Itest_ObjAlternate
{
  public _ObjBase type { get; set; }
  public _Collections collections { get; set; }
  public _ObjAlternateEnum As_ObjAlternateEnum { get; set; }
}

public class test_ObjAlternateEnum
  : test_TypeRef
  , Itest_ObjAlternateEnum
{
  public _Identifier label { get; set; }
}

public class test_ObjectFor<Tfor>
  : testfor
  , Itest_ObjectFor<Tfor>
{
  public _Identifier object { get; set; }
}

public class test_ObjField<Ttype>
  : test_Aliased
  , Itest_ObjField<Ttype>
{
  public Ttype type { get; set; }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public _Modifiers modifiers { get; set; }
  public _ObjFieldEnum As_ObjFieldEnum { get; set; }
}

public class test_ObjFieldEnum
  : test_TypeRef
  , Itest_ObjFieldEnum
{
  public _Identifier label { get; set; }
}

public class test_ForParam<Ttype>
  : Itest_ForParam<Ttype>
{
  public _ObjAlternate As_ObjAlternate { get; set; }
  public _ObjField<Ttype> As_ObjField { get; set; }
}

public class test_TypeDual
  : test_TypeObject
  , Itest_TypeDual
{
}

public class test_DualField
  : test_ObjField
  , Itest_DualField
{
}

public class test_TypeInput
  : test_TypeObject
  , Itest_TypeInput
{
}

public class test_InputField
  : test_ObjField
  , Itest_InputField
{
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public _Value default { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
}

public class test_TypeOutput
  : test_TypeObject
  , Itest_TypeOutput
{
}

public class test_OutputField
  : test_ObjField
  , Itest_OutputField
{
}

public class test_OutputFieldType
  : test_ObjFieldType
  , Itest_OutputFieldType
{
  public _InputParam parameters { get; set; }
}
