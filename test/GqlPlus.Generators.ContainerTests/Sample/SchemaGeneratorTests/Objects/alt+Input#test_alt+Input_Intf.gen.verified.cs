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
  ItestAltAltInp AsAltAltInp { get; }
  ItestAltInpObject AsAltInp { get; }
}

public interface ItestAltInpObject
{
}

public interface ItestAltAltInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltAltInpObject AsAltAltInp { get; }
}

public interface ItestAltAltInpObject
{
  decimal Alt { get; }
}
