//HintName: test_constraint-enum-parent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public class testCnstEnumPrntDual
  : ItestCnstEnumPrntDual
{
}

public class testRefCnstEnumPrntDual<TType>
  : ItestRefCnstEnumPrntDual<TType>
{
  public TType Field { get; set; }
}
