//HintName: test_constraint-parent-enum+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public class testCnstPrntEnumDual
  : ItestCnstPrntEnumDual
{
}

public class testRefCnstPrntEnumDual<TType>
  : ItestRefCnstPrntEnumDual<TType>
{
  public TType Field { get; set; }
}
