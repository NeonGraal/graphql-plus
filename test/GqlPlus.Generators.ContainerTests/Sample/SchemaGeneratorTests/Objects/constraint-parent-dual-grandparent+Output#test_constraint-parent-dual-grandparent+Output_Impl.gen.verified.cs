//HintName: test_constraint-parent-dual-grandparent+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public class testCnstPrntDualGrndOutp
  : testRefCnstPrntDualGrndOutp<ItestAltCnstPrntDualGrndOutp>
  , ItestCnstPrntDualGrndOutp
{
}

public class testRefCnstPrntDualGrndOutp<TRef>
  : ItestRefCnstPrntDualGrndOutp<TRef>
{
}

public class testGrndCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
}

public class testPrntCnstPrntDualGrndOutp
  : testGrndCnstPrntDualGrndOutp
  , ItestPrntCnstPrntDualGrndOutp
{
}

public class testAltCnstPrntDualGrndOutp
  : testPrntCnstPrntDualGrndOutp
  , ItestAltCnstPrntDualGrndOutp
{
  public decimal Alt { get; set; }
}
