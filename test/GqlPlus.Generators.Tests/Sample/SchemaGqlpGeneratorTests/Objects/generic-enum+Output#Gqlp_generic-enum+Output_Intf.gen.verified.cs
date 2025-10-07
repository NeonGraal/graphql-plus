//HintName: Gqlp_generic-enum+Output_Intf.gen.cs
// Generated from generic-enum+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_enum_Output;

public interface IGnrcEnumOutp
{
  RefGnrcEnumOutp<EnumGnrcEnumOutp> AsRefGnrcEnumOutp { get; }
}

public interface IRefGnrcEnumOutp<Ttype>
{
  Ttype field { get; }
}
