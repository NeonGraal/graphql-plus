//HintName: test_generic-field-dual+Output_Impl.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public class testGnrcFieldDualOutp
  : ItestGnrcFieldDualOutp
{
  public testRefGnrcFieldDualOutp<testAltGnrcFieldDualOutp> field { get; set; }
  public testGnrcFieldDualOutp GnrcFieldDualOutp { get; set; }
}

public class testRefGnrcFieldDualOutp<Tref>
  : ItestRefGnrcFieldDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldDualOutp RefGnrcFieldDualOutp { get; set; }
}

public class testAltGnrcFieldDualOutp
  : ItestAltGnrcFieldDualOutp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcFieldDualOutp AltGnrcFieldDualOutp { get; set; }
}
