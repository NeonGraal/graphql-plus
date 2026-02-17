//HintName: test_generic-parent-enum-dom+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

public class testGnrcPrntEnumDomOutp
  : testFieldGnrcPrntEnumDomOutp<ItestDomGnrcPrntEnumDomOutp>
  , ItestGnrcPrntEnumDomOutp
{
}

public class testFieldGnrcPrntEnumDomOutp<TRef>
  : ItestFieldGnrcPrntEnumDomOutp<TRef>
{
  public TRef Field { get; set; }
}

public class testDomGnrcPrntEnumDomOutp
  : GqlpDomainEnum
  , ItestDomGnrcPrntEnumDomOutp
{
}
