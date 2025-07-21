//HintName: Gqlp_output-generic-enum_Impl.gen.cs
// Generated from output-generic-enum.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_generic_enum;
public class OutputOutpGnrcEnum
  : IOutpGnrcEnum
{
  public RefOutpGnrcEnum<EnumOutpGnrcEnum> AsRefOutpGnrcEnum { get; set; }
}
public class OutputRefOutpGnrcEnum<Ttype>
  : IRefOutpGnrcEnum<Ttype>
{
  public Ttype field { get; set; }
}
