//HintName: Gqlp_constraint-enum-parent+Output_Intf.gen.cs
// Generated from constraint-enum-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_parent_Output;

public interface ICnstEnumPrntOutp
{
  RefCnstEnumPrntOutp<EnumCnstEnumPrntOutp> AsRefCnstEnumPrntOutp { get; }
}

public interface IRefCnstEnumPrntOutp<Ttype>
{
  Ttype field { get; }
}
