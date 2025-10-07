//HintName: Gqlp_constraint-enum+Output_Impl.gen.cs
// Generated from constraint-enum+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_Output;

public class OutputCnstEnumOutp
  : ICnstEnumOutp
{
  public RefCnstEnumOutp<EnumCnstEnumOutp> AsRefCnstEnumOutp { get; set; }
}

public class OutputRefCnstEnumOutp<Ttype>
  : IRefCnstEnumOutp<Ttype>
{
  public Ttype field { get; set; }
}
