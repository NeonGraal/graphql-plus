//HintName: Model_Intro_Base.gen.cs
// Generated from Intro_Base.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_Intro_Base;

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
