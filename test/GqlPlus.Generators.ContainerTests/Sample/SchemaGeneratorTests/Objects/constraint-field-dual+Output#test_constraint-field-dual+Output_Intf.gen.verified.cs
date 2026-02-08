//HintName: test_constraint-field-dual+Output_Intf.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public interface ItestCnstFieldDualOutp
  : ItestRefCnstFieldDualOutp
{
}

public interface ItestCnstFieldDualOutpObject
  : ItestRefCnstFieldDualOutpObject
{
}

public interface ItestRefCnstFieldDualOutp<Tref>
{
}

public interface ItestRefCnstFieldDualOutpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldDualOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstFieldDualOutpObject
{
}

public interface ItestAltCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
}

public interface ItestAltCnstFieldDualOutpObject
  : ItestPrntCnstFieldDualOutpObject
{
  public ItestNumber Alt { get; set; }
}
