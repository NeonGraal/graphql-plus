//HintName: test_constraint-enum+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public class testCnstEnumOutp
  : ItestCnstEnumOutp
{
}

public class testRefCnstEnumOutp<TType>
  : ItestRefCnstEnumOutp<TType>
{
  public TType Field { get; set; }
}
