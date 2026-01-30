//HintName: test_generic-field-dual+Output_Intf.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public interface ItestGnrcFieldDualOutp
{
  public testGnrcFieldDualOutp GnrcFieldDualOutp { get; set; }
}

public interface ItestGnrcFieldDualOutpObject
{
  public testRefGnrcFieldDualOutp<testAltGnrcFieldDualOutp> field { get; set; }
}

public interface ItestRefGnrcFieldDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldDualOutp RefGnrcFieldDualOutp { get; set; }
}

public interface ItestRefGnrcFieldDualOutpObject<Tref>
{
}

public interface ItestAltGnrcFieldDualOutp
{
  public testString AsString { get; set; }
  public testAltGnrcFieldDualOutp AltGnrcFieldDualOutp { get; set; }
}

public interface ItestAltGnrcFieldDualOutpObject
{
  public testNumber alt { get; set; }
}
