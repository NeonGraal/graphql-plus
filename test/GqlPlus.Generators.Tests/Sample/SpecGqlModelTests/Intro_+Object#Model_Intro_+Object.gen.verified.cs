//HintName: Model_Intro_+Object.gen.cs
// Generated from Intro_+Object.graphql+

/*
*/

namespace GqlTest.Model_Intro__Object;

public interface I_TypeObject<Tkind,Tparent,Tfield,Talternate>
  : I_ChildType
{
  _ObjTypeParam typeParams { get; }
  Tfield fields { get; }
  Talternate alternates { get; }
  _ObjectFor<Tfield> allFields { get; }
  _ObjectFor<Talternate> allAlternates { get; }
}
public class Output_TypeObject<Tkind,Tparent,Tfield,Talternate>
  : Output_ChildType
  , I_TypeObject<Tkind,Tparent,Tfield,Talternate>
{
  public _ObjTypeParam typeParams { get; set; }
  public Tfield fields { get; set; }
  public Talternate alternates { get; set; }
  public _ObjectFor<Tfield> allFields { get; set; }
  public _ObjectFor<Talternate> allAlternates { get; set; }
}

public interface I_ObjConstraint<Tbase>
{
  _TypeSimple As_TypeSimple { get; }
  Tbase Asbase { get; }
}
public class Output_ObjConstraint<Tbase>
  : I_ObjConstraint<Tbase>
{
  public _TypeSimple As_TypeSimple { get; set; }
  public Tbase Asbase { get; set; }
}

public interface I_ObjType<Tbase>
{
  _BaseType<_TypeKind> As_BaseType { get; }
  _ObjConstraint<Tbase> As_ObjConstraint { get; }
}
public class Output_ObjType<Tbase>
  : I_ObjType<Tbase>
{
  public _BaseType<_TypeKind> As_BaseType { get; set; }
  public _ObjConstraint<Tbase> As_ObjConstraint { get; set; }
}

public interface I_ObjBase<Targ>
  : I_Described
{
  Targ typeArgs { get; }
  _ObjTypeParam As_ObjTypeParam { get; }
}
public class Output_ObjBase<Targ>
  : Output_Described
  , I_ObjBase<Targ>
{
  public Targ typeArgs { get; set; }
  public _ObjTypeParam As_ObjTypeParam { get; set; }
}

public interface I_ObjTypeArg
  : I_TypeRef
{
  _ObjTypeParam As_ObjTypeParam { get; }
}
public class Output_ObjTypeArg
  : Output_TypeRef
  , I_ObjTypeArg
{
  public _ObjTypeParam As_ObjTypeParam { get; set; }
}

public interface I_TypeParam
  : I_Identifier
{
}
public class Domain_TypeParam
  : Domain_Identifier
  , I_TypeParam
{
}

public interface I_ObjTypeParam
  : I_Described
{
  _TypeParam typeParam { get; }
}
public class Output_ObjTypeParam
  : Output_Described
  , I_ObjTypeParam
{
  public _TypeParam typeParam { get; set; }
}

public interface I_Alternate<Tbase>
{
  Tbase base { get; }
  _Collections collections { get; }
}
public class Output_Alternate<Tbase>
  : I_Alternate<Tbase>
{
  public Tbase base { get; set; }
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
  _Identifier dual { get; }
}
public class Output_DualBase
  : Output_ObjBase
  , I_DualBase
{
  public _Identifier dual { get; set; }
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
  _Identifier dual { get; }
}
public class Output_DualTypeArg
  : Output_ObjTypeArg
  , I_DualTypeArg
{
  public _Identifier dual { get; set; }
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
  _Identifier input { get; }
  _DualBase As_DualBase { get; }
}
public class Output_InputBase
  : Output_ObjBase
  , I_InputBase
{
  public _Identifier input { get; set; }
  public _DualBase As_DualBase { get; set; }
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
  _Identifier input { get; }
}
public class Output_InputTypeArg
  : Output_ObjTypeArg
  , I_InputTypeArg
{
  public _Identifier input { get; set; }
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
  _Identifier output { get; }
  _DualBase As_DualBase { get; }
}
public class Output_OutputBase
  : Output_ObjBase
  , I_OutputBase
{
  public _Identifier output { get; set; }
  public _DualBase As_DualBase { get; set; }
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
  _Identifier output { get; }
  _Identifier label { get; }
}
public class Output_OutputTypeArg
  : Output_ObjTypeArg
  , I_OutputTypeArg
{
  public _Identifier output { get; set; }
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
