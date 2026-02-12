//HintName: test_generic-parent-enum-dom+Output_Intf.gen.cs
// Generated from generic-parent-enum-dom+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

public interface ItestGnrcPrntEnumDomOutp
  : ItestFieldGnrcPrntEnumDomOutp<ItestDomGnrcPrntEnumDomOutp>
{
  ItestGnrcPrntEnumDomOutpObject AsGnrcPrntEnumDomOutp { get; }
}

public interface ItestGnrcPrntEnumDomOutpObject
  : ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>
{
}

public interface ItestFieldGnrcPrntEnumDomOutp<TRef>
{
  ItestFieldGnrcPrntEnumDomOutpObject<TRef> AsFieldGnrcPrntEnumDomOutp { get; }
}

public interface ItestFieldGnrcPrntEnumDomOutpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntEnumDomOutp
  : IGqlpDomainEnum
{
}
