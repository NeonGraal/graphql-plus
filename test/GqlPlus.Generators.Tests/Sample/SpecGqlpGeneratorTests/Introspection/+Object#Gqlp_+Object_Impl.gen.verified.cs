//HintName: Gqlp_+Object_Impl.gen.cs
// Generated from +Object.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp__Object;

public class Domain_ObjectKind
  : I_ObjectKind
{
}

public class Output_TypeObject<Tkind,Tparent,TtypeParam,Tfield,Talternate>
  : Output_ChildType
  , I_TypeObject<Tkind,Tparent,TtypeParam,Tfield,Talternate>
{
  public TtypeParam typeParams { get; set; }
  public Tfield fields { get; set; }
  public Talternate alternates { get; set; }
  public _ObjectFor<Tfield> allFields { get; set; }
  public _ObjectFor<Talternate> allAlternates { get; set; }
}

public class Output_ObjTypeParam<Tkind>
  : Output_Named
  , I_ObjTypeParam<Tkind>
{
  public _ObjConstraint<Tkind> constraint { get; set; }
}

public class Output_ObjConstraint<Tkind>
  : Output_TypeRef
  , I_ObjConstraint<Tkind>
{
}

public class Output_ObjBase<Targ>
  : Output_Named
  , I_ObjBase<Targ>
{
  public Targ typeArgs { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class Output_ObjTypeArg
  : Output_TypeRef
  , I_ObjTypeArg
{
  public _TypeParam As_TypeParam { get; set; }
}

public class Output_TypeParam
  : Output_Named
  , I_TypeParam
{
  public _Identifier typeParam { get; set; }
}

public class Output_Alternate<Tbase>
  : I_Alternate<Tbase>
{
  public Tbase type { get; set; }
  public _Collections collections { get; set; }
}

public class Output_ObjectFor<Tfor>
  : Outputfor
  , I_ObjectFor<Tfor>
{
  public _Identifier object { get; set; }
}

public class Output_Field<Tbase>
  : Output_Aliased
  , I_Field<Tbase>
{
  public Tbase type { get; set; }
  public _Modifiers modifiers { get; set; }
}

public class Output_ForParam<Tbase>
  : I_ForParam<Tbase>
{
  public _Alternate<Tbase> As_Alternate { get; set; }
  public _Field<Tbase> As_Field { get; set; }
}

public class Output_TypeDual
  : Output_TypeObject
  , I_TypeDual
{
}

public class Output_DualBase
  : Output_ObjBase
  , I_DualBase
{
}

public class Output_DualTypeParam
  : Output_ObjTypeParam
  , I_DualTypeParam
{
}

public class Output_DualField
  : Output_Field
  , I_DualField
{
}

public class Output_DualAlternate
  : Output_Alternate
  , I_DualAlternate
{
}

public class Output_DualTypeArg
  : Output_ObjTypeArg
  , I_DualTypeArg
{
}

public class Output_TypeInput
  : Output_TypeObject
  , I_TypeInput
{
}

public class Output_InputBase
  : Output_ObjBase
  , I_InputBase
{
  public _DualBase As_DualBase { get; set; }
}

public class Output_InputTypeParam
  : Output_ObjTypeParam
  , I_InputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public class Output_InputField
  : Output_Field
  , I_InputField
{
  public _Value default { get; set; }
}

public class Output_InputAlternate
  : Output_Alternate
  , I_InputAlternate
{
}

public class Output_InputTypeArg
  : Output_ObjTypeArg
  , I_InputTypeArg
{
}

public class Output_InputParam
  : Output_InputBase
  , I_InputParam
{
  public _Modifiers modifiers { get; set; }
  public _Value default { get; set; }
}

public class Output_TypeOutput
  : Output_TypeObject
  , I_TypeOutput
{
}

public class Output_OutputBase
  : Output_ObjBase
  , I_OutputBase
{
  public _DualBase As_DualBase { get; set; }
}

public class Output_OutputTypeParam
  : Output_ObjTypeParam
  , I_OutputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public class Output_OutputField
  : Output_Field
  , I_OutputField
{
  public _InputParam parameters { get; set; }
  public _OutputEnum As_OutputEnum { get; set; }
}

public class Output_OutputAlternate
  : Output_Alternate
  , I_OutputAlternate
{
}

public class Output_OutputTypeArg
  : Output_ObjTypeArg
  , I_OutputTypeArg
{
  public _Identifier label { get; set; }
}

public class Output_OutputEnum
  : Output_TypeRef
  , I_OutputEnum
{
  public _Identifier field { get; set; }
  public _Identifier label { get; set; }
}
