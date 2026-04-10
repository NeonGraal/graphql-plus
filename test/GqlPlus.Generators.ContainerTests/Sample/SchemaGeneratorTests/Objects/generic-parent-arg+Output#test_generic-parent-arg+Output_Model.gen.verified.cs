//HintName: test_generic-parent-arg+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

public class testGnrcPrntArgOutp<TType>
  : testRefGnrcPrntArgOutp<TType>
  , ItestGnrcPrntArgOutp<TType>
{
  public ItestGnrcPrntArgOutpObject<TType>? As_GnrcPrntArgOutp { get; set; }
}

public class testGnrcPrntArgOutpObject<TType>
  : testRefGnrcPrntArgOutpObject<TType>
  , ItestGnrcPrntArgOutpObject<TType>
{

  public testGnrcPrntArgOutpObject
    ()
  {
  }
}

public class testRefGnrcPrntArgOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntArgOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntArgOutpObject<TRef>? As_RefGnrcPrntArgOutp { get; set; }
}

public class testRefGnrcPrntArgOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntArgOutpObject<TRef>
{

  public testRefGnrcPrntArgOutpObject
    ()
  {
  }
}
