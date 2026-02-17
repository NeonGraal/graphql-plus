//HintName: test_field-mod-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public interface ItestFieldModParamOutp<TMod>
  : IGqlpModelImplementationBase
{
  ItestFieldModParamOutpObject<TMod> AsFieldModParamOutp { get; }
}

public interface ItestFieldModParamOutpObject<TMod>
{
  IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; }
}

public interface ItestFldFieldModParamOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestFldFieldModParamOutpObject AsFldFieldModParamOutp { get; }
}

public interface ItestFldFieldModParamOutpObject
{
  decimal Field { get; }
}
