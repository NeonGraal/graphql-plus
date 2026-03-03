//HintName: test_generic-field+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Output;

public class testGnrcFieldOutp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcFieldOutp<TType>
{
  public ItestGnrcFieldOutpObject<TType>? As_GnrcFieldOutp { get; set; }
}

public class testGnrcFieldOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcFieldOutpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcFieldOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
