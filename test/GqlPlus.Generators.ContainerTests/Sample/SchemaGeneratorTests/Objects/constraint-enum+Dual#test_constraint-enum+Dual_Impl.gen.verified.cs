//HintName: test_constraint-enum+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public class testCnstEnumDual
  : ItestCnstEnumDual
{
}

public class testRefCnstEnumDual<TType>
  : ItestRefCnstEnumDual<TType>
{
  public TType Field { get; set; }
}
