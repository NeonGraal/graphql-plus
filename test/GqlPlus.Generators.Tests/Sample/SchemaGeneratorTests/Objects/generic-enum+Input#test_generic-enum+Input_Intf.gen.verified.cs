//HintName: test_generic-enum+Input_Intf.gen.cs
// Generated from generic-enum+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public interface ItestGnrcEnumInp
{
  RefGnrcEnumInp<EnumGnrcEnumInp> AsRefGnrcEnumInp { get; }
}

public interface ItestRefGnrcEnumInp<Ttype>
{
  Ttype field { get; }
}
