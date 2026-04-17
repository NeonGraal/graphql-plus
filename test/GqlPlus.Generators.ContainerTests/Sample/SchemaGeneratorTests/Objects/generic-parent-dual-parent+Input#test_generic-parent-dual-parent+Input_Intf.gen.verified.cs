//HintName: test_generic-parent-dual-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntInpObject<TRef>? As_RefGnrcPrntDualPrntInp { get; }
}

public interface ItestRefGnrcPrntDualPrntInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualPrntInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntInpObject? As_AltGnrcPrntDualPrntInp { get; }
}

public interface ItestAltGnrcPrntDualPrntInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
