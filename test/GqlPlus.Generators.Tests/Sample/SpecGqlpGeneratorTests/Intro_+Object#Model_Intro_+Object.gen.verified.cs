//HintName: Model_Intro_+Object.gen.cs
// Generated from Intro_+Object.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_Intro__Object;

public interface I_ObjectKind
{
}
public class Domain_ObjectKind
  : I_ObjectKind
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

public interface I_ObjTypeParam<Tkind>
  : I_Named
{
  _ObjConstraint<Tkind> constraint { get; }
}
public class Output_ObjTypeParam<Tkind>
  : Output_Named
  , I_ObjTypeParam<Tkind>
{
  public _ObjConstraint<Tkind> constraint { get; set; }
}

public interface I_ObjConstraint<Tkind>
  : I_TypeRef
{
}
public class Output_ObjConstraint<Tkind>
  : Output_TypeRef
  , I_ObjConstraint<Tkind>
{
}

public interface I_ObjBase<Targ>
  : I_Named
{
  Targ typeArgs { get; }
  _TypeParam As_TypeParam { get; }
}
public class Output_ObjBase<Targ>
  : Output_Named
  , I_ObjBase<Targ>
{
  public Targ typeArgs { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public interface I_ObjTypeArg
  : I_TypeRef
{
  _TypeParam As_TypeParam { get; }
}
public class Output_ObjTypeArg
  : Output_TypeRef
  , I_ObjTypeArg
{
  public _TypeParam As_TypeParam { get; set; }
}

public interface I_TypeParam
  : I_Named
{
  _Identifier typeParam { get; }
}
public class Output_TypeParam
  : Output_Named
  , I_TypeParam
{
  public _Identifier typeParam { get; set; }
}

public interface I_Alternate<Tbase>
{
  Tbase type { get; }
  _Collections collections { get; }
}
public class Output_Alternate<Tbase>
  : I_Alternate<Tbase>
{
  public Tbase type { get; set; }
  public _Collections collections { get; set; }
}

public interface I_ObjectFor<Tfor>
  : Ifor
{
  _Identifier object { get; }
}
public class Output_ObjectFor<Tfor>
  : Outputfor
  , I_ObjectFor<Tfor>
{
  public _Identifier object { get; set; }
}

public interface I_Field<Tbase>
  : I_Aliased
{
  Tbase type { get; }
  _Modifiers modifiers { get; }
}
public class Output_Field<Tbase>
  : Output_Aliased
  , I_Field<Tbase>
{
  public Tbase type { get; set; }
  public _Modifiers modifiers { get; set; }
}

public interface I_ForParam<Tbase>
{
  _Alternate<Tbase> As_Alternate { get; }
  _Field<Tbase> As_Field { get; }
}
public class Output_ForParam<Tbase>
  : I_ForParam<Tbase>
{
  public _Alternate<Tbase> As_Alternate { get; set; }
  public _Field<Tbase> As_Field { get; set; }
}

public interface I_TypeDual
  : I_TypeObject
{
}
public class Output_TypeDual
  : Output_TypeObject
  , I_TypeDual
{
}

public interface I_DualBase
  : I_ObjBase
{
}
public class Output_DualBase
  : Output_ObjBase
  , I_DualBase
{
}

public interface I_DualTypeParam
  : I_ObjTypeParam
{
}
public class Output_DualTypeParam
  : Output_ObjTypeParam
  , I_DualTypeParam
{
}

public interface I_DualField
  : I_Field
{
}
public class Output_DualField
  : Output_Field
  , I_DualField
{
}

public interface I_DualAlternate
  : I_Alternate
{
}
public class Output_DualAlternate
  : Output_Alternate
  , I_DualAlternate
{
}

public interface I_DualTypeArg
  : I_ObjTypeArg
{
}
public class Output_DualTypeArg
  : Output_ObjTypeArg
  , I_DualTypeArg
{
}

public interface I_TypeInput
  : I_TypeObject
{
}
public class Output_TypeInput
  : Output_TypeObject
  , I_TypeInput
{
}

public interface I_InputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}
public class Output_InputBase
  : Output_ObjBase
  , I_InputBase
{
  public _DualBase As_DualBase { get; set; }
}

public interface I_InputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
}
public class Output_InputTypeParam
  : Output_ObjTypeParam
  , I_InputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public interface I_InputField
  : I_Field
{
  _Constant default { get; }
}
public class Output_InputField
  : Output_Field
  , I_InputField
{
  public _Constant default { get; set; }
}

public interface I_InputAlternate
  : I_Alternate
{
}
public class Output_InputAlternate
  : Output_Alternate
  , I_InputAlternate
{
}

public interface I_InputTypeArg
  : I_ObjTypeArg
{
}
public class Output_InputTypeArg
  : Output_ObjTypeArg
  , I_InputTypeArg
{
}

public interface I_InputParam
  : I_InputBase
{
  _Modifiers modifiers { get; }
  _Constant default { get; }
}
public class Output_InputParam
  : Output_InputBase
  , I_InputParam
{
  public _Modifiers modifiers { get; set; }
  public _Constant default { get; set; }
}

public interface I_TypeOutput
  : I_TypeObject
{
}
public class Output_TypeOutput
  : Output_TypeObject
  , I_TypeOutput
{
}

public interface I_OutputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}
public class Output_OutputBase
  : Output_ObjBase
  , I_OutputBase
{
  public _DualBase As_DualBase { get; set; }
}

public interface I_OutputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}
public class Output_OutputTypeParam
  : Output_ObjTypeParam
  , I_OutputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public interface I_OutputField
  : I_Field
{
  _InputParam parameters { get; }
  _OutputEnum As_OutputEnum { get; }
}
public class Output_OutputField
  : Output_Field
  , I_OutputField
{
  public _InputParam parameters { get; set; }
  public _OutputEnum As_OutputEnum { get; set; }
}

public interface I_OutputAlternate
  : I_Alternate
{
}
public class Output_OutputAlternate
  : Output_Alternate
  , I_OutputAlternate
{
}

public interface I_OutputTypeArg
  : I_ObjTypeArg
{
  _Identifier label { get; }
}
public class Output_OutputTypeArg
  : Output_ObjTypeArg
  , I_OutputTypeArg
{
  public _Identifier label { get; set; }
}

public interface I_OutputEnum
  : I_TypeRef
{
  _Identifier field { get; }
  _Identifier label { get; }
}
public class Output_OutputEnum
  : Output_TypeRef
  , I_OutputEnum
{
  public _Identifier field { get; set; }
  public _Identifier label { get; set; }
}
