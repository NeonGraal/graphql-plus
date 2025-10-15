//HintName: test_constraint-parent-obj-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public class DualtestCnstPrntObjPrntDual
  : DualtestRefCnstPrntObjPrntDual
  , ItestCnstPrntObjPrntDual
{
}

public class DualtestRefCnstPrntObjPrntDual<Tref>
  : Dualtestref
  , ItestRefCnstPrntObjPrntDual<Tref>
{
}

public class DualtestPrntCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  public String AsString { get; set; }
}

public class DualtestAltCnstPrntObjPrntDual
  : DualtestPrntCnstPrntObjPrntDual
  , ItestAltCnstPrntObjPrntDual
{
  public Number alt { get; set; }
}
