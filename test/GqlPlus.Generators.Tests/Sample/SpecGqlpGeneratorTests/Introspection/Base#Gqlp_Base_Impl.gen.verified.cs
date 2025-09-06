//HintName: Gqlp_Base_Impl.gen.cs
// Generated from Base.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Base;

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
