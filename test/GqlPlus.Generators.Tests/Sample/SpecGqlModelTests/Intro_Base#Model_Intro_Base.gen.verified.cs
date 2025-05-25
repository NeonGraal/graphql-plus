//HintName: Model_Intro_Base.gen.cs
// Generated from Intro_Base.graphql+

/*
*/

namespace GqlTest.Model_Intro_Base;

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
