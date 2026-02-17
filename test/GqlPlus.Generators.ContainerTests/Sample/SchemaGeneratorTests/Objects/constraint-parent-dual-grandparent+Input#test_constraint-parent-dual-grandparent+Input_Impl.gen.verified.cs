//HintName: test_constraint-parent-dual-grandparent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public class testCnstPrntDualGrndInp
  : testRefCnstPrntDualGrndInp<ItestAltCnstPrntDualGrndInp>
  , ItestCnstPrntDualGrndInp
{
}

public class testRefCnstPrntDualGrndInp<TRef>
  : ItestRefCnstPrntDualGrndInp<TRef>
{
}

public class testGrndCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
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
  public decimal Alt { get; set; }
}
