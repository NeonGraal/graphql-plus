//HintName: test_alt+Output_Intf.gen.cs
// Generated from {CurrentDirectory}alt+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Output;

public interface ItestAltOutp
  : IGqlpInterfaceBase
{
  ItestAltAltOutp? AsAltAltOutp { get; }
  ItestAltOutpObject? As_AltOutp { get; }
}

public interface ItestAltOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltOutpObject? As_AltAltOutp { get; }
}

public interface ItestAltAltOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
