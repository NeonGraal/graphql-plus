//HintName: test_generic-enum+Input_Impl.gen.cs
// Generated from generic-enum+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public class testGnrcEnumInp
  : ItestGnrcEnumInp
{
  public testRefGnrcEnumInp<testEnumGnrcEnumInp> AsRefGnrcEnumInp { get; set; }
  public testGnrcEnumInp GnrcEnumInp { get; set; }
}

public class testRefGnrcEnumInp<Ttype>
  : ItestRefGnrcEnumInp<Ttype>
{
  public Ttype field { get; set; }
  public testRefGnrcEnumInp RefGnrcEnumInp { get; set; }
}
