//HintName: test_constraint-field-domain+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

public class testCnstFieldDmnDual
  : testRefCnstFieldDmnDual<ItestDomCnstFieldDmnDual>
  , ItestCnstFieldDmnDual
{
}

public class testRefCnstFieldDmnDual<TRef>
  : ItestRefCnstFieldDmnDual<TRef>
{
  public TRef Field { get; set; }
}

public class testDomCnstFieldDmnDual
  : GqlpDomainString
  , ItestDomCnstFieldDmnDual
{
}
