//HintName: test_field-mod-param+Input_Intf.gen.cs
// Generated from field-mod-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public interface ItestFieldModParamInp<TMod>
{
  ItestFieldModParamInpObject AsFieldModParamInp { get; }
}

public interface ItestFieldModParamInpObject<TMod>
{
  IDictionary<TMod, ItestFldFieldModParamInp> Field { get; }
}

public interface ItestFldFieldModParamInp
{
  string AsString { get; }
  ItestFldFieldModParamInpObject AsFldFieldModParamInp { get; }
}

public interface ItestFldFieldModParamInpObject
{
  decimal Field { get; }
}
