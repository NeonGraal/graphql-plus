//HintName: test_alt-mod-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public interface ItestAltModParamInp<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestAltAltModParamInp>? AsAltAltModParamInp { get; }
  ItestAltModParamInpObject<TMod>? As_AltModParamInp { get; }
}

public interface ItestAltModParamInpObject<TMod>
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModParamInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModParamInpObject? As_AltAltModParamInp { get; }
}

public interface ItestAltAltModParamInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
