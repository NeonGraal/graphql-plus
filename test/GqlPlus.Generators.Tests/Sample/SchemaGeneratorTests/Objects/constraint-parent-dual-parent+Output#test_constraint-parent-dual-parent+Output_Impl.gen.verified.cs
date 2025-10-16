//HintName: test_constraint-parent-dual-parent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public class testCnstPrntDualPrntOutp
  : testRefCnstPrntDualPrntOutp
  , ItestCnstPrntDualPrntOutp
{
}

public class testRefCnstPrntDualPrntOutp<Tref>
  : testref
  , ItestRefCnstPrntDualPrntOutp<Tref>
{
}

public class testPrntCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  public String AsString { get; set; }
}

public class testAltCnstPrntDualPrntOutp
  : testPrntCnstPrntDualPrntOutp
  , ItestAltCnstPrntDualPrntOutp
{
  public Number alt { get; set; }
}
