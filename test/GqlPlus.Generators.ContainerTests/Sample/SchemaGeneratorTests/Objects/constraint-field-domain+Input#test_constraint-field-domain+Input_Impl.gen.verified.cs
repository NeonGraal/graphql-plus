//HintName: test_constraint-field-domain+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

public class testCnstFieldDmnInp
  : testRefCnstFieldDmnInp<ItestDomCnstFieldDmnInp>
  , ItestCnstFieldDmnInp
{
}

public class testRefCnstFieldDmnInp<TRef>
  : ItestRefCnstFieldDmnInp<TRef>
{
  public TRef Field { get; set; }
}

public class testDomCnstFieldDmnInp
  : GqlpDomainString
  , ItestDomCnstFieldDmnInp
{
}
