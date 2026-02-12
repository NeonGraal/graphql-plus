//HintName: test_field-mod-param+Output_Intf.gen.cs
// Generated from field-mod-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public interface ItestFieldModParamOutp<TMod>
{
  ItestFieldModParamOutpObject<TMod> AsFieldModParamOutp { get; }
}

public interface ItestFieldModParamOutpObject<TMod>
{
  IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; }
}

public interface ItestFldFieldModParamOutp
{
  string AsString { get; }
  ItestFldFieldModParamOutpObject AsFldFieldModParamOutp { get; }
}

public interface ItestFldFieldModParamOutpObject
{
  decimal Field { get; }
}
