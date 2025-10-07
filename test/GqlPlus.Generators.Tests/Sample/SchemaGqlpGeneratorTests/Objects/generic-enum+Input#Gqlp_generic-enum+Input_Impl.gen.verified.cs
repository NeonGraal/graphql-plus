//HintName: Gqlp_generic-enum+Input_Impl.gen.cs
// Generated from generic-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_enum_Input;

public class InputGnrcEnumInp
  : IGnrcEnumInp
{
  public RefGnrcEnumInp<EnumGnrcEnumInp> AsRefGnrcEnumInp { get; set; }
}

public class InputRefGnrcEnumInp<Ttype>
  : IRefGnrcEnumInp<Ttype>
{
  public Ttype field { get; set; }
}
