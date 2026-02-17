//HintName: test_constraint-dom-enum+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public class testCnstDomEnumDual
  : ItestCnstDomEnumDual
{
}

public class testRefCnstDomEnumDual<TType>
  : ItestRefCnstDomEnumDual<TType>
{
  public TType Field { get; set; }
}

public class testJustCnstDomEnumDual
  : GqlpDomainEnum
  , ItestJustCnstDomEnumDual
{
}
