//HintName: test_generic-parent-arg+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

public class testGnrcPrntArgInp<TType>
  : testRefGnrcPrntArgInp<TType>
  , ItestGnrcPrntArgInp<TType>
{
  public ItestGnrcPrntArgInpObject<TType>? As_GnrcPrntArgInp { get; set; }
}

public class testGnrcPrntArgInpObject<TType>
  : testRefGnrcPrntArgInpObject<TType>
  , ItestGnrcPrntArgInpObject<TType>
{

  public testGnrcPrntArgInpObject
    ()
  {
  }
}

public class testRefGnrcPrntArgInp<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntArgInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntArgInpObject<TRef>? As_RefGnrcPrntArgInp { get; set; }
}

public class testRefGnrcPrntArgInpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntArgInpObject<TRef>
{

  public testRefGnrcPrntArgInpObject
    ()
  {
  }
}
