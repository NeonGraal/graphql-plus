//HintName: test_constraint-parent-obj-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public class testCnstPrntObjPrntDual
  : testRefCnstPrntObjPrntDual<ItestAltCnstPrntObjPrntDual>
  , ItestCnstPrntObjPrntDual
{
}

public class testRefCnstPrntObjPrntDual<TRef>
  : ItestRefCnstPrntObjPrntDual<TRef>
{
}

public class testPrntCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
}

public class testAltCnstPrntObjPrntDual
  : testPrntCnstPrntObjPrntDual
  , ItestAltCnstPrntObjPrntDual
{
  public decimal Alt { get; set; }
}
