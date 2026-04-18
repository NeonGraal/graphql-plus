//HintName: test_alt-mod-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public interface ItestAltModParamOutp<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestAltAltModParamOutp>? AsAltAltModParamOutp { get; }
  ItestAltModParamOutpObject<TMod>? As_AltModParamOutp { get; }
}

public interface ItestAltModParamOutpObject<TMod>
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModParamOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModParamOutpObject? As_AltAltModParamOutp { get; }
}

public interface ItestAltAltModParamOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
