//HintName: Gqlp_constraint-enum+Output_Intf.gen.cs
// Generated from constraint-enum+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_Output;

public interface ICnstEnumOutp
{
  RefCnstEnumOutp<EnumCnstEnumOutp> AsRefCnstEnumOutp { get; }
}

public interface IRefCnstEnumOutp<Ttype>
{
  Ttype field { get; }
}
