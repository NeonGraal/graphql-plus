//HintName: test_Base_Impl.gen.cs
// Generated from Base.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Base;

public class Domaintest_ObjectKind
  : Itest_ObjectKind
{
}

public class Outputtest_TypeObject<Tkind,Tfield>
  : Outputtest_ChildType
  , Itest_TypeObject<Tkind,Tfield>
{
  public _ObjTypeParam typeParams { get; set; }
  public Tfield fields { get; set; }
  public _ObjAlternate alternates { get; set; }
  public _ObjectFor<Tfield> allFields { get; set; }
  public _ObjectFor<_ObjAlternate> allAlternates { get; set; }
}

public class Outputtest_ObjTypeParam
  : Outputtest_Named
  , Itest_ObjTypeParam
{
  public _TypeRef<_TypeKind> constraint { get; set; }
}

public class Outputtest_ObjBase
  : Outputtest_Named
  , Itest_ObjBase
{
  public _ObjTypeArg typeArgs { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class Outputtest_ObjTypeArg
  : Outputtest_TypeRef
  , Itest_ObjTypeArg
{
  public _Identifier label { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class Outputtest_TypeParam
  : Outputtest_Described
  , Itest_TypeParam
{
  public _Identifier typeParam { get; set; }
}

public class Outputtest_ObjAlternate
  : Itest_ObjAlternate
{
  public _ObjBase type { get; set; }
  public _Collections collections { get; set; }
  public _ObjAlternateEnum As_ObjAlternateEnum { get; set; }
}

public class Outputtest_ObjAlternateEnum
  : Outputtest_TypeRef
  , Itest_ObjAlternateEnum
{
  public _Identifier label { get; set; }
}

public class Outputtest_ObjectFor<Tfor>
  : Outputtestfor
  , Itest_ObjectFor<Tfor>
{
  public _Identifier object { get; set; }
}

public class Outputtest_ObjField<Ttype>
  : Outputtest_Aliased
  , Itest_ObjField<Ttype>
{
  public Ttype type { get; set; }
}

public class Outputtest_ObjFieldType
  : Outputtest_ObjBase
  , Itest_ObjFieldType
{
  public _Modifiers modifiers { get; set; }
  public _ObjFieldEnum As_ObjFieldEnum { get; set; }
}

public class Outputtest_ObjFieldEnum
  : Outputtest_TypeRef
  , Itest_ObjFieldEnum
{
  public _Identifier label { get; set; }
}

public class Outputtest_ForParam<Ttype>
  : Itest_ForParam<Ttype>
{
  public _ObjAlternate As_ObjAlternate { get; set; }
  public _ObjField<Ttype> As_ObjField { get; set; }
}
