//HintName: test_field-mod-param+Output_Intf.gen.cs
// Generated from field-mod-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public interface ItestFieldModParamOutp<Tmod>
{
  ItestFieldModParamOutpObject AsFieldModParamOutp { get; }
}

public interface ItestFieldModParamOutpObject<Tmod>
{
  IDictionary<Tmod, ItestFldFieldModParamOutp> Field { get; }
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
