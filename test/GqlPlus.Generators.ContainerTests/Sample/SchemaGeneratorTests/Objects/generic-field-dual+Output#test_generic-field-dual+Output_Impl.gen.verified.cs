//HintName: test_generic-field-dual+Output_Impl.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public class testGnrcFieldDualOutp
  : ItestGnrcFieldDualOutp
{
  public ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; set; }
  public ItestGnrcFieldDualOutpObject AsGnrcFieldDualOutp { get; set; }
}

public class testRefGnrcFieldDualOutp<TRef>
  : ItestRefGnrcFieldDualOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldDualOutpObject AsRefGnrcFieldDualOutp { get; set; }
}

public class testAltGnrcFieldDualOutp
  : ItestAltGnrcFieldDualOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldDualOutpObject AsAltGnrcFieldDualOutp { get; set; }
}
