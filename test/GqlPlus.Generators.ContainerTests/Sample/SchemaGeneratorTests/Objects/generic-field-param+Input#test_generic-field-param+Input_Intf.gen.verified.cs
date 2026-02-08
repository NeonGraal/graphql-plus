//HintName: test_generic-field-param+Input_Intf.gen.cs
// Generated from generic-field-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public interface ItestGnrcFieldParamInp
{
}

public interface ItestGnrcFieldParamInpObject
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }
}

public interface ItestRefGnrcFieldParamInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcFieldParamInpObject<Tref>
{
}

public interface ItestAltGnrcFieldParamInp
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcFieldParamInpObject
{
  public ItestNumber Alt { get; set; }
}
