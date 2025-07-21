//HintName: Gqlp_output-generic-enum_Intf.gen.cs
// Generated from output-generic-enum.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_generic_enum;

public interface IOutpGnrcEnum
{
  RefOutpGnrcEnum<EnumOutpGnrcEnum> AsRefOutpGnrcEnum { get; }
}

public interface IRefOutpGnrcEnum<Ttype>
{
  Ttype field { get; }
}
