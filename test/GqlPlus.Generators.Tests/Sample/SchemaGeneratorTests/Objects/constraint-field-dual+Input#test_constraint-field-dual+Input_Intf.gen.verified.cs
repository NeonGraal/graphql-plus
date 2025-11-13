//HintName: test_constraint-field-dual+Input_Intf.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public interface ItestCnstFieldDualInp
  : ItestRefCnstFieldDualInp
{
  public testCnstFieldDualInp CnstFieldDualInp { get; set; }
}

public interface ItestCnstFieldDualInpField
  : ItestRefCnstFieldDualInpField
{
}

public interface ItestRefCnstFieldDualInp<Tref>
{
  public testRefCnstFieldDualInp RefCnstFieldDualInp { get; set; }
}

public interface ItestRefCnstFieldDualInpField<Tref>
{
  public Tref field { get; set; }
}

public interface ItestPrntCnstFieldDualInp
{
  public testString AsString { get; set; }
  public testPrntCnstFieldDualInp PrntCnstFieldDualInp { get; set; }
}

public interface ItestPrntCnstFieldDualInpField
{
}

public interface ItestAltCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  public testAltCnstFieldDualInp AltCnstFieldDualInp { get; set; }
}

public interface ItestAltCnstFieldDualInpField
  : ItestPrntCnstFieldDualInpField
{
  public testNumber alt { get; set; }
}
