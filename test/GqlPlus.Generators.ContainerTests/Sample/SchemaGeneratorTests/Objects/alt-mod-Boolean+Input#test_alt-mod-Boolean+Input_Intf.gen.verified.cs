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
  IDictionary<bool, ItestAltAltModBoolInp> AsAltAltModBoolInp { get; }
  ItestAltModBoolInpObject AsAltModBoolInp { get; }
}

public interface ItestAltModBoolInpObject
{
}

public interface ItestAltAltModBoolInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltAltModBoolInpObject AsAltAltModBoolInp { get; }
}

public interface ItestAltAltModBoolInpObject
{
  decimal Alt { get; }
}
