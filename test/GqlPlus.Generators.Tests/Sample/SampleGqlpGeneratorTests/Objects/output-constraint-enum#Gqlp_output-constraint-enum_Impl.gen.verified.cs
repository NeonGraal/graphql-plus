//HintName: Gqlp_output-constraint-enum_Impl.gen.cs
// Generated from output-constraint-enum.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_constraint_enum;
public class OutputOutpCnstEnum
  : IOutpCnstEnum
{
  public RefOutpCnstEnum<outpCnstEnum> AsRefOutpCnstEnum { get; set; }
}
public class OutputRefOutpCnstEnum<Ttype>
  : IRefOutpCnstEnum<Ttype>
{
  public Ttype field { get; set; }
}
