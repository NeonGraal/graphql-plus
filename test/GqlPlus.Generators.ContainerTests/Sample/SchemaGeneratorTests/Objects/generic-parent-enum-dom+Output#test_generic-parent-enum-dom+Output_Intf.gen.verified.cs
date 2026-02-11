//HintName: test_generic-parent-enum-dom+Output_Intf.gen.cs
// Generated from generic-parent-enum-dom+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

public interface ItestGnrcPrntEnumDomOutp
  : ItestFieldGnrcPrntEnumDomOutp
{
  ItestGnrcPrntEnumDomOutpObject AsGnrcPrntEnumDomOutp { get; }
}

public interface ItestGnrcPrntEnumDomOutpObject
  : ItestFieldGnrcPrntEnumDomOutpObject
{
}

public interface ItestFieldGnrcPrntEnumDomOutp<Tref>
{
  ItestFieldGnrcPrntEnumDomOutpObject AsFieldGnrcPrntEnumDomOutp { get; }
}

public interface ItestFieldGnrcPrntEnumDomOutpObject<Tref>
{
  Tref Field { get; }
}

public interface ItestDomGnrcPrntEnumDomOutp
  : IDomainEnum
{
}
