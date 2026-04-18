//HintName: test_generic-parent-dual-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public interface ItestGnrcPrntDualPrntOutp
  : ItestRefGnrcPrntDualPrntOutp<ItestAltGnrcPrntDualPrntOutp>
{
  ItestGnrcPrntDualPrntOutpObject? As_GnrcPrntDualPrntOutp { get; }
}

public interface ItestGnrcPrntDualPrntOutpObject
  : ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>
{
}

public interface ItestRefGnrcPrntDualPrntOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntOutpObject<TRef>? As_RefGnrcPrntDualPrntOutp { get; }
}

public interface ItestRefGnrcPrntDualPrntOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualPrntOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntOutpObject? As_AltGnrcPrntDualPrntOutp { get; }
}

public interface ItestAltGnrcPrntDualPrntOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
