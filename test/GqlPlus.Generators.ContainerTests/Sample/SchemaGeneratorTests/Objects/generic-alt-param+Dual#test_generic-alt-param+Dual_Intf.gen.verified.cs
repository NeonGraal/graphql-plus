//HintName: test_generic-alt-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public interface ItestGnrcAltParamDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual>? AsRefGnrcAltParamDual { get; }
  ItestGnrcAltParamDualObject? As_GnrcAltParamDual { get; }
}

public interface ItestGnrcAltParamDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltParamDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamDualObject<TRef>? As_RefGnrcAltParamDual { get; }
}

public interface ItestRefGnrcAltParamDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltParamDualObject? As_AltGnrcAltParamDual { get; }
}

public interface ItestAltGnrcAltParamDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
