//HintName: test_alt+Output_Intf.gen.cs
// Generated from {CurrentDirectory}alt+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Output;

public interface ItestAltOutp
  : IGqlpModelImplementationBase
{
  ItestAltAltOutp? AsAltAltOutp { get; }
  ItestAltOutpObject? As_AltOutp { get; }
}

public interface ItestAltOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltAltOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltAltOutpObject? As_AltAltOutp { get; }
}

public interface ItestAltAltOutpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
