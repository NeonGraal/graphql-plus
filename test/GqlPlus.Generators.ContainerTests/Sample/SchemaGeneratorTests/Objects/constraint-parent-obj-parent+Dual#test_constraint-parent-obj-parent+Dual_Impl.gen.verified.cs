//HintName: test_constraint-parent-obj-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public class testCnstPrntObjPrntDual
  : testRefCnstPrntObjPrntDual
  , ItestCnstPrntObjPrntDual
{
}

public class testRefCnstPrntObjPrntDual<Tref>
  : testref
  , ItestRefCnstPrntObjPrntDual<Tref>
{
}

public class testPrntCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  public ItestString AsString { get; set; }
}

public class testAltCnstPrntObjPrntDual
  : testPrntCnstPrntObjPrntDual
  , ItestAltCnstPrntObjPrntDual
{
  public ItestNumber Alt { get; set; }
}
