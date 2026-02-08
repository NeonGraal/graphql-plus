//HintName: test_constraint-parent-dual-grandparent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public class testCnstPrntDualGrndInp
  : testRefCnstPrntDualGrndInp
  , ItestCnstPrntDualGrndInp
{
}

public class testRefCnstPrntDualGrndInp<Tref>
  : testref
  , ItestRefCnstPrntDualGrndInp<Tref>
{
}

public class testGrndCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  public ItestString AsString { get; set; }
}

public class testPrntCnstPrntDualGrndInp
  : testGrndCnstPrntDualGrndInp
  , ItestPrntCnstPrntDualGrndInp
{
}

public class testAltCnstPrntDualGrndInp
  : testPrntCnstPrntDualGrndInp
  , ItestAltCnstPrntDualGrndInp
{
  public ItestNumber Alt { get; set; }
}
