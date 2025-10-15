//HintName: test_generic-enum+Input_Impl.gen.cs
// Generated from generic-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public class InputtestGnrcEnumInp
  : ItestGnrcEnumInp
{
  public RefGnrcEnumInp<EnumGnrcEnumInp> AsRefGnrcEnumInp { get; set; }
}

public class InputtestRefGnrcEnumInp<Ttype>
  : ItestRefGnrcEnumInp<Ttype>
{
  public Ttype field { get; set; }
}
