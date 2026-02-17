//HintName: test_generic-field-arg+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

public class testGnrcFieldArgOutp<TType>
  : ItestGnrcFieldArgOutp<TType>
{
  public ItestRefGnrcFieldArgOutp<TType> Field { get; set; }
}

public class testRefGnrcFieldArgOutp<TRef>
  : ItestRefGnrcFieldArgOutp<TRef>
{
}
