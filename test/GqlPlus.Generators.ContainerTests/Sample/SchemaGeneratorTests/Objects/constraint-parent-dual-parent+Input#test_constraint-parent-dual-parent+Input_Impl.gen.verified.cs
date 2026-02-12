//HintName: test_constraint-parent-dual-parent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public class testCnstPrntDualPrntInp
  : testRefCnstPrntDualPrntInp<ItestAltCnstPrntDualPrntInp>
  , ItestCnstPrntDualPrntInp
{
  public ItestCnstPrntDualPrntInpObject AsCnstPrntDualPrntInp { get; set; }
}

public class testRefCnstPrntDualPrntInp<TRef>
  : ItestRefCnstPrntDualPrntInp<TRef>
{
  public TRef AsParent { get; set; }
  public ItestRefCnstPrntDualPrntInpObject<TRef> AsRefCnstPrntDualPrntInp { get; set; }
}

public class testPrntCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntDualPrntInpObject AsPrntCnstPrntDualPrntInp { get; set; }
}

public class testAltCnstPrntDualPrntInp
  : testPrntCnstPrntDualPrntInp
  , ItestAltCnstPrntDualPrntInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualPrntInpObject AsAltCnstPrntDualPrntInp { get; set; }
}
