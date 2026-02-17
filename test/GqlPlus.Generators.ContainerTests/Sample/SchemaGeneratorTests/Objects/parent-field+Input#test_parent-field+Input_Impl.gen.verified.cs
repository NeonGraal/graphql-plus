//HintName: test_parent-field+Input_Impl.gen.cs
// Generated from {CurrentDirectory}parent-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public class testPrntFieldInp
  : testRefPrntFieldInp
  , ItestPrntFieldInp
{
  public decimal Field { get; set; }
}

public class testRefPrntFieldInp
  : ItestRefPrntFieldInp
{
  public decimal Parent { get; set; }
}
