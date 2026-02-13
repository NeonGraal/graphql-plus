//HintName: test_constraint-parent-dual-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public class testCnstPrntDualPrntDual
  : testRefCnstPrntDualPrntDual<ItestAltCnstPrntDualPrntDual>
  , ItestCnstPrntDualPrntDual
{
  public ItestCnstPrntDualPrntDualObject AsCnstPrntDualPrntDual { get; set; }
}

public class testRefCnstPrntDualPrntDual<TRef>
  : ItestRefCnstPrntDualPrntDual<TRef>
{
  public TRef AsParent { get; set; }
  public ItestRefCnstPrntDualPrntDualObject<TRef> AsRefCnstPrntDualPrntDual { get; set; }
}

public class testPrntCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntDualPrntDualObject AsPrntCnstPrntDualPrntDual { get; set; }
}

public class testAltCnstPrntDualPrntDual
  : testPrntCnstPrntDualPrntDual
  , ItestAltCnstPrntDualPrntDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualPrntDualObject AsAltCnstPrntDualPrntDual { get; set; }
}
