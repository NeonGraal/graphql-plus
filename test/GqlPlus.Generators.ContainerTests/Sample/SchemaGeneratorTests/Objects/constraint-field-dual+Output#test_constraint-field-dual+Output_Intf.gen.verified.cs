//HintName: test_constraint-field-dual+Output_Intf.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public interface ItestCnstFieldDualOutp
  : ItestRefCnstFieldDualOutp
{
  public ItestCnstFieldDualOutpObject AsCnstFieldDualOutp { get; set; }
}

public interface ItestCnstFieldDualOutpObject
  : ItestRefCnstFieldDualOutpObject
{
}

public interface ItestRefCnstFieldDualOutp<Tref>
{
  public ItestRefCnstFieldDualOutpObject AsRefCnstFieldDualOutp { get; set; }
}

public interface ItestRefCnstFieldDualOutpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldDualOutp
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstFieldDualOutpObject AsPrntCnstFieldDualOutp { get; set; }
}

public interface ItestPrntCnstFieldDualOutpObject
{
}

public interface ItestAltCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  public ItestAltCnstFieldDualOutpObject AsAltCnstFieldDualOutp { get; set; }
}

public interface ItestAltCnstFieldDualOutpObject
  : ItestPrntCnstFieldDualOutpObject
{
  public ItestNumber Alt { get; set; }
}
