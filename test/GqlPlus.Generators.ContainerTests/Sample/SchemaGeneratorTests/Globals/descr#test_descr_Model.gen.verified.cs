//HintName: test_descr_Model.gen.cs
// Generated from {CurrentDirectory}descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr;

public class testDescr
  : GqlpModelBase
  , ItestDescr
{
  public ItestDescrObject? As_Descr { get; set; }
}

public class testDescrObject
  : GqlpModelBase
  , ItestDescrObject
{

  public testDescrObject
    ()
  {
  }
}
