//HintName: test_alt-mod-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public interface ItestAltModParamOutp<TMod>
  : IGqlpModelImplementationBase
{
  IDictionary<TMod, ItestAltAltModParamOutp> AsAltAltModParamOutp { get; }
  ItestAltModParamOutpObject<TMod> AsAltModParamOutp { get; }
}

public interface ItestAltModParamOutpObject<TMod>
{
}

public interface ItestAltAltModParamOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltAltModParamOutpObject AsAltAltModParamOutp { get; }
}

public interface ItestAltAltModParamOutpObject
{
  decimal Alt { get; }
}
