//HintName: test_constraint-parent-dual-parent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public class testCnstPrntDualPrntInp
  : testRefCnstPrntDualPrntInp<ItestAltCnstPrntDualPrntInp>
  , ItestCnstPrntDualPrntInp
{
}

public class testRefCnstPrntDualPrntInp<TRef>
  : ItestRefCnstPrntDualPrntInp<TRef>
{
}

public class testPrntCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
}

public class testAltCnstPrntDualPrntInp
  : testPrntCnstPrntDualPrntInp
  , ItestAltCnstPrntDualPrntInp
{
  public decimal Alt { get; set; }
}
