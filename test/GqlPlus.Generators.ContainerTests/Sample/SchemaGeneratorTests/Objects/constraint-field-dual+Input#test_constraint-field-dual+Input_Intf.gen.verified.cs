//HintName: test_constraint-field-dual+Input_Intf.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public interface ItestCnstFieldDualInp
  : ItestRefCnstFieldDualInp
{
}

public interface ItestCnstFieldDualInpObject
  : ItestRefCnstFieldDualInpObject
{
}

public interface ItestRefCnstFieldDualInp<Tref>
{
}

public interface ItestRefCnstFieldDualInpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldDualInp
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstFieldDualInpObject
{
}

public interface ItestAltCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
}

public interface ItestAltCnstFieldDualInpObject
  : ItestPrntCnstFieldDualInpObject
{
  public ItestNumber Alt { get; set; }
}
