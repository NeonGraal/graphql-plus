//HintName: test_generic-enum+Input_Impl.gen.cs
// Generated from generic-enum+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public class testGnrcEnumInp
  : ItestGnrcEnumInp
{
  public ItestRefGnrcEnumInp<testEnumGnrcEnumInp> AsRefGnrcEnumInp { get; set; }
  public ItestGnrcEnumInpObject AsGnrcEnumInp { get; set; }
}

public class testRefGnrcEnumInp<Ttype>
  : ItestRefGnrcEnumInp<Ttype>
{
  public Ttype Field { get; set; }
  public ItestRefGnrcEnumInpObject AsRefGnrcEnumInp { get; set; }
}
