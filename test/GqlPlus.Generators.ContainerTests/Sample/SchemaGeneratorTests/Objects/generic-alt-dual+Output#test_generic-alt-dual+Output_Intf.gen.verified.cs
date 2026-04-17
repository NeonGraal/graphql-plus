//HintName: test_generic-alt-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public interface ItestGnrcAltDualOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp>? AsRefGnrcAltDualOutp { get; }
  ItestGnrcAltDualOutpObject? As_GnrcAltDualOutp { get; }
}

public interface ItestGnrcAltDualOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltDualOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualOutpObject<TRef>? As_RefGnrcAltDualOutp { get; }
}

public interface ItestRefGnrcAltDualOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltDualOutpObject? As_AltGnrcAltDualOutp { get; }
}

public interface ItestAltGnrcAltDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
