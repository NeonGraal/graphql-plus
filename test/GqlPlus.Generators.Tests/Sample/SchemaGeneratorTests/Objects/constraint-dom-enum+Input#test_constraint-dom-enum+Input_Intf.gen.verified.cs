//HintName: test_constraint-dom-enum+Input_Intf.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public interface ItestCnstDomEnumInp
{
  RefCnstDomEnumInp<EnumCnstDomEnumInp> AsRefCnstDomEnumInp { get; }
}

public interface ItestRefCnstDomEnumInp<Ttype>
{
  Ttype field { get; }
}

public interface ItestJustCnstDomEnumInp
{
}
