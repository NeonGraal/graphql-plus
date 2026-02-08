//HintName: test_generic-enum+Input_Intf.gen.cs
// Generated from generic-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public interface ItestGnrcEnumInp
{
  public ItestRefGnrcEnumInp<ItestEnumGnrcEnumInp> AsRefGnrcEnumInp { get; set; }
  public ItestGnrcEnumInpObject AsGnrcEnumInp { get; set; }
}

public interface ItestGnrcEnumInpObject
{
}

public interface ItestRefGnrcEnumInp<Ttype>
{
  public ItestRefGnrcEnumInpObject AsRefGnrcEnumInp { get; set; }
}

public interface ItestRefGnrcEnumInpObject<Ttype>
{
  public Ttype Field { get; set; }
}
