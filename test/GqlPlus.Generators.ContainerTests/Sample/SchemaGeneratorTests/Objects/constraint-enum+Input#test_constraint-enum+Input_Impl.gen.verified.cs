//HintName: test_constraint-enum+Input_Impl.gen.cs
// Generated from constraint-enum+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public class testCnstEnumInp
  : ItestCnstEnumInp
{
  public ItestRefCnstEnumInp<ItestEnumCnstEnumInp> AsRefCnstEnumInp { get; set; }
  public ItestCnstEnumInpObject AsCnstEnumInp { get; set; }
}

public class testRefCnstEnumInp<Ttype>
  : ItestRefCnstEnumInp<Ttype>
{
  public Ttype Field { get; set; }
  public ItestRefCnstEnumInpObject AsRefCnstEnumInp { get; set; }
}
