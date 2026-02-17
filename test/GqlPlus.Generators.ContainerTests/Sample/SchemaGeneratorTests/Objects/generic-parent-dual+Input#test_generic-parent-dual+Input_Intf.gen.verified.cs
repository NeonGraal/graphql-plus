//HintName: test_generic-parent-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public interface ItestGnrcPrntDualInp
  : ItestRefGnrcPrntDualInp<ItestAltGnrcPrntDualInp>
{
  ItestGnrcPrntDualInpObject AsGnrcPrntDualInp { get; }
}

public interface ItestGnrcPrntDualInpObject
  : ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>
{
}

public interface ItestRefGnrcPrntDualInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcPrntDualInpObject<TRef> AsRefGnrcPrntDualInp { get; }
}

public interface ItestRefGnrcPrntDualInpObject<TRef>
{
}

public interface ItestAltGnrcPrntDualInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntDualInpObject AsAltGnrcPrntDualInp { get; }
}

public interface ItestAltGnrcPrntDualInpObject
{
  decimal Alt { get; }
}
