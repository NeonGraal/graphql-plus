//HintName: test_constraint-parent-dual-grandparent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public class testCnstPrntDualGrndInp
  : testRefCnstPrntDualGrndInp
  , ItestCnstPrntDualGrndInp
{
  public ItestCnstPrntDualGrndInpObject AsCnstPrntDualGrndInp { get; set; }
}

public class testRefCnstPrntDualGrndInp<Tref>
  : testref
  , ItestRefCnstPrntDualGrndInp<Tref>
{
  public ItestRefCnstPrntDualGrndInpObject AsRefCnstPrntDualGrndInp { get; set; }
}

public class testGrndCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  public string AsString { get; set; }
  public ItestGrndCnstPrntDualGrndInpObject AsGrndCnstPrntDualGrndInp { get; set; }
}

public class testPrntCnstPrntDualGrndInp
  : testGrndCnstPrntDualGrndInp
  , ItestPrntCnstPrntDualGrndInp
{
  public ItestPrntCnstPrntDualGrndInpObject AsPrntCnstPrntDualGrndInp { get; set; }
}

public class testAltCnstPrntDualGrndInp
  : testPrntCnstPrntDualGrndInp
  , ItestAltCnstPrntDualGrndInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualGrndInpObject AsAltCnstPrntDualGrndInp { get; set; }
}
