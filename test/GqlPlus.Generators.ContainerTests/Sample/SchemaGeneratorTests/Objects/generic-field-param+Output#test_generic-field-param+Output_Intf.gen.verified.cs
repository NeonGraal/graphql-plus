//HintName: test_generic-field-param+Output_Intf.gen.cs
// Generated from generic-field-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public interface ItestGnrcFieldParamOutp
{
  public ItestGnrcFieldParamOutpObject AsGnrcFieldParamOutp { get; set; }
}

public interface ItestGnrcFieldParamOutpObject
{
  public ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; set; }
}

public interface ItestRefGnrcFieldParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldParamOutpObject AsRefGnrcFieldParamOutp { get; set; }
}

public interface ItestRefGnrcFieldParamOutpObject<Tref>
{
}

public interface ItestAltGnrcFieldParamOutp
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcFieldParamOutpObject AsAltGnrcFieldParamOutp { get; set; }
}

public interface ItestAltGnrcFieldParamOutpObject
{
  public ItestNumber Alt { get; set; }
}
