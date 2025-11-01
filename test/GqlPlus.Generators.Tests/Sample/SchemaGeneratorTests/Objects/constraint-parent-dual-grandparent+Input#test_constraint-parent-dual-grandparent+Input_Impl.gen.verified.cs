//HintName: test_constraint-parent-dual-grandparent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public class testCnstPrntDualGrndInp
  : testRefCnstPrntDualGrndInp
  , ItestCnstPrntDualGrndInp
{
  public testCnstPrntDualGrndInp CnstPrntDualGrndInp { get; set; }
}

public class testRefCnstPrntDualGrndInp<Tref>
  : testref
  , ItestRefCnstPrntDualGrndInp<Tref>
{
  public testRefCnstPrntDualGrndInp RefCnstPrntDualGrndInp { get; set; }
}

public class testGrndCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  public testString AsString { get; set; }
  public testGrndCnstPrntDualGrndInp GrndCnstPrntDualGrndInp { get; set; }
}

public class testPrntCnstPrntDualGrndInp
  : testGrndCnstPrntDualGrndInp
  , ItestPrntCnstPrntDualGrndInp
{
  public testPrntCnstPrntDualGrndInp PrntCnstPrntDualGrndInp { get; set; }
}

public class testAltCnstPrntDualGrndInp
  : testPrntCnstPrntDualGrndInp
  , ItestAltCnstPrntDualGrndInp
{
  public testNumber alt { get; set; }
  public testAltCnstPrntDualGrndInp AltCnstPrntDualGrndInp { get; set; }
}
