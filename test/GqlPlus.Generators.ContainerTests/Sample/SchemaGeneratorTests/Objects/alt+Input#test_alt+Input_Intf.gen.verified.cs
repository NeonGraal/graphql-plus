//HintName: test_alt+Input_Intf.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

public interface ItestAltInp
  : IGqlpModelImplementationBase
{
  ItestAltAltInp? AsAltAltInp { get; }
  ItestAltInpObject? As_AltInp { get; }
}

public interface ItestAltInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltAltInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltAltInpObject? As_AltAltInp { get; }
}

public interface ItestAltAltInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
