//HintName: test_generic-field-dual+Output_Impl.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public class testGnrcFieldDualOutp
  : ItestGnrcFieldDualOutp
{
  public RefGnrcFieldDualOutp<AltGnrcFieldDualOutp> field { get; set; }
}

public class testRefGnrcFieldDualOutp<Tref>
  : ItestRefGnrcFieldDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcFieldDualOutp
  : ItestAltGnrcFieldDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
