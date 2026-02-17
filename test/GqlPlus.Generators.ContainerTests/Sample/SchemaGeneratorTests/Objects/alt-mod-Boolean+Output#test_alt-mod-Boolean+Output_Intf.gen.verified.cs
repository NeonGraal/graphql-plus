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
  IDictionary<bool, ItestAltAltModBoolOutp>? AsAltAltModBoolOutp { get; }
  ItestAltModBoolOutpObject? As_AltModBoolOutp { get; }
}

public interface ItestAltModBoolOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltAltModBoolOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltAltModBoolOutpObject? As_AltAltModBoolOutp { get; }
}

public interface ItestAltAltModBoolOutpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
