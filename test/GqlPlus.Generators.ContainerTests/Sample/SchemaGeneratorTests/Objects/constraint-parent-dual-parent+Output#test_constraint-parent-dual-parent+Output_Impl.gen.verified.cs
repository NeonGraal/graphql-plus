//HintName: test_constraint-parent-dual-parent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public class testCnstPrntDualPrntOutp
  : testRefCnstPrntDualPrntOutp
  , ItestCnstPrntDualPrntOutp
{
  public ItestCnstPrntDualPrntOutpObject AsCnstPrntDualPrntOutp { get; set; }
}

public class testRefCnstPrntDualPrntOutp<Tref>
  : testref
  , ItestRefCnstPrntDualPrntOutp<Tref>
{
  public ItestRefCnstPrntDualPrntOutpObject AsRefCnstPrntDualPrntOutp { get; set; }
}

public class testPrntCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstPrntDualPrntOutpObject AsPrntCnstPrntDualPrntOutp { get; set; }
}

public class testAltCnstPrntDualPrntOutp
  : testPrntCnstPrntDualPrntOutp
  , ItestAltCnstPrntDualPrntOutp
{
  public ItestNumber Alt { get; set; }
  public ItestAltCnstPrntDualPrntOutpObject AsAltCnstPrntDualPrntOutp { get; set; }
}
