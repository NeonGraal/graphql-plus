//HintName: test_generic-field-param+Output_Impl.gen.cs
// Generated from generic-field-param+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public class testGnrcFieldParamOutp
  : ItestGnrcFieldParamOutp
{
  public testRefGnrcFieldParamOutp<testAltGnrcFieldParamOutp> field { get; set; }
  public testGnrcFieldParamOutp GnrcFieldParamOutp { get; set; }
}

public class testRefGnrcFieldParamOutp<Tref>
  : ItestRefGnrcFieldParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldParamOutp RefGnrcFieldParamOutp { get; set; }
}

public class testAltGnrcFieldParamOutp
  : ItestAltGnrcFieldParamOutp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcFieldParamOutp AltGnrcFieldParamOutp { get; set; }
}
