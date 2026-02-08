//HintName: test_constraint-field-dual+Input_Impl.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public class testCnstFieldDualInp
  : testRefCnstFieldDualInp
  , ItestCnstFieldDualInp
{
  public ItestCnstFieldDualInpObject AsCnstFieldDualInp { get; set; }
}

public class testRefCnstFieldDualInp<Tref>
  : ItestRefCnstFieldDualInp<Tref>
{
  public Tref Field { get; set; }
  public ItestRefCnstFieldDualInpObject AsRefCnstFieldDualInp { get; set; }
}

public class testPrntCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstFieldDualInpObject AsPrntCnstFieldDualInp { get; set; }
}

public class testAltCnstFieldDualInp
  : testPrntCnstFieldDualInp
  , ItestAltCnstFieldDualInp
{
  public ItestNumber Alt { get; set; }
  public ItestAltCnstFieldDualInpObject AsAltCnstFieldDualInp { get; set; }
}
