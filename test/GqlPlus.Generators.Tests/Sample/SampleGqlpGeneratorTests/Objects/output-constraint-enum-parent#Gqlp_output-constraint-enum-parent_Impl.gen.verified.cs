//HintName: Gqlp_output-constraint-enum-parent_Impl.gen.cs
// Generated from output-constraint-enum-parent.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_constraint_enum_parent;
public class OutputOutpCnstEnumPrnt
  : IOutpCnstEnumPrnt
{
  public RefOutpCnstEnumPrnt<outpCnstEnumPrnt> AsRefOutpCnstEnumPrnt { get; set; }
}
public class OutputRefOutpCnstEnumPrnt<Ttype>
  : IRefOutpCnstEnumPrnt<Ttype>
{
  public Ttype field { get; set; }
}
