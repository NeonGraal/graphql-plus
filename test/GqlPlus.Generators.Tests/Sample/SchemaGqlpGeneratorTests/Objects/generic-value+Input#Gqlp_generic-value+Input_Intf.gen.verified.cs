//HintName: Gqlp_generic-value+Input_Intf.gen.cs
// Generated from generic-value+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_value_Input;

public interface IGnrcValueInp
{
  RefGnrcValueInp<EnumGnrcValueInp> AsRefGnrcValueInp { get; }
}

public interface IRefGnrcValueInp<Ttype>
{
  Ttype field { get; }
}
