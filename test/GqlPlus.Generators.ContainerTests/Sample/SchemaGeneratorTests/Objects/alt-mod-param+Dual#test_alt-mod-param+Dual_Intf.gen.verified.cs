//HintName: test_alt-mod-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public interface ItestAltModParamDual<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestAltAltModParamDual>? AsAltAltModParamDual { get; }
  ItestAltModParamDualObject<TMod>? As_AltModParamDual { get; }
}

public interface ItestAltModParamDualObject<TMod>
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModParamDualObject? As_AltAltModParamDual { get; }
}

public interface ItestAltAltModParamDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
