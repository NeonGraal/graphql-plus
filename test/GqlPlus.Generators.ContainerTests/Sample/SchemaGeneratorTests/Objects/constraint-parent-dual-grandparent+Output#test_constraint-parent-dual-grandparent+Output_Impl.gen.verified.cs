//HintName: test_constraint-parent-dual-grandparent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public class testCnstPrntDualGrndOutp
  : testRefCnstPrntDualGrndOutp<ItestAltCnstPrntDualGrndOutp>
  , ItestCnstPrntDualGrndOutp
{
  public ItestCnstPrntDualGrndOutpObject AsCnstPrntDualGrndOutp { get; set; }
}

public class testRefCnstPrntDualGrndOutp<TRef>
  : testref
  , ItestRefCnstPrntDualGrndOutp<TRef>
{
  public ItestRefCnstPrntDualGrndOutpObject AsRefCnstPrntDualGrndOutp { get; set; }
}

public class testGrndCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  public string AsString { get; set; }
  public ItestGrndCnstPrntDualGrndOutpObject AsGrndCnstPrntDualGrndOutp { get; set; }
}

public class testPrntCnstPrntDualGrndOutp
  : testGrndCnstPrntDualGrndOutp
  , ItestPrntCnstPrntDualGrndOutp
{
  public ItestPrntCnstPrntDualGrndOutpObject AsPrntCnstPrntDualGrndOutp { get; set; }
}

public class testAltCnstPrntDualGrndOutp
  : testPrntCnstPrntDualGrndOutp
  , ItestAltCnstPrntDualGrndOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualGrndOutpObject AsAltCnstPrntDualGrndOutp { get; set; }
}
