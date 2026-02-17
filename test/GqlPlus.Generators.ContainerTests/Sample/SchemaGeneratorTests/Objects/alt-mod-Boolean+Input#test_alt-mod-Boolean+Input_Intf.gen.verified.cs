//HintName: test_alt-mod-Boolean+Input_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

public interface ItestAltModBoolInp
  : IGqlpModelImplementationBase
{
  IDictionary<bool, ItestAltAltModBoolInp>? AsAltAltModBoolInp { get; }
  ItestAltModBoolInpObject? As_AltModBoolInp { get; }
}

public interface ItestAltModBoolInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltAltModBoolInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltAltModBoolInpObject? As_AltAltModBoolInp { get; }
}

public interface ItestAltAltModBoolInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
