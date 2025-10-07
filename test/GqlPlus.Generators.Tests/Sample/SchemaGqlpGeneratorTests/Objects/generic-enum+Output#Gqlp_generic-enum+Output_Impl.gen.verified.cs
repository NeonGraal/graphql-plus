//HintName: Gqlp_generic-enum+Output_Impl.gen.cs
// Generated from generic-enum+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_enum_Output;

public class OutputGnrcEnumOutp
  : IGnrcEnumOutp
{
  public RefGnrcEnumOutp<EnumGnrcEnumOutp> AsRefGnrcEnumOutp { get; set; }
}

public class OutputRefGnrcEnumOutp<Ttype>
  : IRefGnrcEnumOutp<Ttype>
{
  public Ttype field { get; set; }
}
