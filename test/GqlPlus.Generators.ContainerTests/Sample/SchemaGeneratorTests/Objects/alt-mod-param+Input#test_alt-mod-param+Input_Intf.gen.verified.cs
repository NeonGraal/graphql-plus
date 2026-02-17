//HintName: test_alt-mod-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public interface ItestAltModParamInp<TMod>
  : IGqlpModelImplementationBase
{
  IDictionary<TMod, ItestAltAltModParamInp> AsAltAltModParamInp { get; }
  ItestAltModParamInpObject<TMod> AsAltModParamInp { get; }
}

public interface ItestAltModParamInpObject<TMod>
{
}

public interface ItestAltAltModParamInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltAltModParamInpObject AsAltAltModParamInp { get; }
}

public interface ItestAltAltModParamInpObject
{
  decimal Alt { get; }
}
