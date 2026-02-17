//HintName: test_constraint-parent-dual-grandparent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public class testCnstPrntDualGrndDual
  : testRefCnstPrntDualGrndDual<ItestAltCnstPrntDualGrndDual>
  , ItestCnstPrntDualGrndDual
{
}

public class testRefCnstPrntDualGrndDual<TRef>
  : ItestRefCnstPrntDualGrndDual<TRef>
{
}

public class testGrndCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
}

public class testPrntCnstPrntDualGrndDual
  : testGrndCnstPrntDualGrndDual
  , ItestPrntCnstPrntDualGrndDual
{
}

public class testAltCnstPrntDualGrndDual
  : testPrntCnstPrntDualGrndDual
  , ItestAltCnstPrntDualGrndDual
{
  public decimal Alt { get; set; }
}
