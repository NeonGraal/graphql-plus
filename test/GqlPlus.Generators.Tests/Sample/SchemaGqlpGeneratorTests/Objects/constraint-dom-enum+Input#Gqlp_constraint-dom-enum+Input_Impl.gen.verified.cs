//HintName: Gqlp_constraint-dom-enum+Input_Impl.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_dom_enum_Input;

public class InputCnstDomEnumInp
  : ICnstDomEnumInp
{
  public RefCnstDomEnumInp<EnumCnstDomEnumInp> AsRefCnstDomEnumInp { get; set; }
}

public class InputRefCnstDomEnumInp<Ttype>
  : IRefCnstDomEnumInp<Ttype>
{
  public Ttype field { get; set; }
}

public class DomainJustCnstDomEnumInp
  : IJustCnstDomEnumInp
{
}
