//HintName: Gqlp_constraint-dom-enum+Input_Intf.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_dom_enum_Input;

public interface ICnstDomEnumInp
{
  RefCnstDomEnumInp<EnumCnstDomEnumInp> AsRefCnstDomEnumInp { get; }
}

public interface IRefCnstDomEnumInp<Ttype>
{
  Ttype field { get; }
}

public interface IJustCnstDomEnumInp
{
}
