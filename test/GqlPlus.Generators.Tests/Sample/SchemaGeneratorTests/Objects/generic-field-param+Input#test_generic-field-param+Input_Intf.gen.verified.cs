//HintName: test_generic-field-param+Input_Intf.gen.cs
// Generated from generic-field-param+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public interface ItestGnrcFieldParamInp
{
  RefGnrcFieldParamInp<AltGnrcFieldParamInp> field { get; }
}

public interface ItestRefGnrcFieldParamInp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcFieldParamInp
{
  Number alt { get; }
  String AsString { get; }
}
