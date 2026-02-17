//HintName: test_generic-parent-enum-dom+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public class testGnrcPrntEnumDomDual
  : testFieldGnrcPrntEnumDomDual<ItestDomGnrcPrntEnumDomDual>
  , ItestGnrcPrntEnumDomDual
{
}

public class testFieldGnrcPrntEnumDomDual<TRef>
  : ItestFieldGnrcPrntEnumDomDual<TRef>
{
  public TRef Field { get; set; }
}

public class testDomGnrcPrntEnumDomDual
  : GqlpDomainEnum
  , ItestDomGnrcPrntEnumDomDual
{
}
