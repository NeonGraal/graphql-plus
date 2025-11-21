//HintName: test_constraint-parent-dual-parent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public class testCnstPrntDualPrntInp
  : testRefCnstPrntDualPrntInp
  , ItestCnstPrntDualPrntInp
{
  public testCnstPrntDualPrntInp CnstPrntDualPrntInp { get; set; }
}

public class testRefCnstPrntDualPrntInp<Tref>
  : testref
  , ItestRefCnstPrntDualPrntInp<Tref>
{
  public testRefCnstPrntDualPrntInp RefCnstPrntDualPrntInp { get; set; }
}

public class testPrntCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  public testString AsString { get; set; }
  public testPrntCnstPrntDualPrntInp PrntCnstPrntDualPrntInp { get; set; }
}

public class testAltCnstPrntDualPrntInp
  : testPrntCnstPrntDualPrntInp
  , ItestAltCnstPrntDualPrntInp
{
  public testNumber alt { get; set; }
  public testAltCnstPrntDualPrntInp AltCnstPrntDualPrntInp { get; set; }
}
