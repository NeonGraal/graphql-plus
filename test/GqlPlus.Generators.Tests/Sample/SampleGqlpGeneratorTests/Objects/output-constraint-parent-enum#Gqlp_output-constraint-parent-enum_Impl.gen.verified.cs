//HintName: Gqlp_output-constraint-parent-enum_Impl.gen.cs
// Generated from output-constraint-parent-enum.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_constraint_parent_enum;
public class OutputOutpCnstPrntEnum
  : IOutpCnstPrntEnum
{
  public RefOutpCnstPrntEnum<parentOutpCnstPrntEnum> AsRefOutpCnstPrntEnum { get; set; }
}
public class OutputRefOutpCnstPrntEnum<Ttype>
  : IRefOutpCnstPrntEnum<Ttype>
{
  public Ttype field { get; set; }
}
