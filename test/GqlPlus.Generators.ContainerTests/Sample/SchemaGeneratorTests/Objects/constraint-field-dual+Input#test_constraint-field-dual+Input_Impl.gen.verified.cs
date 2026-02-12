//HintName: test_constraint-field-dual+Input_Impl.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public class testCnstFieldDualInp
  : testRefCnstFieldDualInp<ItestAltCnstFieldDualInp>
  , ItestCnstFieldDualInp
{
  public ItestCnstFieldDualInpObject AsCnstFieldDualInp { get; set; }
}

public class testRefCnstFieldDualInp<TRef>
  : ItestRefCnstFieldDualInp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldDualInpObject<TRef> AsRefCnstFieldDualInp { get; set; }
}

public class testPrntCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldDualInpObject AsPrntCnstFieldDualInp { get; set; }
}

public class testAltCnstFieldDualInp
  : testPrntCnstFieldDualInp
  , ItestAltCnstFieldDualInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldDualInpObject AsAltCnstFieldDualInp { get; set; }
}
