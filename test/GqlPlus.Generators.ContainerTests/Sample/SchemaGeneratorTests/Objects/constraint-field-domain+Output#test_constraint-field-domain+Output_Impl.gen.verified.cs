//HintName: test_constraint-field-domain+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public class testCnstFieldDmnOutp
  : testRefCnstFieldDmnOutp<ItestDomCnstFieldDmnOutp>
  , ItestCnstFieldDmnOutp
{
}

public class testRefCnstFieldDmnOutp<TRef>
  : ItestRefCnstFieldDmnOutp<TRef>
{
  public TRef Field { get; set; }
}

public class testDomCnstFieldDmnOutp
  : GqlpDomainString
  , ItestDomCnstFieldDmnOutp
{
}
