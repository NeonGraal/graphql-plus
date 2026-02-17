//HintName: test_generic-parent-string-dom+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

public class testGnrcPrntStrDomDual
  : testFieldGnrcPrntStrDomDual<ItestDomGnrcPrntStrDomDual>
  , ItestGnrcPrntStrDomDual
{
}

public class testFieldGnrcPrntStrDomDual<TRef>
  : ItestFieldGnrcPrntStrDomDual<TRef>
{
  public TRef Field { get; set; }
}

public class testDomGnrcPrntStrDomDual
  : GqlpDomainString
  , ItestDomGnrcPrntStrDomDual
{
}
