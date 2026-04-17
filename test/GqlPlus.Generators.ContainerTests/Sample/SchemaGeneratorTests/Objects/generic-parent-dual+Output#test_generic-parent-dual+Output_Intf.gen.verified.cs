//HintName: test_generic-parent-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp<ItestAltGnrcPrntDualOutp>
{
  ItestGnrcPrntDualOutpObject? As_GnrcPrntDualOutp { get; }
}

public interface ItestGnrcPrntDualOutpObject
  : ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>
{
}

public interface ItestRefGnrcPrntDualOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntDualOutpObject<TRef>? As_RefGnrcPrntDualOutp { get; }
}

public interface ItestRefGnrcPrntDualOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualOutpObject? As_AltGnrcPrntDualOutp { get; }
}

public interface ItestAltGnrcPrntDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
