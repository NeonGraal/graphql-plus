//HintName: test_generic-enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public class testGnrcEnumOutp
  : GqlpModelBase
  , ItestGnrcEnumOutp
{
  public ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp>? AsEnumGnrcEnumOutpgnrcEnumOutp { get; set; }
  public ItestGnrcEnumOutpObject? As_GnrcEnumOutp { get; set; }
}

public class testGnrcEnumOutpObject
  : GqlpModelBase
  , ItestGnrcEnumOutpObject
{

  public testGnrcEnumOutpObject
    ()
  {
  }
}

public class testRefGnrcEnumOutp<TType>
  : GqlpModelBase
  , ItestRefGnrcEnumOutp<TType>
{
  public ItestRefGnrcEnumOutpObject<TType>? As_RefGnrcEnumOutp { get; set; }
}

public class testRefGnrcEnumOutpObject<TType>
  : GqlpModelBase
  , ItestRefGnrcEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcEnumOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
