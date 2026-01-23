//HintName: test_generic-enum+Input_Intf.gen.cs
// Generated from generic-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public interface ItestGnrcEnumInp
{
  public testRefGnrcEnumInp<testEnumGnrcEnumInp> AsRefGnrcEnumInp { get; set; }
  public testGnrcEnumInp GnrcEnumInp { get; set; }
}

public interface ItestGnrcEnumInpObject
{
}

public interface ItestRefGnrcEnumInp<Ttype>
{
  public testRefGnrcEnumInp RefGnrcEnumInp { get; set; }
}

public interface ItestRefGnrcEnumInpObject<Ttype>
{
  public Ttype field { get; set; }
}
