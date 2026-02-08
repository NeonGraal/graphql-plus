//HintName: test_constraint-enum-parent+Input_Impl.gen.cs
// Generated from constraint-enum-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public class testCnstEnumPrntInp
  : ItestCnstEnumPrntInp
{
  public ItestRefCnstEnumPrntInp<ItestEnumCnstEnumPrntInp> AsRefCnstEnumPrntInp { get; set; }
  public ItestCnstEnumPrntInpObject AsCnstEnumPrntInp { get; set; }
}

public class testRefCnstEnumPrntInp<Ttype>
  : ItestRefCnstEnumPrntInp<Ttype>
{
  public Ttype Field { get; set; }
  public ItestRefCnstEnumPrntInpObject AsRefCnstEnumPrntInp { get; set; }
}
