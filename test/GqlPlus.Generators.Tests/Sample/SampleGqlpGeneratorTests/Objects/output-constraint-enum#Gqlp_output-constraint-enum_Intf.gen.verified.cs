//HintName: Gqlp_output-constraint-enum_Intf.gen.cs
// Generated from output-constraint-enum.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_constraint_enum;

public interface IOutpCnstEnum
{
  RefOutpCnstEnum<outpCnstEnum> AsRefOutpCnstEnum { get; }
}

public interface IRefOutpCnstEnum<Ttype>
{
  Ttype field { get; }
}
