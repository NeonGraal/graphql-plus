//HintName: test_generic-parent-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp<ItestAltGnrcPrntDualOutp>
{
  ItestGnrcPrntDualOutpObject AsGnrcPrntDualOutp { get; }
}

public interface ItestGnrcPrntDualOutpObject
  : ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>
{
}

public interface ItestRefGnrcPrntDualOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcPrntDualOutpObject<TRef> AsRefGnrcPrntDualOutp { get; }
}

public interface ItestRefGnrcPrntDualOutpObject<TRef>
{
}

public interface ItestAltGnrcPrntDualOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntDualOutpObject AsAltGnrcPrntDualOutp { get; }
}

public interface ItestAltGnrcPrntDualOutpObject
{
  decimal Alt { get; }
}
