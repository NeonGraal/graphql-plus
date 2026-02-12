//HintName: test_constraint-parent-obj-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public class testCnstPrntObjPrntDual
  : testRefCnstPrntObjPrntDual<ItestAltCnstPrntObjPrntDual>
  , ItestCnstPrntObjPrntDual
{
  public ItestCnstPrntObjPrntDualObject AsCnstPrntObjPrntDual { get; set; }
}

public class testRefCnstPrntObjPrntDual<TRef>
  : testref
  , ItestRefCnstPrntObjPrntDual<TRef>
{
  public ItestRefCnstPrntObjPrntDualObject<TRef> AsRefCnstPrntObjPrntDual { get; set; }
}

public class testPrntCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntObjPrntDualObject AsPrntCnstPrntObjPrntDual { get; set; }
}

public class testAltCnstPrntObjPrntDual
  : testPrntCnstPrntObjPrntDual
  , ItestAltCnstPrntObjPrntDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntObjPrntDualObject AsAltCnstPrntObjPrntDual { get; set; }
}
