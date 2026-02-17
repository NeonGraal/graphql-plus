//HintName: test_constraint-dom-enum+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public class testCnstDomEnumOutp
  : ItestCnstDomEnumOutp
{
}

public class testRefCnstDomEnumOutp<TType>
  : ItestRefCnstDomEnumOutp<TType>
{
  public TType Field { get; set; }
}

public class testJustCnstDomEnumOutp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumOutp
{
}
