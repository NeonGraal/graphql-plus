//HintName: test_generic-parent-dual+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public class testGnrcPrntDualOutp
  : testRefGnrcPrntDualOutp<ItestAltGnrcPrntDualOutp>
  , ItestGnrcPrntDualOutp
{
}

public class testRefGnrcPrntDualOutp<TRef>
  : ItestRefGnrcPrntDualOutp<TRef>
{
}

public class testAltGnrcPrntDualOutp
  : ItestAltGnrcPrntDualOutp
{
  public decimal Alt { get; set; }
}
