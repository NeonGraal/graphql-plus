//HintName: test_constraint-parent-obj-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public class testCnstPrntObjPrntDual
  : testRefCnstPrntObjPrntDual
  , ItestCnstPrntObjPrntDual
{
  public testCnstPrntObjPrntDual CnstPrntObjPrntDual { get; set; }
}

public class testRefCnstPrntObjPrntDual<Tref>
  : testref
  , ItestRefCnstPrntObjPrntDual<Tref>
{
  public testRefCnstPrntObjPrntDual RefCnstPrntObjPrntDual { get; set; }
}

public class testPrntCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  public testString AsString { get; set; }
  public testPrntCnstPrntObjPrntDual PrntCnstPrntObjPrntDual { get; set; }
}

public class testAltCnstPrntObjPrntDual
  : testPrntCnstPrntObjPrntDual
  , ItestAltCnstPrntObjPrntDual
{
  public testNumber alt { get; set; }
  public testAltCnstPrntObjPrntDual AltCnstPrntObjPrntDual { get; set; }
}
