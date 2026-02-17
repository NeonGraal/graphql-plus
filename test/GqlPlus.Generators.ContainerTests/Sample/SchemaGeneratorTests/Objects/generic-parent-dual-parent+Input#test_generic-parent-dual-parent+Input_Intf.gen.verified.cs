//HintName: test_generic-parent-dual-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public interface ItestGnrcPrntDualPrntInp
  : ItestRefGnrcPrntDualPrntInp<ItestAltGnrcPrntDualPrntInp>
{
  ItestGnrcPrntDualPrntInpObject AsGnrcPrntDualPrntInp { get; }
}

public interface ItestGnrcPrntDualPrntInpObject
  : ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>
{
}

public interface ItestRefGnrcPrntDualPrntInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefGnrcPrntDualPrntInpObject<TRef> AsRefGnrcPrntDualPrntInp { get; }
}

public interface ItestRefGnrcPrntDualPrntInpObject<TRef>
{
}

public interface ItestAltGnrcPrntDualPrntInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntDualPrntInpObject AsAltGnrcPrntDualPrntInp { get; }
}

public interface ItestAltGnrcPrntDualPrntInpObject
{
  decimal Alt { get; }
}
