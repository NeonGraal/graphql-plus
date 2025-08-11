//HintName: Gqlp_constraint-parent-obj-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_obj_parent_Dual;

public class DualCnstPrntObjPrntDual
  : DualRefCnstPrntObjPrntDual
  , ICnstPrntObjPrntDual
{
}

public class DualRefCnstPrntObjPrntDual<Tref>
  : Dualref
  , IRefCnstPrntObjPrntDual<Tref>
{
}

public class DualPrntCnstPrntObjPrntDual
  : IPrntCnstPrntObjPrntDual
{
  public String AsString { get; set; }
}

public class DualAltCnstPrntObjPrntDual
  : DualPrntCnstPrntObjPrntDual
  , IAltCnstPrntObjPrntDual
{
  public Number alt { get; set; }
}
