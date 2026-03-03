//HintName: test_generic-enum+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public class testGnrcEnumInp
  : GqlpModelImplementationBase
  , ItestGnrcEnumInp
{
  public ItestRefGnrcEnumInp<testEnumGnrcEnumInp>? AsEnumGnrcEnumInpgnrcEnumInp { get; set; }
  public ItestGnrcEnumInpObject? As_GnrcEnumInp { get; set; }
}

public class testGnrcEnumInpObject
  : GqlpModelImplementationBase
  , ItestGnrcEnumInpObject
{

  public testGnrcEnumInpObject
    ()
  {
  }
}

public class testRefGnrcEnumInp<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcEnumInp<TType>
{
  public ItestRefGnrcEnumInpObject<TType>? As_RefGnrcEnumInp { get; set; }
}

public class testRefGnrcEnumInpObject<TType>
  : GqlpModelImplementationBase
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
