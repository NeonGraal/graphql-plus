//HintName: test_alt-mod-Boolean+Output_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

public interface ItestAltModBoolOutp
  : IGqlpModelImplementationBase
{
  IDictionary<bool, ItestAltAltModBoolOutp> AsAltAltModBoolOutp { get; }
  ItestAltModBoolOutpObject AsAltModBoolOutp { get; }
}

public interface ItestAltModBoolOutpObject
{
}

public interface ItestAltAltModBoolOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltAltModBoolOutpObject AsAltAltModBoolOutp { get; }
}

public interface ItestAltAltModBoolOutpObject
{
  decimal Alt { get; }
}
