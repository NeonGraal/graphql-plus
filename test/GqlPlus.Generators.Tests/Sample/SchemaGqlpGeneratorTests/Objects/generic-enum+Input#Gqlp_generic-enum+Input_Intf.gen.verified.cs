//HintName: Gqlp_generic-enum+Input_Intf.gen.cs
// Generated from generic-enum+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_enum_Input;

public interface IGnrcEnumInp
{
  RefGnrcEnumInp<EnumGnrcEnumInp> AsRefGnrcEnumInp { get; }
}

public interface IRefGnrcEnumInp<Ttype>
{
  Ttype field { get; }
}
