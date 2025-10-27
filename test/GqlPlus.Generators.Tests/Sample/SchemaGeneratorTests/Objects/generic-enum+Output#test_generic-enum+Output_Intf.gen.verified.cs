//HintName: test_generic-enum+Output_Intf.gen.cs
// Generated from generic-enum+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public interface ItestGnrcEnumOutp
{
  RefGnrcEnumOutp<EnumGnrcEnumOutp> AsRefGnrcEnumOutp { get; }
}

public interface ItestRefGnrcEnumOutp<Ttype>
{
  Ttype field { get; }
}
