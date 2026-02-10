//HintName: test_constraint-field-dual+Input_Intf.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public interface ItestCnstFieldDualInp
  : ItestRefCnstFieldDualInp
{
  public ItestCnstFieldDualInpObject AsCnstFieldDualInp { get; set; }
}

public interface ItestCnstFieldDualInpObject
  : ItestRefCnstFieldDualInpObject
{
}

public interface ItestRefCnstFieldDualInp<Tref>
{
  public ItestRefCnstFieldDualInpObject AsRefCnstFieldDualInp { get; set; }
}

public interface ItestRefCnstFieldDualInpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldDualInp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldDualInpObject AsPrntCnstFieldDualInp { get; set; }
}

public interface ItestPrntCnstFieldDualInpObject
{
}

public interface ItestAltCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  public ItestAltCnstFieldDualInpObject AsAltCnstFieldDualInp { get; set; }
}

public interface ItestAltCnstFieldDualInpObject
  : ItestPrntCnstFieldDualInpObject
{
  public decimal Alt { get; set; }
}
