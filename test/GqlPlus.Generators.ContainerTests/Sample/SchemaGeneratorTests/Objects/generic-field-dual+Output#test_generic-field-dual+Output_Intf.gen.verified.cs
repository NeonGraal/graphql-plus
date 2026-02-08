//HintName: test_generic-field-dual+Output_Intf.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public interface ItestGnrcFieldDualOutp
{
  public ItestGnrcFieldDualOutpObject AsGnrcFieldDualOutp { get; set; }
}

public interface ItestGnrcFieldDualOutpObject
{
  public ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; set; }
}

public interface ItestRefGnrcFieldDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldDualOutpObject AsRefGnrcFieldDualOutp { get; set; }
}

public interface ItestRefGnrcFieldDualOutpObject<Tref>
{
}

public interface ItestAltGnrcFieldDualOutp
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcFieldDualOutpObject AsAltGnrcFieldDualOutp { get; set; }
}

public interface ItestAltGnrcFieldDualOutpObject
{
  public ItestNumber Alt { get; set; }
}
