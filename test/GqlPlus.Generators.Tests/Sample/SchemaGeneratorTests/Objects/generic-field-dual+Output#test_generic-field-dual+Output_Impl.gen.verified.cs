//HintName: test_generic-field-dual+Output_Impl.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public class OutputtestGnrcFieldDualOutp
  : ItestGnrcFieldDualOutp
{
  public RefGnrcFieldDualOutp<AltGnrcFieldDualOutp> field { get; set; }
}

public class OutputtestRefGnrcFieldDualOutp<Tref>
  : ItestRefGnrcFieldDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestAltGnrcFieldDualOutp
  : ItestAltGnrcFieldDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
