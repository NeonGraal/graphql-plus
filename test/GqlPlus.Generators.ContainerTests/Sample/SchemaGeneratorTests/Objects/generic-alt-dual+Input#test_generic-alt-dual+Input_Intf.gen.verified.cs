//HintName: test_generic-alt-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public interface ItestGnrcAltDualInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp>? AsRefGnrcAltDualInp { get; }
  ItestGnrcAltDualInpObject? As_GnrcAltDualInp { get; }
}

public interface ItestGnrcAltDualInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltDualInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualInpObject<TRef>? As_RefGnrcAltDualInp { get; }
}

public interface ItestRefGnrcAltDualInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltDualInpObject? As_AltGnrcAltDualInp { get; }
}

public interface ItestAltGnrcAltDualInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
