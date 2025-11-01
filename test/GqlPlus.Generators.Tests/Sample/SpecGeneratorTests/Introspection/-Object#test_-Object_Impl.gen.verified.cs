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
  public ICollection<test_ObjTypeParam> typeParams { get; set; }
  public ICollection<Tfield> fields { get; set; }
  public ICollection<test_ObjAlternate> alternates { get; set; }
  public ICollection<test_ObjectFor<Tfield>> allFields { get; set; }
  public ICollection<test_ObjectFor<test_ObjAlternate>> allAlternates { get; set; }
  public test_TypeObject _TypeObject { get; set; }
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public test_TypeRef<test_TypeKind> constraint { get; set; }
  public test_ObjTypeParam _ObjTypeParam { get; set; }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public ICollection<test_ObjTypeArg> typeArgs { get; set; }
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjBase _ObjBase { get; set; }
}

public class test_ObjTypeArg
  : test_TypeRef
  , Itest_ObjTypeArg
{
  public test_Identifier? label { get; set; }
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjTypeArg _ObjTypeArg { get; set; }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public test_Identifier typeParam { get; set; }
  public test_TypeParam _TypeParam { get; set; }
}

public class test_ObjAlternate
  : Itest_ObjAlternate
{
  public test_ObjBase type { get; set; }
  public ICollection<test_Collections> collections { get; set; }
  public test_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
  public test_ObjAlternate _ObjAlternate { get; set; }
}

public class test_ObjAlternateEnum
  : test_TypeRef
  , Itest_ObjAlternateEnum
{
  public test_Identifier label { get; set; }
  public test_ObjAlternateEnum _ObjAlternateEnum { get; set; }
}

public class test_ObjectFor<Tfor>
  : testfor
  , Itest_ObjectFor<Tfor>
{
  public test_Identifier object { get; set; }
  public test_ObjectFor _ObjectFor { get; set; }
}

public class test_ObjField<Ttype>
  : test_Aliased
  , Itest_ObjField<Ttype>
{
  public Ttype type { get; set; }
  public test_ObjField _ObjField { get; set; }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public ICollection<test_Modifiers> modifiers { get; set; }
  public test_ObjFieldEnum As_ObjFieldEnum { get; set; }
  public test_ObjFieldType _ObjFieldType { get; set; }
}

public class test_ObjFieldEnum
  : test_TypeRef
  , Itest_ObjFieldEnum
{
  public test_Identifier label { get; set; }
  public test_ObjFieldEnum _ObjFieldEnum { get; set; }
}

public class test_ForParam<Ttype>
  : Itest_ForParam<Ttype>
{
  public test_ObjAlternate As_ObjAlternate { get; set; }
  public test_ObjField<Ttype> As_ObjField { get; set; }
  public test_ForParam _ForParam { get; set; }
}

public class test_DualField
  : test_ObjField
  , Itest_DualField
{
  public test_DualField _DualField { get; set; }
}

public class test_InputField
  : test_ObjField
  , Itest_InputField
{
  public test_InputField _InputField { get; set; }
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public test_Value? default { get; set; }
  public test_InputFieldType _InputFieldType { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
  public test_InputParam _InputParam { get; set; }
}

public class test_OutputField
  : test_ObjField
  , Itest_OutputField
{
  public test_OutputField _OutputField { get; set; }
}

public class test_OutputFieldType
  : test_ObjFieldType
  , Itest_OutputFieldType
{
  public ICollection<test_InputParam> parameters { get; set; }
  public test_OutputFieldType _OutputFieldType { get; set; }
}
