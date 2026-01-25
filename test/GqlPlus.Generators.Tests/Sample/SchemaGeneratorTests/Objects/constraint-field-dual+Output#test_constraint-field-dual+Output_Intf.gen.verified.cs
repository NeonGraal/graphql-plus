//HintName: test_constraint-field-dual+Output_Intf.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public interface ItestCnstFieldDualOutp
  : ItestRefCnstFieldDualOutp
{
  public testCnstFieldDualOutp CnstFieldDualOutp { get; set; }
}

public interface ItestCnstFieldDualOutpObject
  : ItestRefCnstFieldDualOutpObject
{
}

public interface ItestRefCnstFieldDualOutp<Tref>
{
  public testRefCnstFieldDualOutp RefCnstFieldDualOutp { get; set; }
}

public interface ItestRefCnstFieldDualOutpObject<Tref>
{
  public Tref field { get; set; }
}

public interface ItestPrntCnstFieldDualOutp
{
  public testString AsString { get; set; }
  public testPrntCnstFieldDualOutp PrntCnstFieldDualOutp { get; set; }
}

public interface ItestPrntCnstFieldDualOutpObject
{
}

public interface ItestAltCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  public testAltCnstFieldDualOutp AltCnstFieldDualOutp { get; set; }
}

public interface ItestAltCnstFieldDualOutpObject
  : ItestPrntCnstFieldDualOutpObject
{
  public testNumber alt { get; set; }
}
