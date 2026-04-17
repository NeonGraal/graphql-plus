//HintName: test_generic-enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public class testGnrcEnumInp
  : GqlpModelBase
  , ItestGnrcEnumInp
{
  public ItestRefGnrcEnumInp<testEnumGnrcEnumInp>? AsEnumGnrcEnumInpgnrcEnumInp { get; set; }
  public ItestGnrcEnumInpObject? As_GnrcEnumInp { get; set; }
}

public class testGnrcEnumInpObject
  : GqlpModelBase
  , ItestGnrcEnumInpObject
{

  public testGnrcEnumInpObject
    ()
  {
  }
}

public class testRefGnrcEnumInp<TType>
  : GqlpModelBase
  , ItestRefGnrcEnumInp<TType>
{
  public ItestRefGnrcEnumInpObject<TType>? As_RefGnrcEnumInp { get; set; }
}

public class testRefGnrcEnumInpObject<TType>
  : GqlpModelBase
  , ItestRefGnrcEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcEnumInpObject
    ( TType field
    )
  {
    Field = field;
  }
}
