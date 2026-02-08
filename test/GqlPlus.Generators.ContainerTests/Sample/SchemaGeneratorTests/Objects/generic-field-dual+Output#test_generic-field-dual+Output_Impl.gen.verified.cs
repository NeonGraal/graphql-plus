//HintName: test_generic-field-dual+Output_Impl.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public class testGnrcFieldDualOutp
  : ItestGnrcFieldDualOutp
{
  public ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; set; }
}

public class testRefGnrcFieldDualOutp<Tref>
  : ItestRefGnrcFieldDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcFieldDualOutp
  : ItestAltGnrcFieldDualOutp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
}
