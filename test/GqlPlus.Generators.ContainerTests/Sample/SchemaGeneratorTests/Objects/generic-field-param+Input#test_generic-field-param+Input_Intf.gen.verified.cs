//HintName: test_generic-field-param+Input_Intf.gen.cs
// Generated from generic-field-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public interface ItestGnrcFieldParamInp
{
  public ItestGnrcFieldParamInpObject AsGnrcFieldParamInp { get; set; }
}

public interface ItestGnrcFieldParamInpObject
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }
}

public interface ItestRefGnrcFieldParamInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldParamInpObject AsRefGnrcFieldParamInp { get; set; }
}

public interface ItestRefGnrcFieldParamInpObject<Tref>
{
}

public interface ItestAltGnrcFieldParamInp
{
  public string AsString { get; set; }
  public ItestAltGnrcFieldParamInpObject AsAltGnrcFieldParamInp { get; set; }
}

public interface ItestAltGnrcFieldParamInpObject
{
  public decimal Alt { get; set; }
}
