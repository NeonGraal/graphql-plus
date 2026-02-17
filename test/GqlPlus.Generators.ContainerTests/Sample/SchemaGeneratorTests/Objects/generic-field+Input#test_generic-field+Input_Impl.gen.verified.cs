//HintName: test_generic-field+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public class testGnrcFieldInp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcFieldInp<TType>
{
  public ItestGnrcFieldInpObject<TType>? As_GnrcFieldInp { get; set; }
}

public class testGnrcFieldInpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcFieldInpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcFieldInpObject(TType field)
  {
    Field = field;
  }
}
