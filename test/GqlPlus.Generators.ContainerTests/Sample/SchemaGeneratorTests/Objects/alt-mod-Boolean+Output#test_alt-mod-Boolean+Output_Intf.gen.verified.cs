//HintName: test_alt-mod-Boolean+Output_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

public interface ItestAltModBoolOutp
  : IGqlpInterfaceBase
{
  IDictionary<bool, ItestAltAltModBoolOutp>? AsAltAltModBoolOutp { get; }
  ItestAltModBoolOutpObject? As_AltModBoolOutp { get; }
}

public interface ItestAltModBoolOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModBoolOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModBoolOutpObject? As_AltAltModBoolOutp { get; }
}

public interface ItestAltAltModBoolOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
