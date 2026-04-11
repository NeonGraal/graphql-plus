//HintName: test_alt-mod-Boolean+Input_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

public interface ItestAltModBoolInp
  : IGqlpInterfaceBase
{
  IDictionary<bool, ItestAltAltModBoolInp>? AsAltAltModBoolInp { get; }
  ItestAltModBoolInpObject? As_AltModBoolInp { get; }
}

public interface ItestAltModBoolInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModBoolInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModBoolInpObject? As_AltAltModBoolInp { get; }
}

public interface ItestAltAltModBoolInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
