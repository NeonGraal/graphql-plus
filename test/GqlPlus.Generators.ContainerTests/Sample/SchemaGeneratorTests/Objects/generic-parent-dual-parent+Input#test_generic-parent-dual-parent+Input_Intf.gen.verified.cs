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
  ItestGnrcPrntDualPrntInpObject? As_GnrcPrntDualPrntInp { get; }
}

public interface ItestGnrcPrntDualPrntInpObject
  : ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>
{
}

public interface ItestRefGnrcPrntDualPrntInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntInpObject<TRef>? As_RefGnrcPrntDualPrntInp { get; }
}

public interface ItestRefGnrcPrntDualPrntInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcPrntDualPrntInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntInpObject? As_AltGnrcPrntDualPrntInp { get; }
}

public interface ItestAltGnrcPrntDualPrntInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
