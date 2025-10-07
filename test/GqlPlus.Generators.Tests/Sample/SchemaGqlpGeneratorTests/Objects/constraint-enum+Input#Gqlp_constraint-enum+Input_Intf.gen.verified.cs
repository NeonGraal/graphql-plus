//HintName: Gqlp_constraint-enum+Input_Intf.gen.cs
// Generated from constraint-enum+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_Input;

public interface ICnstEnumInp
{
  RefCnstEnumInp<EnumCnstEnumInp> AsRefCnstEnumInp { get; }
}

public interface IRefCnstEnumInp<Ttype>
{
  Ttype field { get; }
}
