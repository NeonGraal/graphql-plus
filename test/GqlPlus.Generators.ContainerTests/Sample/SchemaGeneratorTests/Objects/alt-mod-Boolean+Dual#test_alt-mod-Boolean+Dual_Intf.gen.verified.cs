//HintName: test_alt-mod-Boolean+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public interface ItestAltModBoolDual
  : IGqlpInterfaceBase
{
  IDictionary<bool, ItestAltAltModBoolDual>? AsAltAltModBoolDual { get; }
  ItestAltModBoolDualObject? As_AltModBoolDual { get; }
}

public interface ItestAltModBoolDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModBoolDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModBoolDualObject? As_AltAltModBoolDual { get; }
}

public interface ItestAltAltModBoolDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
