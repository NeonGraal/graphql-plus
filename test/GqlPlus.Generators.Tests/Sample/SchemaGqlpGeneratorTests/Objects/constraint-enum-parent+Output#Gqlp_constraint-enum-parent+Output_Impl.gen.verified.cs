//HintName: Gqlp_constraint-enum-parent+Output_Impl.gen.cs
// Generated from constraint-enum-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_parent_Output;

public class OutputCnstEnumPrntOutp
  : ICnstEnumPrntOutp
{
  public RefCnstEnumPrntOutp<EnumCnstEnumPrntOutp> AsRefCnstEnumPrntOutp { get; set; }
}

public class OutputRefCnstEnumPrntOutp<Ttype>
  : IRefCnstEnumPrntOutp<Ttype>
{
  public Ttype field { get; set; }
}
