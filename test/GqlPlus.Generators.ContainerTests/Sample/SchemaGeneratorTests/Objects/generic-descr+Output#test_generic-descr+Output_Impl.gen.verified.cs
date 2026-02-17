//HintName: test_generic-descr+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Output;

public class testGnrcDescrOutp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcDescrOutp<TType>
{
  public ItestGnrcDescrOutpObject<TType>? As_GnrcDescrOutp { get; set; }
}

public class testGnrcDescrOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcDescrOutpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcDescrOutpObject(TType field)
  {
    Field = field;
  }
}
