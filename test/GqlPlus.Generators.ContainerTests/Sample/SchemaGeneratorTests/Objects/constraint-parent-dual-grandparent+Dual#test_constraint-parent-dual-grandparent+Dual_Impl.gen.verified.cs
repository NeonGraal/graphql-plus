//HintName: test_constraint-parent-dual-grandparent+Dual_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public class testCnstPrntDualGrndDual
  : testRefCnstPrntDualGrndDual
  , ItestCnstPrntDualGrndDual
{
  public ItestCnstPrntDualGrndDualObject AsCnstPrntDualGrndDual { get; set; }
}

public class testRefCnstPrntDualGrndDual<Tref>
  : testref
  , ItestRefCnstPrntDualGrndDual<Tref>
{
  public ItestRefCnstPrntDualGrndDualObject AsRefCnstPrntDualGrndDual { get; set; }
}

public class testGrndCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  public ItestString AsString { get; set; }
  public ItestGrndCnstPrntDualGrndDualObject AsGrndCnstPrntDualGrndDual { get; set; }
}

public class testPrntCnstPrntDualGrndDual
  : testGrndCnstPrntDualGrndDual
  , ItestPrntCnstPrntDualGrndDual
{
  public ItestPrntCnstPrntDualGrndDualObject AsPrntCnstPrntDualGrndDual { get; set; }
}

public class testAltCnstPrntDualGrndDual
  : testPrntCnstPrntDualGrndDual
  , ItestAltCnstPrntDualGrndDual
{
  public ItestNumber Alt { get; set; }
  public ItestAltCnstPrntDualGrndDualObject AsAltCnstPrntDualGrndDual { get; set; }
}
