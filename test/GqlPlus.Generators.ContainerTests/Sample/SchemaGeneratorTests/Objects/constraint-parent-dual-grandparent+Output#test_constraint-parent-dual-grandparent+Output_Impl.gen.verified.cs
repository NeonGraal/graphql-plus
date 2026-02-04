//HintName: test_constraint-parent-dual-grandparent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public class testCnstPrntDualGrndOutp
  : testRefCnstPrntDualGrndOutp
  , ItestCnstPrntDualGrndOutp
{
  public testCnstPrntDualGrndOutp CnstPrntDualGrndOutp { get; set; }
}

public class testRefCnstPrntDualGrndOutp<Tref>
  : testref
  , ItestRefCnstPrntDualGrndOutp<Tref>
{
  public testRefCnstPrntDualGrndOutp RefCnstPrntDualGrndOutp { get; set; }
}

public class testGrndCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  public testString AsString { get; set; }
  public testGrndCnstPrntDualGrndOutp GrndCnstPrntDualGrndOutp { get; set; }
}

public class testPrntCnstPrntDualGrndOutp
  : testGrndCnstPrntDualGrndOutp
  , ItestPrntCnstPrntDualGrndOutp
{
  public testPrntCnstPrntDualGrndOutp PrntCnstPrntDualGrndOutp { get; set; }
}

public class testAltCnstPrntDualGrndOutp
  : testPrntCnstPrntDualGrndOutp
  , ItestAltCnstPrntDualGrndOutp
{
  public testNumber alt { get; set; }
  public testAltCnstPrntDualGrndOutp AltCnstPrntDualGrndOutp { get; set; }
}
