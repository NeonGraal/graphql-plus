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
  ItestAltAltOutp AsAltAltOutp { get; }
  ItestAltOutpObject AsAltOutp { get; }
}

public interface ItestAltOutpObject
{
}

public interface ItestAltAltOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltAltOutpObject AsAltAltOutp { get; }
}

public interface ItestAltAltOutpObject
{
  decimal Alt { get; }
}
