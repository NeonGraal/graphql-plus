//HintName: test_alt+Input_Intf.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

public interface ItestAltInp
  : IGqlpInterfaceBase
{
  ItestAltAltInp? AsAltAltInp { get; }
  ItestAltInpObject? As_AltInp { get; }
}

public interface ItestAltInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltInpObject? As_AltAltInp { get; }
}

public interface ItestAltAltInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
