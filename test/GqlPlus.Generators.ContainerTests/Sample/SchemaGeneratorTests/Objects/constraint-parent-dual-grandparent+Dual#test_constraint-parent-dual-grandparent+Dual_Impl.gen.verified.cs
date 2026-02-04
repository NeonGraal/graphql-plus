//HintName: test_constraint-parent-dual-grandparent+Dual_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public class testCnstPrntDualGrndDual
  : testRefCnstPrntDualGrndDual
  , ItestCnstPrntDualGrndDual
{
  public testCnstPrntDualGrndDual CnstPrntDualGrndDual { get; set; }
}

public class testRefCnstPrntDualGrndDual<Tref>
  : testref
  , ItestRefCnstPrntDualGrndDual<Tref>
{
  public testRefCnstPrntDualGrndDual RefCnstPrntDualGrndDual { get; set; }
}

public class testGrndCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  public testString AsString { get; set; }
  public testGrndCnstPrntDualGrndDual GrndCnstPrntDualGrndDual { get; set; }
}

public class testPrntCnstPrntDualGrndDual
  : testGrndCnstPrntDualGrndDual
  , ItestPrntCnstPrntDualGrndDual
{
  public testPrntCnstPrntDualGrndDual PrntCnstPrntDualGrndDual { get; set; }
}

public class testAltCnstPrntDualGrndDual
  : testPrntCnstPrntDualGrndDual
  , ItestAltCnstPrntDualGrndDual
{
  public testNumber alt { get; set; }
  public testAltCnstPrntDualGrndDual AltCnstPrntDualGrndDual { get; set; }
}
