//HintName: test_generic-parent-string-dom+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

public class testGnrcPrntStrDomOutp
  : testFieldGnrcPrntStrDomOutp<ItestDomGnrcPrntStrDomOutp>
  , ItestGnrcPrntStrDomOutp
{
}

public class testFieldGnrcPrntStrDomOutp<TRef>
  : ItestFieldGnrcPrntStrDomOutp<TRef>
{
  public TRef Field { get; set; }
}

public class testDomGnrcPrntStrDomOutp
  : GqlpDomainString
  , ItestDomGnrcPrntStrDomOutp
{
}
