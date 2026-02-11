//HintName: test_generic-field-param+Input_Intf.gen.cs
// Generated from generic-field-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public interface ItestGnrcFieldParamInp
{
  ItestGnrcFieldParamInpObject AsGnrcFieldParamInp { get; }
}

public interface ItestGnrcFieldParamInpObject
{
  ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; }
}

public interface ItestRefGnrcFieldParamInp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcFieldParamInpObject AsRefGnrcFieldParamInp { get; }
}

public interface ItestRefGnrcFieldParamInpObject<TRef>
{
}

public interface ItestAltGnrcFieldParamInp
{
  string AsString { get; }
  ItestAltGnrcFieldParamInpObject AsAltGnrcFieldParamInp { get; }
}

public interface ItestAltGnrcFieldParamInpObject
{
  decimal Alt { get; }
}
