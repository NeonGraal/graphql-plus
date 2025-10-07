//HintName: Gqlp_-Object_Impl.gen.cs
// Generated from -Object.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp__Object;

public class Domain_ObjectKind
  : I_ObjectKind
{
}

public class Output_TypeObject<Tkind,Tfield>
  : Output_ChildType
  , I_TypeObject<Tkind,Tfield>
{
  public _ObjTypeParam typeParams { get; set; }
  public Tfield fields { get; set; }
  public _ObjAlternate alternates { get; set; }
  public _ObjectFor<Tfield> allFields { get; set; }
  public _ObjectFor<_ObjAlternate> allAlternates { get; set; }
}

public class Output_ObjTypeParam
  : Output_Named
  , I_ObjTypeParam
{
  public _TypeRef<_TypeKind> constraint { get; set; }
}

public class Output_ObjBase
  : Output_Named
  , I_ObjBase
{
  public _ObjTypeArg typeArgs { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class Output_ObjTypeArg
  : Output_TypeRef
  , I_ObjTypeArg
{
  public _Identifier label { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class Output_TypeParam
  : Output_Described
  , I_TypeParam
{
  public _Identifier typeParam { get; set; }
}

public class Output_ObjAlternate
  : I_ObjAlternate
{
  public _ObjBase type { get; set; }
  public _Collections collections { get; set; }
  public _ObjAlternateEnum As_ObjAlternateEnum { get; set; }
}

public class Output_ObjAlternateEnum
  : Output_TypeRef
  , I_ObjAlternateEnum
{
  public _Identifier label { get; set; }
}

public class Output_ObjectFor<Tfor>
  : Outputfor
  , I_ObjectFor<Tfor>
{
  public _Identifier object { get; set; }
}

public class Output_ObjField<Ttype>
  : Output_Aliased
  , I_ObjField<Ttype>
{
  public Ttype type { get; set; }
}

public class Output_ObjFieldType
  : Output_ObjBase
  , I_ObjFieldType
{
  public _Modifiers modifiers { get; set; }
  public _ObjFieldEnum As_ObjFieldEnum { get; set; }
}

public class Output_ObjFieldEnum
  : Output_TypeRef
  , I_ObjFieldEnum
{
  public _Identifier label { get; set; }
}

public class Output_ForParam<Ttype>
  : I_ForParam<Ttype>
{
  public _ObjAlternate As_ObjAlternate { get; set; }
  public _ObjField<Ttype> As_ObjField { get; set; }
}

public class Output_TypeDual
  : Output_TypeObject
  , I_TypeDual
{
}

public class Output_DualField
  : Output_ObjField
  , I_DualField
{
}

public class Output_TypeInput
  : Output_TypeObject
  , I_TypeInput
{
}

public class Output_InputField
  : Output_ObjField
  , I_InputField
{
}

public class Output_InputFieldType
  : Output_ObjFieldType
  , I_InputFieldType
{
  public _Value default { get; set; }
}

public class Output_InputParam
  : Output_InputFieldType
  , I_InputParam
{
}

public class Output_TypeOutput
  : Output_TypeObject
  , I_TypeOutput
{
}

public class Output_OutputField
  : Output_ObjField
  , I_OutputField
{
}

public class Output_OutputFieldType
  : Output_ObjFieldType
  , I_OutputFieldType
{
  public _InputParam parameters { get; set; }
}
