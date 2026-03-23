//HintName: test_generic-parent-enum-dom+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

public interface ItestGnrcPrntEnumDomOutp
  : ItestFieldGnrcPrntEnumDomOutp<ItestDomGnrcPrntEnumDomOutp>
{
  ItestGnrcPrntEnumDomOutpObject? As_GnrcPrntEnumDomOutp { get; }
}

public interface ItestGnrcPrntEnumDomOutpObject
  : ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>
{
}

public interface ItestFieldGnrcPrntEnumDomOutp<TRef>
  : IGqlpModelImplementationBase
{
  ItestFieldGnrcPrntEnumDomOutpObject<TRef>? As_FieldGnrcPrntEnumDomOutp { get; }
}

public interface ItestFieldGnrcPrntEnumDomOutpObject<TRef>
  : IGqlpModelImplementationBase
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntEnumDomOutp
  : IGqlpDomainEnum
{
  new testEnumGnrcPrntEnumDomOutp? Value { get; }
}
