//HintName: Gqlp_output-constraint-parent-enum_Intf.gen.cs
// Generated from output-constraint-parent-enum.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_constraint_parent_enum;

public interface IOutpCnstPrntEnum
{
  RefOutpCnstPrntEnum<parentOutpCnstPrntEnum> AsRefOutpCnstPrntEnum { get; }
}

public interface IRefOutpCnstPrntEnum<Ttype>
{
  Ttype field { get; }
}
