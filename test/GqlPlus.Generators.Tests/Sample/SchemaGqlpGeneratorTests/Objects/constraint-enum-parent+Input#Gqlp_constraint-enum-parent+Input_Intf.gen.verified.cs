//HintName: Gqlp_constraint-enum-parent+Input_Intf.gen.cs
// Generated from constraint-enum-parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_parent_Input;

public interface ICnstEnumPrntInp
{
  RefCnstEnumPrntInp<EnumCnstEnumPrntInp> AsRefCnstEnumPrntInp { get; }
}

public interface IRefCnstEnumPrntInp<Ttype>
{
  Ttype field { get; }
}
