//HintName: test_generic-enum+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public class testGnrcEnumDual
  : ItestGnrcEnumDual
{
}

public class testRefGnrcEnumDual<TType>
  : ItestRefGnrcEnumDual<TType>
{
  public TType Field { get; set; }
}
