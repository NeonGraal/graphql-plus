//HintName: test_constraint-alt-dual+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public class testCnstAltDualOutp
  : ItestCnstAltDualOutp
{
}

public class testRefCnstAltDualOutp<TRef>
  : ItestRefCnstAltDualOutp<TRef>
{
}

public class testPrntCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
}

public class testAltCnstAltDualOutp
  : testPrntCnstAltDualOutp
  , ItestAltCnstAltDualOutp
{
  public decimal Alt { get; set; }
}
