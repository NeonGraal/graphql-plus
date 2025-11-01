//HintName: test_constraint-parent-dual-parent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public class testCnstPrntDualPrntOutp
  : testRefCnstPrntDualPrntOutp
  , ItestCnstPrntDualPrntOutp
{
  public testCnstPrntDualPrntOutp CnstPrntDualPrntOutp { get; set; }
}

public class testRefCnstPrntDualPrntOutp<Tref>
  : testref
  , ItestRefCnstPrntDualPrntOutp<Tref>
{
  public testRefCnstPrntDualPrntOutp RefCnstPrntDualPrntOutp { get; set; }
}

public class testPrntCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  public testString AsString { get; set; }
  public testPrntCnstPrntDualPrntOutp PrntCnstPrntDualPrntOutp { get; set; }
}

public class testAltCnstPrntDualPrntOutp
  : testPrntCnstPrntDualPrntOutp
  , ItestAltCnstPrntDualPrntOutp
{
  public testNumber alt { get; set; }
  public testAltCnstPrntDualPrntOutp AltCnstPrntDualPrntOutp { get; set; }
}
